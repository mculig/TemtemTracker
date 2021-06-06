using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using TemtemTracker.Data;

namespace TemtemTracker.Controllers {
    class WebserverController : IDisposable {

        interface IRoute {
            string Identifier { get; }

            JObject Handle();
        }

        class RouteStatus : IRoute {
            private readonly TemtemDataTable table;

            public RouteStatus(TemtemDataTable table) {
                this.table = table;
            }

            public string Identifier => "/";
            public JObject Handle() {
                JObject obj = new JObject();
                long durationTime = table.timer.durationTime;

                obj.Add("time", HelperMethods.MilisToHMS(durationTime));

                if (durationTime == 0) {
                    durationTime = 1;
                }
                double durationTimeD = durationTime / (1000.0 * 60.0 * 60.0);
                obj.Add("temtem_per_hour", (double)table.timer.temtemCount / durationTimeD);

                JArray array = new JArray();
                foreach (TemtemDataRow row in table.rows) {
                    JObject encounteredObj = new JObject();
                    encounteredObj.Add("species", row.name);
                    encounteredObj.Add("encounters", row.encountered);
                    encounteredObj.Add("percentage", row.encounteredPercent);
                    encounteredObj.Add("time_to_luma", HelperMethods.MilisToHMS(row.timeToLuma));
                    array.Add(encounteredObj);
                }
                obj.Add("encountered", array);

                return obj;
            }
        }

        private readonly SettingsController settingsController;
        private readonly UserSettings settings;
        private readonly HttpListener httpListener;
        private readonly Dictionary<string, IRoute> routes;

        public WebserverController(SettingsController settingsController, UserSettings settings, TemtemDataTable table) {
            this.settingsController = settingsController;
            this.settings = settings;
            httpListener = new HttpListener();

            IRoute[] routes = new IRoute[] {
                new RouteStatus(table)
            };

            this.routes = new Dictionary<string, IRoute>();

            foreach (IRoute route in routes) {
                this.routes.Add(route.Identifier, route);
            }

            settingsController.WebserverEnabled+= SettingsControllerOnWebserverEnabled;
            settingsController.WebserverPortChanged += SettingsControllerOnWebserverPortChanged;

            if (settings.webserverEnabled) {
                Start();
            }
        }

        private void SettingsControllerOnWebserverEnabled(object sender, bool enabled) {
            if (httpListener.IsListening == false && enabled) {
                Start();
            }
            else if (httpListener.IsListening && enabled == false) {
                Stop();
            }
        }

        private void SettingsControllerOnWebserverPortChanged(object sender, int newPort) {
            if (httpListener.IsListening) {
                // Stop and start to apply the new port
                Stop();
                Start();
            }
        }


        public void Dispose() {
            if (httpListener.IsListening) {
                httpListener.Stop();
            }
        }

        private CancellationTokenSource cancelToken;

        public void Stop() {
            cancelToken.Cancel();
            httpListener.Stop();
            httpListener.Prefixes.Clear();
        }

        public void Start() {
            httpListener.Prefixes.Add($"http://localhost:{settings.webserverPort}/");
            httpListener.Start();

            cancelToken = new CancellationTokenSource();
            CancellationToken token = cancelToken.Token;

            Task.Run(() => {
                try {
                    while (token.IsCancellationRequested == false) {
                        HttpListenerContext context = httpListener.GetContext();
                        Task task = new Task(() => { HandleRequest(context); });
                        task.Start();
                    }
                }
                catch (InvalidOperationException) { }
                catch (HttpListenerException) {
                    // Thrown when the server gets stopped. Should be harmless to catch.
                }
            });
        }

        private void HandleRequest(HttpListenerContext context) {
            JObject response = null;
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            context.Response.Headers.Add("Access-Control-Allow-Methods", "POST, GET");
            context.Response.ContentType = "application/json";
            if (routes.TryGetValue(context.Request.RawUrl, out IRoute route)) {
                response = route.Handle();
            } else {
                context.Response.StatusCode = 404;
            }

            if (response != null) {
                byte[] buffer = Encoding.UTF8.GetBytes(response.ToString());
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            }

            context.Response.Close();
        }
    }
}

