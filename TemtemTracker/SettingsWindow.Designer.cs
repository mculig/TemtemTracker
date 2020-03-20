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
            this.opacityTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.windowSettings.SuspendLayout();
            this.saiparkSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temtem2Multiplier)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temtem1Multiplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opacityTrackBar)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.windowSettings);
            this.tabControl1.Controls.Add(this.saiparkSettings);
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
            this.saiparkSettings.ResumeLayout(false);
            this.saiparkSettings.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temtem2Multiplier)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temtem1Multiplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opacityTrackBar)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
    }
}