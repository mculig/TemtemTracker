namespace TemtemTracker
{
    partial class TemtemTrackerUI
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
            this.trackerTable = new System.Windows.Forms.TableLayoutPanel();
            this.temtemTableTotalUI = new TemtemTracker.TemtemTableTotalUI();
            this.temtemTableRowHeaderUI = new TemtemTracker.TemtemTableRowHeaderUI();
            this.timeTrackerUI1 = new TemtemTracker.TimeTrackerUI();
            this.SuspendLayout();
            // 
            // trackerTable
            // 
            this.trackerTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackerTable.AutoScroll = true;
            this.trackerTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.trackerTable.ColumnCount = 1;
            this.trackerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.trackerTable.Location = new System.Drawing.Point(0, 29);
            this.trackerTable.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.trackerTable.Name = "trackerTable";
            this.trackerTable.RowCount = 1;
            this.trackerTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.trackerTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.trackerTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.trackerTable.Size = new System.Drawing.Size(698, 170);
            this.trackerTable.TabIndex = 0;
            // 
            // temtemTableTotalUI
            // 
            this.temtemTableTotalUI.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.temtemTableTotalUI.Location = new System.Drawing.Point(0, 201);
            this.temtemTableTotalUI.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.temtemTableTotalUI.Name = "temtemTableTotalUI";
            this.temtemTableTotalUI.Size = new System.Drawing.Size(698, 29);
            this.temtemTableTotalUI.TabIndex = 1;
            // 
            // temtemTableRowHeaderUI
            // 
            this.temtemTableRowHeaderUI.Dock = System.Windows.Forms.DockStyle.Top;
            this.temtemTableRowHeaderUI.Location = new System.Drawing.Point(0, 0);
            this.temtemTableRowHeaderUI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.temtemTableRowHeaderUI.Name = "temtemTableRowHeaderUI";
            this.temtemTableRowHeaderUI.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.temtemTableRowHeaderUI.Size = new System.Drawing.Size(698, 29);
            this.temtemTableRowHeaderUI.TabIndex = 0;
            // 
            // timeTrackerUI1
            // 
            this.timeTrackerUI1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.timeTrackerUI1.Location = new System.Drawing.Point(0, 230);
            this.timeTrackerUI1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.timeTrackerUI1.Name = "timeTrackerUI1";
            this.timeTrackerUI1.Size = new System.Drawing.Size(698, 37);
            this.timeTrackerUI1.TabIndex = 1;
            // 
            // TemtemTrackerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.temtemTableTotalUI);
            this.Controls.Add(this.temtemTableRowHeaderUI);
            this.Controls.Add(this.timeTrackerUI1);
            this.Controls.Add(this.trackerTable);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TemtemTrackerUI";
            this.Size = new System.Drawing.Size(698, 267);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel trackerTable;
        private TimeTrackerUI timeTrackerUI1;
        private TemtemTableRowHeaderUI temtemTableRowHeaderUI;
        private TemtemTableTotalUI temtemTableTotalUI;
    }
}

