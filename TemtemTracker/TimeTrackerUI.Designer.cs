namespace TemtemTracker
{
    partial class TimeTrackerUI
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dayTimeLabel = new System.Windows.Forms.Label();
            this.sessionTimeLabel = new System.Windows.Forms.Label();
            this.labelTimeTodayTitle = new System.Windows.Forms.Label();
            this.temtemHLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.labelTemtemHTitle = new System.Windows.Forms.Label();
            this.labelTimeTitle = new System.Windows.Forms.Label();
            this.labelCurrentSessionTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.dayTimeLabel, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.sessionTimeLabel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelTimeTodayTitle, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.temtemHLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.timeLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelTemtemHTitle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelTimeTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelCurrentSessionTitle, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(434, 77);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dayTimeLabel
            // 
            this.dayTimeLabel.AutoSize = true;
            this.dayTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dayTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dayTimeLabel.Location = new System.Drawing.Point(327, 38);
            this.dayTimeLabel.Name = "dayTimeLabel";
            this.dayTimeLabel.Size = new System.Drawing.Size(104, 39);
            this.dayTimeLabel.TabIndex = 7;
            this.dayTimeLabel.Text = "00:00:00";
            this.dayTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sessionTimeLabel
            // 
            this.sessionTimeLabel.AutoSize = true;
            this.sessionTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sessionTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sessionTimeLabel.Location = new System.Drawing.Point(219, 38);
            this.sessionTimeLabel.Name = "sessionTimeLabel";
            this.sessionTimeLabel.Size = new System.Drawing.Size(102, 39);
            this.sessionTimeLabel.TabIndex = 6;
            this.sessionTimeLabel.Text = "00:00:00";
            this.sessionTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTimeTodayTitle
            // 
            this.labelTimeTodayTitle.AutoSize = true;
            this.labelTimeTodayTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTimeTodayTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeTodayTitle.Location = new System.Drawing.Point(327, 0);
            this.labelTimeTodayTitle.Name = "labelTimeTodayTitle";
            this.labelTimeTodayTitle.Size = new System.Drawing.Size(104, 38);
            this.labelTimeTodayTitle.TabIndex = 5;
            this.labelTimeTodayTitle.Text = "Today";
            this.labelTimeTodayTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // temtemHLabel
            // 
            this.temtemHLabel.AutoSize = true;
            this.temtemHLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.temtemHLabel.Location = new System.Drawing.Point(111, 38);
            this.temtemHLabel.Name = "temtemHLabel";
            this.temtemHLabel.Size = new System.Drawing.Size(102, 39);
            this.temtemHLabel.TabIndex = 3;
            this.temtemHLabel.Text = "0.00";
            this.temtemHLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeLabel.Location = new System.Drawing.Point(3, 38);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(102, 39);
            this.timeLabel.TabIndex = 2;
            this.timeLabel.Text = "00:00:00";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTemtemHTitle
            // 
            this.labelTemtemHTitle.AutoSize = true;
            this.labelTemtemHTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTemtemHTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemtemHTitle.Location = new System.Drawing.Point(111, 0);
            this.labelTemtemHTitle.Name = "labelTemtemHTitle";
            this.labelTemtemHTitle.Size = new System.Drawing.Size(102, 38);
            this.labelTemtemHTitle.TabIndex = 1;
            this.labelTemtemHTitle.Text = "Temtem/h";
            this.labelTemtemHTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTimeTitle
            // 
            this.labelTimeTitle.AutoSize = true;
            this.labelTimeTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTimeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTimeTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelTimeTitle.Name = "labelTimeTitle";
            this.labelTimeTitle.Size = new System.Drawing.Size(108, 38);
            this.labelTimeTitle.TabIndex = 0;
            this.labelTimeTitle.Text = "Total Time";
            this.labelTimeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCurrentSessionTitle
            // 
            this.labelCurrentSessionTitle.AutoSize = true;
            this.labelCurrentSessionTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCurrentSessionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentSessionTitle.Location = new System.Drawing.Point(219, 0);
            this.labelCurrentSessionTitle.Name = "labelCurrentSessionTitle";
            this.labelCurrentSessionTitle.Size = new System.Drawing.Size(102, 38);
            this.labelCurrentSessionTitle.TabIndex = 4;
            this.labelCurrentSessionTitle.Text = "Session";
            this.labelCurrentSessionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimeTrackerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TimeTrackerUI";
            this.Size = new System.Drawing.Size(434, 77);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label temtemHLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label labelTemtemHTitle;
        private System.Windows.Forms.Label labelTimeTitle;
        private System.Windows.Forms.Label labelCurrentSessionTitle;
        private System.Windows.Forms.Label labelTimeTodayTitle;
        private System.Windows.Forms.Label dayTimeLabel;
        private System.Windows.Forms.Label sessionTimeLabel;
    }
}
