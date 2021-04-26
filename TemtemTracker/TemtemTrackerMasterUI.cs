using System;
using System.Drawing;
using System.Windows.Forms;
using TemtemTracker.Controllers;
using TemtemTracker.Data;

namespace TemtemTracker {
    public partial class TemtemTrackerMasterUI : Form {

        private delegate void OpacityChangeDelegate(object sender, double opacity);
        private delegate void TimerPauseDelegate(object sender, bool TimerState);
        private delegate void StyleChangeDelegate(object sender, Style windowStyle);

        private readonly AboutWindow aboutWindow;
        private readonly StatisticsWindow statisticsWindow;
        private readonly SettingsController settingsController;
        private readonly TemtemTrackerUI trackerUI;

        private Style style;

        public TemtemTrackerMasterUI(SettingsController settingsController, TemtemTrackerUI trackerUI) {
            InitializeComponent();
            aboutWindow = new AboutWindow();
            statisticsWindow = new StatisticsWindow();

            this.settingsController = settingsController;
            this.trackerUI = trackerUI;
            this.Opacity = settingsController.GetUserSettings().mainWindowOpacity;

            settingsController.MainWindowOpacityChanged += SetWindowOpacity;
            settingsController.TimerPausedToggled += TogglePauseTimerUIIndication;
            settingsController.StyleChanged += SetWindowStyle;

            CreateTrackerTab();
            CreateStatisticsTab();
        }

        private void CreateTrackerTab() {
            trackerUI.Dock = DockStyle.Fill;
            var tab = new TabPage();
            tab.Text = "Tracker";
            tab.Controls.Add(trackerUI);
            tabControl.TabPages.Add(tab);
        }

        private void CreateStatisticsTab() {
            statisticsWindow.Dock = DockStyle.Fill;
            var tab = new TabPage();
            tab.Text = "Statistics";
            tab.Controls.Add(statisticsWindow);
            tabControl.TabPages.Add(tab);
        }

        private void SetWindowOpacity(object sender, double opacity) {
            if(this.InvokeRequired) {
                OpacityChangeDelegate d = new OpacityChangeDelegate(SetWindowOpacity);
                this.Invoke(d, new object[] { sender, opacity });
            } else {
                this.Opacity = opacity;
            }
        }

        private void SetWindowStyle(object sender, Style style) {
            if(this.InvokeRequired) {
                StyleChangeDelegate d = new StyleChangeDelegate(SetWindowStyle);
                this.Invoke(d, new object[] { sender, style });
            } else {
                //Set the style
                this.style = style;
                //Set the foreground and background colors
                this.BackColor = ColorTranslator.FromHtml(style.trackerBackground);
                this.ForeColor = ColorTranslator.FromHtml(style.trackerForeground);
                //Create a custom color table for the menu and set the colors
                CustomMenuColorTable colorTable = new CustomMenuColorTable(style);
                menuStrip1.Renderer = new ToolStripProfessionalRenderer(colorTable);
                menuStrip1.BackColor = ColorTranslator.FromHtml(style.menuStripBackground);
                menuStrip1.ForeColor = ColorTranslator.FromHtml(style.menuStripForeground);
                //Set the colors of items in the menu strip
                foreach(ToolStripMenuItem item in menuStrip1.Items) {
                    foreach(ToolStripItem dropdownItem in item.DropDownItems) {
                        dropdownItem.ForeColor = ColorTranslator.FromHtml(style.menuStripForeground);
                    }
                    item.ForeColor = ColorTranslator.FromHtml(style.menuStripForeground);
                }
            }
        }

        public void SetMenuStripHotkeyStrings(string resetTableHotkey, string pauseTimerHotkey) {
            resetTableToolStripMenuItem.ShortcutKeyDisplayString = resetTableHotkey;
            pauseTimerToolStripMenuItem.ShortcutKeyDisplayString = pauseTimerHotkey;
        }

        public void TogglePauseTimerUIIndication(object sender, bool timerState) {
            if(this.InvokeRequired) {
                TimerPauseDelegate d = new TimerPauseDelegate(TogglePauseTimerUIIndication);
                this.Invoke(d, new object[] { sender, timerState });
            } else {
                if(timerState) {
                    pauseTimerToolStripMenuItem.Text = "Pause timer";
                } else {
                    pauseTimerToolStripMenuItem.Text = "Unpause timer";
                }

                trackerUI.TogglePauseTimerUIIndication(sender, timerState);
            }
        }

        private void PropertiesToolStripMenuItem_Click(object sender, EventArgs e) {
            settingsController.ShowSettingsWindow();
        }

        private void ResetTableToolStripMenuItem_Click(object sender, EventArgs e) {
            trackerUI.ResetTableToolStripMenuItem_Click(sender, e);
        }

        private void PauseTimerToolStripMenuItem_Click(object sender, EventArgs e) {
            trackerUI.PauseTimerToolStripMenuItem_Click(sender, e);
        }

        private void LoadTableToolStripMenuItem_Click(object sender, EventArgs e) {
            trackerUI.LoadTableToolStripMenuItem_Click(sender, e);
        }

        private void SaveTableToolStripMenuItem_Click(object sender, EventArgs e) {
            trackerUI.SaveTableToolStripMenuItem_Click(sender, e);
        }

        private void ExportCSVToolStripMenuItem_Click(object sender, EventArgs e) {
            trackerUI.ExportCSVToolStripMenuItem_Click(sender, e);
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e) {
            aboutWindow.Show();
        }
    }
}
