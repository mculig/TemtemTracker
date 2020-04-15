namespace TemtemTracker
{
    partial class IndividualTrackerWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndividualTrackerWindow));
            this.labelTemtemName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelEncounteredPercent = new System.Windows.Forms.Label();
            this.labelEncounters = new System.Windows.Forms.Label();
            this.labelChanceLuma = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTimer = new System.Windows.Forms.Label();
            this.labelTemtemPerHour = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTemtemName
            // 
            this.labelTemtemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTemtemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemtemName.Location = new System.Drawing.Point(37, 9);
            this.labelTemtemName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTemtemName.Name = "labelTemtemName";
            this.labelTemtemName.Size = new System.Drawing.Size(329, 55);
            this.labelTemtemName.TabIndex = 0;
            this.labelTemtemName.Text = "TemtemName";
            this.labelTemtemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.labelEncounteredPercent, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelEncounters, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelChanceLuma, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 75);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(378, 65);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // labelEncounteredPercent
            // 
            this.labelEncounteredPercent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEncounteredPercent.AutoSize = true;
            this.labelEncounteredPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEncounteredPercent.Location = new System.Drawing.Point(262, 18);
            this.labelEncounteredPercent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEncounteredPercent.Name = "labelEncounteredPercent";
            this.labelEncounteredPercent.Size = new System.Drawing.Size(106, 29);
            this.labelEncounteredPercent.TabIndex = 2;
            this.labelEncounteredPercent.Text = "100.00%";
            this.labelEncounteredPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelEncounters
            // 
            this.labelEncounters.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEncounters.AutoSize = true;
            this.labelEncounters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEncounters.Location = new System.Drawing.Point(24, 18);
            this.labelEncounters.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEncounters.Name = "labelEncounters";
            this.labelEncounters.Size = new System.Drawing.Size(78, 29);
            this.labelEncounters.TabIndex = 0;
            this.labelEncounters.Text = "20000";
            this.labelEncounters.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelChanceLuma
            // 
            this.labelChanceLuma.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelChanceLuma.AutoSize = true;
            this.labelChanceLuma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChanceLuma.Location = new System.Drawing.Point(136, 18);
            this.labelChanceLuma.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelChanceLuma.Name = "labelChanceLuma";
            this.labelChanceLuma.Size = new System.Drawing.Size(106, 29);
            this.labelChanceLuma.TabIndex = 1;
            this.labelChanceLuma.Text = "100.00%";
            this.labelChanceLuma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.labelTimer, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelTemtemPerHour, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(18, 149);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(378, 57);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // labelTimer
            // 
            this.labelTimer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTimer.AutoSize = true;
            this.labelTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimer.Location = new System.Drawing.Point(43, 14);
            this.labelTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(103, 29);
            this.labelTimer.TabIndex = 1;
            this.labelTimer.Text = "00:00:00";
            this.labelTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTemtemPerHour
            // 
            this.labelTemtemPerHour.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTemtemPerHour.AutoSize = true;
            this.labelTemtemPerHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemtemPerHour.Location = new System.Drawing.Point(241, 14);
            this.labelTemtemPerHour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTemtemPerHour.Name = "labelTemtemPerHour";
            this.labelTemtemPerHour.Size = new System.Drawing.Size(84, 29);
            this.labelTemtemPerHour.TabIndex = 2;
            this.labelTemtemPerHour.Text = "250.00";
            this.labelTemtemPerHour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IndividualTrackerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 225);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.labelTemtemName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "IndividualTrackerWindow";
            this.Text = "TemtemTracker";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IndividualTrackerWindow_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTemtemName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelEncounteredPercent;
        private System.Windows.Forms.Label labelEncounters;
        private System.Windows.Forms.Label labelChanceLuma;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelTemtemPerHour;
        private System.Windows.Forms.Label labelTimer;
    }
}