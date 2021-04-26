using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TemtemTracker.Controllers;
using TemtemTracker.Data;

namespace TemtemTracker {
    public partial class StatisticsWindow : UserControl
    {
        private delegate void populateStatisticsDelegate(TrackingStatistics stats);

        private readonly DatabaseController dbcon;

        Tuple<DateTime, DateTime> focusedWeek;


        public StatisticsWindow()
        {
            InitializeComponent();

            focusedWeek = HelperMethods.GetCurrentWeek();

            dbcon = DatabaseController.Instance;
        }


        private void StatisticsWindow_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                RefreshStatistics();
            }
        }

        private void RefreshStatistics()
        {
            dbcon.GetEncounterStatistics(focusedWeek).ContinueWith(task =>
            {
                PopulateStatistics(task.Result);
            });
        }

        private void PopulateStatistics(TrackingStatistics stats)
        {
            if (this.InvokeRequired)
            {
                populateStatisticsDelegate d = new populateStatisticsDelegate(PopulateStatistics);
                this.Invoke(d, new object[] { stats });
            }
            else
            { 
                //Encounter chart
                chartWeeklyEncounters.Series.Clear();
                chartWeeklyEncounters.ResetAutoValues();
                Series totalEncounters = new Series
                {
                    ChartType = SeriesChartType.Column,
                    Name = "Temtem encountered",
                    IsValueShownAsLabel = true,
                    LabelBackColor = Color.White
                };
                for (int i = 0; i < 7; i++)
                {
                    totalEncounters.Points.AddXY(stats.dailyEncounters[i].date, stats.dailyEncounters[i].totalTemtemEncountered);
                }
                chartWeeklyEncounters.Series.Add(totalEncounters);

                //Playtime chart
                chartWeeklyPlaytime.Series.Clear();
                chartWeeklyPlaytime.ResetAutoValues();
                Series totalPlaytime = new Series
                {
                    ChartType = SeriesChartType.Column,
                    Name = "Playtime(minutes)",
                    IsValueShownAsLabel = true,
                    LabelBackColor = Color.White
                };
                for (int i = 0; i < 7; i++)
                {
                    totalPlaytime.Points.AddXY(stats.dailyPlaytime[i].date, stats.dailyPlaytime[i].totalPlaytimeMinutes);
                }
                chartWeeklyPlaytime.Series.Add(totalPlaytime);

            }
            
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshStatistics();
        }

        private void ButtonNextWeek_Click(object sender, EventArgs e)
        {
            focusedWeek = HelperMethods.GetNextWeek(focusedWeek);
            RefreshStatistics();
        }

        private void ButtonCurrentWeek_Click(object sender, EventArgs e)
        {
            focusedWeek = HelperMethods.GetCurrentWeek();
            RefreshStatistics();
        }

        private void ButtonPreviousWeek_Click(object sender, EventArgs e)
        {
            focusedWeek = HelperMethods.GetPriorWeek(focusedWeek);
            RefreshStatistics();
        }
    }
}
