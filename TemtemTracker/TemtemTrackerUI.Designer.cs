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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.temtemTableTotalUI = new TemtemTracker.TemtemTableTotalUI();
            this.temtemTableRowHeaderUI = new TemtemTracker.TemtemTableRowHeaderUI();
            this.timeTrackerUI1 = new TemtemTracker.TimeTrackerUI();
            this.exportCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
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
            this.trackerTable.Location = new System.Drawing.Point(0, 77);
            this.trackerTable.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.trackerTable.Name = "trackerTable";
            this.trackerTable.RowCount = 1;
            this.trackerTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.trackerTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.trackerTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.trackerTable.Size = new System.Drawing.Size(1047, 230);
            this.trackerTable.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetTableToolStripMenuItem,
            this.pauseTimerToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveTableToolStripMenuItem,
            this.loadTableToolStripMenuItem,
            this.exportCSVToolStripMenuItem,
            this.toolStripSeparator2,
            this.propertiesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // resetTableToolStripMenuItem
            // 
            this.resetTableToolStripMenuItem.Name = "resetTableToolStripMenuItem";
            this.resetTableToolStripMenuItem.ShortcutKeyDisplayString = "F6";
            this.resetTableToolStripMenuItem.Size = new System.Drawing.Size(221, 30);
            this.resetTableToolStripMenuItem.Text = "Reset Table";
            this.resetTableToolStripMenuItem.Click += new System.EventHandler(this.resetTableToolStripMenuItem_Click);
            // 
            // pauseTimerToolStripMenuItem
            // 
            this.pauseTimerToolStripMenuItem.Name = "pauseTimerToolStripMenuItem";
            this.pauseTimerToolStripMenuItem.ShortcutKeyDisplayString = "F8";
            this.pauseTimerToolStripMenuItem.Size = new System.Drawing.Size(221, 30);
            this.pauseTimerToolStripMenuItem.Text = "Pause Timer";
            this.pauseTimerToolStripMenuItem.Click += new System.EventHandler(this.pauseTimerToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(218, 6);
            // 
            // saveTableToolStripMenuItem
            // 
            this.saveTableToolStripMenuItem.Name = "saveTableToolStripMenuItem";
            this.saveTableToolStripMenuItem.Size = new System.Drawing.Size(221, 30);
            this.saveTableToolStripMenuItem.Text = "Save As";
            this.saveTableToolStripMenuItem.Click += new System.EventHandler(this.saveTableToolStripMenuItem_Click);
            // 
            // loadTableToolStripMenuItem
            // 
            this.loadTableToolStripMenuItem.Name = "loadTableToolStripMenuItem";
            this.loadTableToolStripMenuItem.Size = new System.Drawing.Size(221, 30);
            this.loadTableToolStripMenuItem.Text = "Load";
            this.loadTableToolStripMenuItem.Click += new System.EventHandler(this.loadTableToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(218, 6);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(221, 30);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1047, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip";
            // 
            // temtemTableTotalUI
            // 
            this.temtemTableTotalUI.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.temtemTableTotalUI.Location = new System.Drawing.Point(0, 310);
            this.temtemTableTotalUI.Name = "temtemTableTotalUI";
            this.temtemTableTotalUI.Size = new System.Drawing.Size(1047, 44);
            this.temtemTableTotalUI.TabIndex = 1;
            // 
            // temtemTableRowHeaderUI
            // 
            this.temtemTableRowHeaderUI.Dock = System.Windows.Forms.DockStyle.Top;
            this.temtemTableRowHeaderUI.Location = new System.Drawing.Point(0, 33);
            this.temtemTableRowHeaderUI.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.temtemTableRowHeaderUI.Name = "temtemTableRowHeaderUI";
            this.temtemTableRowHeaderUI.Size = new System.Drawing.Size(1047, 44);
            this.temtemTableRowHeaderUI.TabIndex = 0;
            // 
            // timeTrackerUI1
            // 
            this.timeTrackerUI1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.timeTrackerUI1.Location = new System.Drawing.Point(0, 354);
            this.timeTrackerUI1.Name = "timeTrackerUI1";
            this.timeTrackerUI1.Size = new System.Drawing.Size(1047, 57);
            this.timeTrackerUI1.TabIndex = 1;
            // 
            // exportCSVToolStripMenuItem
            // 
            this.exportCSVToolStripMenuItem.Name = "exportCSVToolStripMenuItem";
            this.exportCSVToolStripMenuItem.Size = new System.Drawing.Size(221, 30);
            this.exportCSVToolStripMenuItem.Text = "Export CSV";
            this.exportCSVToolStripMenuItem.Click += new System.EventHandler(this.exportCSVToolStripMenuItem_Click);
            // 
            // TemtemTrackerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1047, 411);
            this.Controls.Add(this.temtemTableTotalUI);
            this.Controls.Add(this.temtemTableRowHeaderUI);
            this.Controls.Add(this.timeTrackerUI1);
            this.Controls.Add(this.trackerTable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "TemtemTrackerUI";
            this.Text = "TemtemTracker V3";
            this.TopMost = true;
            this.ResizeEnd += new System.EventHandler(this.TemtemTrackerUI_ResizeEnd);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel trackerTable;
        private TimeTrackerUI timeTrackerUI1;
        private TemtemTableRowHeaderUI temtemTableRowHeaderUI;
        private TemtemTableTotalUI temtemTableTotalUI;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem resetTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseTimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exportCSVToolStripMenuItem;
    }
}

