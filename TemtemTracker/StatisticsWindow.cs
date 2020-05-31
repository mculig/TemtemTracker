using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TemtemTracker.Controllers;
using TemtemTracker.Data;

namespace TemtemTracker
{
    public partial class StatisticsWindow : Form
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
                    Name = "Temtem encountered"
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
                    Name = "Playtime(minutes)"
                };
                for (int i = 0; i < 7; i++)
                {
                    totalPlaytime.Points.AddXY(stats.dailyPlaytime[i].date, stats.dailyPlaytime[i].totalPlaytimeMinutes);
                }
                chartWeeklyPlaytime.Series.Add(totalPlaytime);

                //Encounter averages chart
                chartSingleDoubleBattles.Series.Clear();
                chartSingleDoubleBattles.ResetAutoValues();
                Series doubleSingleBattles = new Series
                {
                    ChartType = SeriesChartType.Pie,
                    Name = "Double/Single battles"
                };
                doubleSingleBattles.Points.AddXY("Double battles", stats.doubleBattlesTotal);
                doubleSingleBattles.Points.AddXY("Single battles", stats.singleBattlesTotal);
                chartSingleDoubleBattles.Series.Add(doubleSingleBattles);
            }
            
        }

        private void StatisticsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
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
