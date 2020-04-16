using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemtemTracker;
using TemtemTracker.Controllers;
using TemtemTracker.Data;

namespace TemtemTracker
{
    public partial class TemtemTrackerUI : Form
    {
        private delegate void AddRowDelegate(TemtemTableRowUI row);
        private delegate void TimerPauseDelegate(object sender, bool TimerState);
        private delegate void StyleChangeDelegate(object sender, Style windowStyle);
        private delegate void OpacityChangeDelegate(object sender, double opacity);
        private SettingsController settingsController;
        private TemtemTableController tableController;
        private readonly AboutWindow aboutWindow;
        private Style style;

        public TemtemTrackerUI(SettingsController settingsController)
        {
            InitializeComponent();
            aboutWindow = new AboutWindow();
            this.Width = settingsController.GetUserSettings().mainWindowWidth;
            this.Height = settingsController.GetUserSettings().mainWindowHeight;
            this.Opacity = settingsController.GetUserSettings().mainWindowOpacity;
            settingsController.TimerPausedToggled += TogglePauseTimerUIIndication;
            this.settingsController = settingsController;
            settingsController.StyleChanged += SetWindowStyle;
            settingsController.MainWindowOpacityChanged += SetWindowOpacity;
            SetWindowStyle(null, settingsController.GetWindowStyle());
        }

        public void SetSettingsController(SettingsController settingsController)
        {
            this.settingsController = settingsController;
        }

        public void SetTableController(TemtemTableController tableController)
        {
            this.tableController = tableController;
        }

        public void AddRowToTable(TemtemTableRowUI row)
        {
            if (this.InvokeRequired)
            {
                AddRowDelegate d = new AddRowDelegate(AddRowToTable);
                this.Invoke(d, new object[] { row });
            }
            else
            {
                trackerTable.Controls.Add(row);
                RecolorTableRows();
            } 
        }

        public void RemoveRowFromTable(TemtemTableRowUI row)
        {
            trackerTable.Controls.Remove(row);
            RecolorTableRows();  
        }

        private void SetWindowOpacity(object sender, double opacity)
        {
            if (this.InvokeRequired)
            {
                OpacityChangeDelegate d = new OpacityChangeDelegate(SetWindowOpacity);
                this.Invoke(d, new object[] { sender, opacity });
            }
            else
            {
                this.Opacity = opacity;
            }         
        }

        private void RecolorTableRows()
        {
            int i = 1;
            foreach (TemtemTableRowUI r in trackerTable.Controls)
            {
                if (i % 2 == 0)
                {
                    r.SetLight(style);
                }
                else
                {
                    r.SetDark(style);
                }
                i++;
            }
        }

        public void RemoveAllTableRows()
        {
            trackerTable.Controls.Clear();
        }

        public void SetTotal(TemtemDataRow totalRow)
        {
            temtemTableTotalUI.SetTotal(totalRow);
        }

        public void UpdateTotal()
        {
            temtemTableTotalUI.UpdateRow();
        }

        public void UpdateTime(long timeMilis)
        {
            timeTrackerUI1.UpdateTime(timeMilis);
        }

        public void UpdateTemtemH(double temtemH)
        {
            timeTrackerUI1.UpdateTemtemH(temtemH);
        }

        public void SetMenuStripHotkeyStrings(string resetTableHotkey, string pauseTimerHotkey)
        {
            resetTableToolStripMenuItem.ShortcutKeyDisplayString = resetTableHotkey;
            pauseTimerToolStripMenuItem.ShortcutKeyDisplayString = pauseTimerHotkey;
        }

        public void TogglePauseTimerUIIndication(object sender, bool timerState)
        {
            if (this.InvokeRequired)
            {
                TimerPauseDelegate d = new TimerPauseDelegate(TogglePauseTimerUIIndication);
                this.Invoke(d, new object[] { sender, timerState });
            }
            else
            {
                if (timerState)
                {
                    pauseTimerToolStripMenuItem.Text = "Pause timer";
                }
                else
                {
                    pauseTimerToolStripMenuItem.Text = "Unpause timer";
                }
                timeTrackerUI1.SetPausedVisualIndication(timerState);
            }
            
        }

        private void SetWindowStyle(object sender, Style style)
        {
            if (this.InvokeRequired)
            {
                StyleChangeDelegate d = new StyleChangeDelegate(SetWindowStyle);
                this.Invoke(d, new object[] { sender, style });
            }
            else
            {
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
                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    foreach (ToolStripItem dropdownItem in item.DropDownItems)
                    {
                        dropdownItem.ForeColor = ColorTranslator.FromHtml(style.menuStripForeground);
                    }
                    item.ForeColor = ColorTranslator.FromHtml(style.menuStripForeground);
                }
                //Recolor the table rows
                RecolorTableRows();
                //Set the time tracker UI style
                timeTrackerUI1.SetStyle(style);
            }          
        }

        private void PropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsController.ShowSettingsWindow();
        }

        private void ResetTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableController.ResetTable();
        }

        private void PauseTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsController.ToggleTimerPaused();
        }

        private void TemtemTrackerUI_ResizeEnd(object sender, EventArgs e)
        {
            settingsController.SetMainWindowSize(this.Size);
        }

        private void LoadTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                Filter = "json files (*.json)|*.json",
                FilterIndex = 0,
                RestoreDirectory = true
            };
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                //Reset the table. This is necessary because loading adds elements to the UI
                //so we need to clear the UI first
                tableController.ResetTable();
                //Load the table from the provided file
                tableController.LoadTableFromFile(openFile.FileName);
            }
        }

        private void SaveTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "json files (*.json)|*.json",
                FilterIndex = 0,
                RestoreDirectory = true
            };
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                tableController.SaveTableAs(saveDialog.FileName);
            }
        }

        private void ExportCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog exportDialog = new SaveFileDialog
            {
                Filter = "csv files (*.csv)|*.csv",
                FilterIndex = 0,
                RestoreDirectory = true
            };
            if (exportDialog.ShowDialog() == DialogResult.OK)
            {
                tableController.ExportCSV(exportDialog.FileName);
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutWindow.Show();
        }

    }
}
