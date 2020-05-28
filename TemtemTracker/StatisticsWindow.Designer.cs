namespace TemtemTracker
{
    partial class StatisticsWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsWindow));
            this.chartWeeklyEncounters = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartWeeklyPlaytime = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartSingleDoubleBattles = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonPreviousWeek = new System.Windows.Forms.Button();
            this.buttonCurrentWeek = new System.Windows.Forms.Button();
            this.buttonNextWeek = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chartWeeklyEncounters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartWeeklyPlaytime)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSingleDoubleBattles)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartWeeklyEncounters
            // 
            chartArea1.Name = "ChartArea1";
            this.chartWeeklyEncounters.ChartAreas.Add(chartArea1);
            this.tableLayoutPanel1.SetColumnSpan(this.chartWeeklyEncounters, 2);
            this.chartWeeklyEncounters.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chartWeeklyEncounters.Legends.Add(legend3);
            this.chartWeeklyEncounters.Location = new System.Drawing.Point(295, 3);
            this.chartWeeklyEncounters.Name = "chartWeeklyEncounters";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartWeeklyEncounters.Series.Add(series3);
            this.chartWeeklyEncounters.Size = new System.Drawing.Size(580, 275);
            this.chartWeeklyEncounters.TabIndex = 4;
            this.chartWeeklyEncounters.Text = "chartWeeklyEncounters";
            // 
            // chartWeeklyPlaytime
            // 
            chartArea2.Name = "ChartArea1";
            this.chartWeeklyPlaytime.ChartAreas.Add(chartArea2);
            this.tableLayoutPanel1.SetColumnSpan(this.chartWeeklyPlaytime, 3);
            this.chartWeeklyPlaytime.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartWeeklyPlaytime.Legends.Add(legend1);
            this.chartWeeklyPlaytime.Location = new System.Drawing.Point(3, 284);
            this.chartWeeklyPlaytime.Name = "chartWeeklyPlaytime";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartWeeklyPlaytime.Series.Add(series1);
            this.chartWeeklyPlaytime.Size = new System.Drawing.Size(872, 275);
            this.chartWeeklyPlaytime.TabIndex = 5;
            this.chartWeeklyPlaytime.Text = "chartWeeklyEncounters";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.chartWeeklyEncounters, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartWeeklyPlaytime, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chartSingleDoubleBattles, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(878, 562);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // chartSingleDoubleBattles
            // 
            chartArea3.Name = "ChartArea1";
            this.chartSingleDoubleBattles.ChartAreas.Add(chartArea3);
            this.chartSingleDoubleBattles.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartSingleDoubleBattles.Legends.Add(legend2);
            this.chartSingleDoubleBattles.Location = new System.Drawing.Point(3, 3);
            this.chartSingleDoubleBattles.Name = "chartSingleDoubleBattles";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartSingleDoubleBattles.Series.Add(series2);
            this.chartSingleDoubleBattles.Size = new System.Drawing.Size(286, 275);
            this.chartSingleDoubleBattles.TabIndex = 6;
            this.chartSingleDoubleBattles.Text = "chart1";
            // 
            // buttonPreviousWeek
            // 
            this.buttonPreviousWeek.Location = new System.Drawing.Point(3, 3);
            this.buttonPreviousWeek.Name = "buttonPreviousWeek";
            this.buttonPreviousWeek.Size = new System.Drawing.Size(81, 59);
            this.buttonPreviousWeek.TabIndex = 7;
            this.buttonPreviousWeek.Text = "Previous week";
            this.buttonPreviousWeek.UseVisualStyleBackColor = true;
            this.buttonPreviousWeek.Click += new System.EventHandler(this.ButtonPreviousWeek_Click);
            // 
            // buttonCurrentWeek
            // 
            this.buttonCurrentWeek.Location = new System.Drawing.Point(90, 3);
            this.buttonCurrentWeek.Name = "buttonCurrentWeek";
            this.buttonCurrentWeek.Size = new System.Drawing.Size(81, 59);
            this.buttonCurrentWeek.TabIndex = 8;
            this.buttonCurrentWeek.Text = "Current Week";
            this.buttonCurrentWeek.UseVisualStyleBackColor = true;
            this.buttonCurrentWeek.Click += new System.EventHandler(this.ButtonCurrentWeek_Click);
            // 
            // buttonNextWeek
            // 
            this.buttonNextWeek.Location = new System.Drawing.Point(177, 3);
            this.buttonNextWeek.Name = "buttonNextWeek";
            this.buttonNextWeek.Size = new System.Drawing.Size(81, 59);
            this.buttonNextWeek.TabIndex = 9;
            this.buttonNextWeek.Text = "Next Week";
            this.buttonNextWeek.UseVisualStyleBackColor = true;
            this.buttonNextWeek.Click += new System.EventHandler(this.ButtonNextWeek_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(264, 3);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(81, 59);
            this.buttonRefresh.TabIndex = 10;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel1.Controls.Add(this.buttonPreviousWeek);
            this.panel1.Controls.Add(this.buttonRefresh);
            this.panel1.Controls.Add(this.buttonCurrentWeek);
            this.panel1.Controls.Add(this.buttonNextWeek);
            this.panel1.Location = new System.Drawing.Point(266, 568);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 67);
            this.panel1.TabIndex = 11;
            // 
            // StatisticsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 644);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StatisticsWindow";
            this.Text = "Statistics";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StatisticsWindow_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.StatisticsWindow_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.chartWeeklyEncounters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartWeeklyPlaytime)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSingleDoubleBattles)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chartWeeklyEncounters;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartWeeklyPlaytime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonPreviousWeek;
        private System.Windows.Forms.Button buttonCurrentWeek;
        private System.Windows.Forms.Button buttonNextWeek;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSingleDoubleBattles;
    }
}