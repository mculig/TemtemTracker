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
            this.temtemHLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.labelTemtemHTitle = new System.Windows.Forms.Label();
            this.labelTimeTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.temtemHLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.timeLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelTemtemHTitle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelTimeTitle, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(236, 77);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // temtemHLabel
            // 
            this.temtemHLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.temtemHLabel.AutoSize = true;
            this.temtemHLabel.Location = new System.Drawing.Point(157, 47);
            this.temtemHLabel.Name = "temtemHLabel";
            this.temtemHLabel.Size = new System.Drawing.Size(40, 20);
            this.temtemHLabel.TabIndex = 3;
            this.temtemHLabel.Text = "0.00";
            // 
            // timeLabel
            // 
            this.timeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(23, 47);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(71, 20);
            this.timeLabel.TabIndex = 2;
            this.timeLabel.Text = "00:00:00";
            // 
            // labelTemtemHTitle
            // 
            this.labelTemtemHTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTemtemHTitle.AutoSize = true;
            this.labelTemtemHTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemtemHTitle.Location = new System.Drawing.Point(133, 9);
            this.labelTemtemHTitle.Name = "labelTemtemHTitle";
            this.labelTemtemHTitle.Size = new System.Drawing.Size(88, 20);
            this.labelTemtemHTitle.TabIndex = 1;
            this.labelTemtemHTitle.Text = "Temtem/h";
            // 
            // labelTimeTitle
            // 
            this.labelTimeTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTimeTitle.AutoSize = true;
            this.labelTimeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeTitle.Location = new System.Drawing.Point(35, 9);
            this.labelTimeTitle.Name = "labelTimeTitle";
            this.labelTimeTitle.Size = new System.Drawing.Size(47, 20);
            this.labelTimeTitle.TabIndex = 0;
            this.labelTimeTitle.Text = "Time";
            // 
            // TimeTrackerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TimeTrackerUI";
            this.Size = new System.Drawing.Size(236, 77);
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
    }
}
