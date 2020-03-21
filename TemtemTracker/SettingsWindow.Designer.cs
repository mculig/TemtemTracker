namespace TemtemTracker
{
    partial class SettingsWindow
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.windowSettings = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.opacityTrackBar = new System.Windows.Forms.TrackBar();
            this.darkModeCheckbox = new System.Windows.Forms.CheckBox();
            this.saiparkSettings = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.temtem2Multiplier = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.temtem2NameSelect = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.temtem1Multiplier = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.temtem1NameSelect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxSaiparkMode = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelResetTableHotkey = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonRemapResetTableHotkey = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonRemapPauseTimerHotkey = new System.Windows.Forms.Button();
            this.labelPauseTimerHotkey = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.windowSettings.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacityTrackBar)).BeginInit();
            this.saiparkSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temtem2Multiplier)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temtem1Multiplier)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.windowSettings);
            this.tabControl1.Controls.Add(this.saiparkSettings);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(342, 435);
            this.tabControl1.TabIndex = 0;
            // 
            // windowSettings
            // 
            this.windowSettings.Controls.Add(this.groupBox3);
            this.windowSettings.Controls.Add(this.darkModeCheckbox);
            this.windowSettings.Location = new System.Drawing.Point(4, 29);
            this.windowSettings.Name = "windowSettings";
            this.windowSettings.Padding = new System.Windows.Forms.Padding(3);
            this.windowSettings.Size = new System.Drawing.Size(334, 402);
            this.windowSettings.TabIndex = 2;
            this.windowSettings.Text = "Window";
            this.windowSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.opacityTrackBar);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(320, 100);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Opacity";
            // 
            // opacityTrackBar
            // 
            this.opacityTrackBar.Location = new System.Drawing.Point(6, 25);
            this.opacityTrackBar.Maximum = 100;
            this.opacityTrackBar.Minimum = 20;
            this.opacityTrackBar.Name = "opacityTrackBar";
            this.opacityTrackBar.Size = new System.Drawing.Size(308, 69);
            this.opacityTrackBar.TabIndex = 4;
            this.opacityTrackBar.Value = 100;
            this.opacityTrackBar.Scroll += new System.EventHandler(this.opacityTrackBar_Scroll);
            // 
            // darkModeCheckbox
            // 
            this.darkModeCheckbox.AutoSize = true;
            this.darkModeCheckbox.Location = new System.Drawing.Point(6, 112);
            this.darkModeCheckbox.Name = "darkModeCheckbox";
            this.darkModeCheckbox.Size = new System.Drawing.Size(113, 24);
            this.darkModeCheckbox.TabIndex = 3;
            this.darkModeCheckbox.Text = "Dark Mode";
            this.darkModeCheckbox.UseVisualStyleBackColor = true;
            this.darkModeCheckbox.CheckedChanged += new System.EventHandler(this.darkModeCheckbox_CheckedChanged);
            // 
            // saiparkSettings
            // 
            this.saiparkSettings.Controls.Add(this.groupBox2);
            this.saiparkSettings.Controls.Add(this.groupBox1);
            this.saiparkSettings.Controls.Add(this.checkBoxSaiparkMode);
            this.saiparkSettings.Location = new System.Drawing.Point(4, 29);
            this.saiparkSettings.Name = "saiparkSettings";
            this.saiparkSettings.Padding = new System.Windows.Forms.Padding(3);
            this.saiparkSettings.Size = new System.Drawing.Size(334, 402);
            this.saiparkSettings.TabIndex = 3;
            this.saiparkSettings.Text = "Saipark";
            this.saiparkSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.temtem2Multiplier);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.temtem2NameSelect);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(8, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(318, 94);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Temtem 2";
            // 
            // temtem2Multiplier
            // 
            this.temtem2Multiplier.DecimalPlaces = 1;
            this.temtem2Multiplier.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.temtem2Multiplier.Location = new System.Drawing.Point(87, 59);
            this.temtem2Multiplier.Name = "temtem2Multiplier";
            this.temtem2Multiplier.Size = new System.Drawing.Size(105, 26);
            this.temtem2Multiplier.TabIndex = 5;
            this.temtem2Multiplier.ValueChanged += new System.EventHandler(this.temtem2Multiplier_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Multiplier:";
            // 
            // temtem2NameSelect
            // 
            this.temtem2NameSelect.FormattingEnabled = true;
            this.temtem2NameSelect.Location = new System.Drawing.Point(71, 25);
            this.temtem2NameSelect.Name = "temtem2NameSelect";
            this.temtem2NameSelect.Size = new System.Drawing.Size(121, 28);
            this.temtem2NameSelect.TabIndex = 3;
            this.temtem2NameSelect.SelectedIndexChanged += new System.EventHandler(this.temtem2NameSelect_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Name: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.temtem1Multiplier);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.temtem1NameSelect);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 94);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Temtem 1";
            // 
            // temtem1Multiplier
            // 
            this.temtem1Multiplier.DecimalPlaces = 1;
            this.temtem1Multiplier.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.temtem1Multiplier.Location = new System.Drawing.Point(87, 59);
            this.temtem1Multiplier.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.temtem1Multiplier.Name = "temtem1Multiplier";
            this.temtem1Multiplier.Size = new System.Drawing.Size(105, 26);
            this.temtem1Multiplier.TabIndex = 5;
            this.temtem1Multiplier.ValueChanged += new System.EventHandler(this.temtem1Multiplier_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Multiplier:";
            // 
            // temtem1NameSelect
            // 
            this.temtem1NameSelect.FormattingEnabled = true;
            this.temtem1NameSelect.Location = new System.Drawing.Point(71, 25);
            this.temtem1NameSelect.Name = "temtem1NameSelect";
            this.temtem1NameSelect.Size = new System.Drawing.Size(121, 28);
            this.temtem1NameSelect.TabIndex = 3;
            this.temtem1NameSelect.SelectedIndexChanged += new System.EventHandler(this.temtem1NameSelect_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name: ";
            // 
            // checkBoxSaiparkMode
            // 
            this.checkBoxSaiparkMode.AutoSize = true;
            this.checkBoxSaiparkMode.Location = new System.Drawing.Point(8, 6);
            this.checkBoxSaiparkMode.Name = "checkBoxSaiparkMode";
            this.checkBoxSaiparkMode.Size = new System.Drawing.Size(187, 24);
            this.checkBoxSaiparkMode.TabIndex = 0;
            this.checkBoxSaiparkMode.Text = "Enable Saipark Mode";
            this.checkBoxSaiparkMode.UseVisualStyleBackColor = true;
            this.checkBoxSaiparkMode.CheckedChanged += new System.EventHandler(this.checkBoxSaiparkMode_CheckedChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(334, 402);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "Hotkeys";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelResetTableHotkey
            // 
            this.labelResetTableHotkey.AutoSize = true;
            this.labelResetTableHotkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResetTableHotkey.Location = new System.Drawing.Point(6, 33);
            this.labelResetTableHotkey.Name = "labelResetTableHotkey";
            this.labelResetTableHotkey.Size = new System.Drawing.Size(65, 20);
            this.labelResetTableHotkey.TabIndex = 0;
            this.labelResetTableHotkey.Text = "Hotkey";
            this.labelResetTableHotkey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonRemapResetTableHotkey);
            this.groupBox4.Controls.Add(this.labelResetTableHotkey);
            this.groupBox4.Location = new System.Drawing.Point(8, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(318, 86);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Reset Table Hotkey";
            // 
            // buttonRemapResetTableHotkey
            // 
            this.buttonRemapResetTableHotkey.Location = new System.Drawing.Point(71, 25);
            this.buttonRemapResetTableHotkey.Name = "buttonRemapResetTableHotkey";
            this.buttonRemapResetTableHotkey.Size = new System.Drawing.Size(103, 36);
            this.buttonRemapResetTableHotkey.TabIndex = 1;
            this.buttonRemapResetTableHotkey.Text = "Remap";
            this.buttonRemapResetTableHotkey.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonRemapPauseTimerHotkey);
            this.groupBox5.Controls.Add(this.labelPauseTimerHotkey);
            this.groupBox5.Location = new System.Drawing.Point(8, 98);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(318, 86);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Pause Timer Hotkey";
            // 
            // buttonRemapPauseTimerHotkey
            // 
            this.buttonRemapPauseTimerHotkey.Location = new System.Drawing.Point(71, 25);
            this.buttonRemapPauseTimerHotkey.Name = "buttonRemapPauseTimerHotkey";
            this.buttonRemapPauseTimerHotkey.Size = new System.Drawing.Size(103, 36);
            this.buttonRemapPauseTimerHotkey.TabIndex = 1;
            this.buttonRemapPauseTimerHotkey.Text = "Remap";
            this.buttonRemapPauseTimerHotkey.UseVisualStyleBackColor = true;
            // 
            // labelPauseTimerHotkey
            // 
            this.labelPauseTimerHotkey.AutoSize = true;
            this.labelPauseTimerHotkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPauseTimerHotkey.Location = new System.Drawing.Point(6, 33);
            this.labelPauseTimerHotkey.Name = "labelPauseTimerHotkey";
            this.labelPauseTimerHotkey.Size = new System.Drawing.Size(65, 20);
            this.labelPauseTimerHotkey.TabIndex = 0;
            this.labelPauseTimerHotkey.Text = "Hotkey";
            this.labelPauseTimerHotkey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 435);
            this.Controls.Add(this.tabControl1);
            this.Name = "SettingsWindow";
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsWindow_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.windowSettings.ResumeLayout(false);
            this.windowSettings.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacityTrackBar)).EndInit();
            this.saiparkSettings.ResumeLayout(false);
            this.saiparkSettings.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temtem2Multiplier)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temtem1Multiplier)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage windowSettings;
        private System.Windows.Forms.TabPage saiparkSettings;
        private System.Windows.Forms.CheckBox darkModeCheckbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown temtem1Multiplier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox temtem1NameSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxSaiparkMode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown temtem2Multiplier;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox temtem2NameSelect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TrackBar opacityTrackBar;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelResetTableHotkey;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonRemapPauseTimerHotkey;
        private System.Windows.Forms.Label labelPauseTimerHotkey;
        private System.Windows.Forms.Button buttonRemapResetTableHotkey;
    }
}