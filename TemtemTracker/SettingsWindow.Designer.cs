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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.settingsTabControl = new System.Windows.Forms.TabControl();
            this.windowTabPage = new System.Windows.Forms.TabPage();
            this.inactivitySettings = new System.Windows.Forms.GroupBox();
            this.labelInactivityPauseAfter = new System.Windows.Forms.Label();
            this.inactivityTreshold = new System.Windows.Forms.NumericUpDown();
            this.checkboxInactivity = new System.Windows.Forms.CheckBox();
            this.labelAutosaveInterval = new System.Windows.Forms.Label();
            this.autosaveInterval = new System.Windows.Forms.NumericUpDown();
            this.checkBoxDisableWhileTimer = new System.Windows.Forms.CheckBox();
            this.labelWindowStyle = new System.Windows.Forms.Label();
            this.comboBoxStyleSelect = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.opacityTrackBar = new System.Windows.Forms.TrackBar();
            this.lumaChanceTabPage = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radioButtonLuma75Percent = new System.Windows.Forms.RadioButton();
            this.radioButtonLuma9999Percent = new System.Windows.Forms.RadioButton();
            this.radioButtonLuma50Percent = new System.Windows.Forms.RadioButton();
            this.saiparkTabPage = new System.Windows.Forms.TabPage();
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
            this.hotkeysTabPage = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonRemapPauseTimerHotkey = new System.Windows.Forms.Button();
            this.labelPauseTimerHotkey = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonRemapResetTableHotkey = new System.Windows.Forms.Button();
            this.labelResetTableHotkey = new System.Windows.Forms.Label();
            this.settingsTabControl.SuspendLayout();
            this.windowTabPage.SuspendLayout();
            this.inactivitySettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inactivityTreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autosaveInterval)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacityTrackBar)).BeginInit();
            this.lumaChanceTabPage.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.saiparkTabPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temtem2Multiplier)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temtem1Multiplier)).BeginInit();
            this.hotkeysTabPage.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsTabControl
            // 
            this.settingsTabControl.Controls.Add(this.windowTabPage);
            this.settingsTabControl.Controls.Add(this.lumaChanceTabPage);
            this.settingsTabControl.Controls.Add(this.saiparkTabPage);
            this.settingsTabControl.Controls.Add(this.hotkeysTabPage);
            this.settingsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsTabControl.Location = new System.Drawing.Point(0, 0);
            this.settingsTabControl.Name = "settingsTabControl";
            this.settingsTabControl.SelectedIndex = 0;
            this.settingsTabControl.Size = new System.Drawing.Size(342, 435);
            this.settingsTabControl.TabIndex = 0;
            // 
            // windowTabPage
            // 
            this.windowTabPage.Controls.Add(this.inactivitySettings);
            this.windowTabPage.Controls.Add(this.labelAutosaveInterval);
            this.windowTabPage.Controls.Add(this.autosaveInterval);
            this.windowTabPage.Controls.Add(this.checkBoxDisableWhileTimer);
            this.windowTabPage.Controls.Add(this.labelWindowStyle);
            this.windowTabPage.Controls.Add(this.comboBoxStyleSelect);
            this.windowTabPage.Controls.Add(this.groupBox3);
            this.windowTabPage.Location = new System.Drawing.Point(4, 29);
            this.windowTabPage.Name = "windowTabPage";
            this.windowTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.windowTabPage.Size = new System.Drawing.Size(334, 402);
            this.windowTabPage.TabIndex = 2;
            this.windowTabPage.Text = "General";
            this.windowTabPage.UseVisualStyleBackColor = true;
            // 
            // inactivitySettings
            // 
            this.inactivitySettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inactivitySettings.Controls.Add(this.labelInactivityPauseAfter);
            this.inactivitySettings.Controls.Add(this.inactivityTreshold);
            this.inactivitySettings.Controls.Add(this.checkboxInactivity);
            this.inactivitySettings.Location = new System.Drawing.Point(3, 218);
            this.inactivitySettings.Name = "inactivitySettings";
            this.inactivitySettings.Size = new System.Drawing.Size(323, 94);
            this.inactivitySettings.TabIndex = 11;
            this.inactivitySettings.TabStop = false;
            this.inactivitySettings.Text = "Inactivity";
            // 
            // labelInactivityPauseAfter
            // 
            this.labelInactivityPauseAfter.AutoSize = true;
            this.labelInactivityPauseAfter.Location = new System.Drawing.Point(6, 57);
            this.labelInactivityPauseAfter.Name = "labelInactivityPauseAfter";
            this.labelInactivityPauseAfter.Size = new System.Drawing.Size(165, 20);
            this.labelInactivityPauseAfter.TabIndex = 13;
            this.labelInactivityPauseAfter.Text = "Pause after (minutes):";
            // 
            // inactivityTreshold
            // 
            this.inactivityTreshold.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.inactivityTreshold.Location = new System.Drawing.Point(177, 55);
            this.inactivityTreshold.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.inactivityTreshold.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.inactivityTreshold.Name = "inactivityTreshold";
            this.inactivityTreshold.Size = new System.Drawing.Size(83, 26);
            this.inactivityTreshold.TabIndex = 12;
            this.inactivityTreshold.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.inactivityTreshold.ValueChanged += new System.EventHandler(this.InactivityTreshold_ValueChanged);
            // 
            // checkboxInactivity
            // 
            this.checkboxInactivity.AutoSize = true;
            this.checkboxInactivity.Location = new System.Drawing.Point(6, 25);
            this.checkboxInactivity.Name = "checkboxInactivity";
            this.checkboxInactivity.Size = new System.Drawing.Size(218, 24);
            this.checkboxInactivity.TabIndex = 0;
            this.checkboxInactivity.Text = "Pause timer when inactive";
            this.checkboxInactivity.UseVisualStyleBackColor = true;
            this.checkboxInactivity.CheckedChanged += new System.EventHandler(this.CheckboxInactivity_CheckedChanged);
            // 
            // labelAutosaveInterval
            // 
            this.labelAutosaveInterval.AutoSize = true;
            this.labelAutosaveInterval.Location = new System.Drawing.Point(8, 188);
            this.labelAutosaveInterval.Name = "labelAutosaveInterval";
            this.labelAutosaveInterval.Size = new System.Drawing.Size(150, 20);
            this.labelAutosaveInterval.TabIndex = 10;
            this.labelAutosaveInterval.Text = "Autosave (minutes):";
            // 
            // autosaveInterval
            // 
            this.autosaveInterval.Location = new System.Drawing.Point(160, 186);
            this.autosaveInterval.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.autosaveInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.autosaveInterval.Name = "autosaveInterval";
            this.autosaveInterval.Size = new System.Drawing.Size(83, 26);
            this.autosaveInterval.TabIndex = 9;
            this.autosaveInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.autosaveInterval.ValueChanged += new System.EventHandler(this.AutosaveInterval_ValueChanged);
            // 
            // checkBoxDisableWhileTimer
            // 
            this.checkBoxDisableWhileTimer.AutoSize = true;
            this.checkBoxDisableWhileTimer.Location = new System.Drawing.Point(6, 149);
            this.checkBoxDisableWhileTimer.Name = "checkBoxDisableWhileTimer";
            this.checkBoxDisableWhileTimer.Size = new System.Drawing.Size(293, 24);
            this.checkBoxDisableWhileTimer.TabIndex = 8;
            this.checkBoxDisableWhileTimer.Text = "Disable detection while timer paused";
            this.checkBoxDisableWhileTimer.UseVisualStyleBackColor = true;
            this.checkBoxDisableWhileTimer.CheckedChanged += new System.EventHandler(this.CheckBoxDisableWhileTimer_CheckedChanged);
            // 
            // labelWindowStyle
            // 
            this.labelWindowStyle.AutoSize = true;
            this.labelWindowStyle.Location = new System.Drawing.Point(8, 118);
            this.labelWindowStyle.Name = "labelWindowStyle";
            this.labelWindowStyle.Size = new System.Drawing.Size(108, 20);
            this.labelWindowStyle.TabIndex = 7;
            this.labelWindowStyle.Text = "Window Style:";
            // 
            // comboBoxStyleSelect
            // 
            this.comboBoxStyleSelect.FormattingEnabled = true;
            this.comboBoxStyleSelect.Location = new System.Drawing.Point(122, 115);
            this.comboBoxStyleSelect.Name = "comboBoxStyleSelect";
            this.comboBoxStyleSelect.Size = new System.Drawing.Size(121, 28);
            this.comboBoxStyleSelect.TabIndex = 6;
            this.comboBoxStyleSelect.SelectedIndexChanged += new System.EventHandler(this.ComboBoxStyleSelect_SelectedIndexChanged);
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
            this.opacityTrackBar.Scroll += new System.EventHandler(this.OpacityTrackBar_Scroll);
            // 
            // lumaChanceTabPage
            // 
            this.lumaChanceTabPage.Controls.Add(this.groupBox6);
            this.lumaChanceTabPage.Location = new System.Drawing.Point(4, 29);
            this.lumaChanceTabPage.Name = "lumaChanceTabPage";
            this.lumaChanceTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.lumaChanceTabPage.Size = new System.Drawing.Size(334, 402);
            this.lumaChanceTabPage.TabIndex = 5;
            this.lumaChanceTabPage.Text = "Luma Chance";
            this.lumaChanceTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.radioButtonLuma75Percent);
            this.groupBox6.Controls.Add(this.radioButtonLuma9999Percent);
            this.groupBox6.Controls.Add(this.radioButtonLuma50Percent);
            this.groupBox6.Location = new System.Drawing.Point(8, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(318, 115);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Show Time For";
            // 
            // radioButtonLuma75Percent
            // 
            this.radioButtonLuma75Percent.AutoSize = true;
            this.radioButtonLuma75Percent.Location = new System.Drawing.Point(6, 53);
            this.radioButtonLuma75Percent.Name = "radioButtonLuma75Percent";
            this.radioButtonLuma75Percent.Size = new System.Drawing.Size(66, 24);
            this.radioButtonLuma75Percent.TabIndex = 4;
            this.radioButtonLuma75Percent.TabStop = true;
            this.radioButtonLuma75Percent.Text = "75%";
            this.radioButtonLuma75Percent.UseVisualStyleBackColor = true;
            this.radioButtonLuma75Percent.CheckedChanged += new System.EventHandler(this.RadioButtonLuma75Percent_CheckedChanged);
            // 
            // radioButtonLuma9999Percent
            // 
            this.radioButtonLuma9999Percent.AutoSize = true;
            this.radioButtonLuma9999Percent.Location = new System.Drawing.Point(6, 83);
            this.radioButtonLuma9999Percent.Name = "radioButtonLuma9999Percent";
            this.radioButtonLuma9999Percent.Size = new System.Drawing.Size(88, 24);
            this.radioButtonLuma9999Percent.TabIndex = 3;
            this.radioButtonLuma9999Percent.TabStop = true;
            this.radioButtonLuma9999Percent.Text = "99.99%";
            this.radioButtonLuma9999Percent.UseVisualStyleBackColor = true;
            this.radioButtonLuma9999Percent.CheckedChanged += new System.EventHandler(this.RadioButtonLuma9999Percent_CheckedChanged);
            // 
            // radioButtonLuma50Percent
            // 
            this.radioButtonLuma50Percent.AutoSize = true;
            this.radioButtonLuma50Percent.Location = new System.Drawing.Point(6, 25);
            this.radioButtonLuma50Percent.Name = "radioButtonLuma50Percent";
            this.radioButtonLuma50Percent.Size = new System.Drawing.Size(66, 24);
            this.radioButtonLuma50Percent.TabIndex = 2;
            this.radioButtonLuma50Percent.TabStop = true;
            this.radioButtonLuma50Percent.Text = "50%";
            this.radioButtonLuma50Percent.UseVisualStyleBackColor = true;
            this.radioButtonLuma50Percent.CheckedChanged += new System.EventHandler(this.RadioButtonLuma50Percent_CheckedChanged);
            // 
            // saiparkTabPage
            // 
            this.saiparkTabPage.Controls.Add(this.groupBox2);
            this.saiparkTabPage.Controls.Add(this.groupBox1);
            this.saiparkTabPage.Controls.Add(this.checkBoxSaiparkMode);
            this.saiparkTabPage.Location = new System.Drawing.Point(4, 29);
            this.saiparkTabPage.Name = "saiparkTabPage";
            this.saiparkTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.saiparkTabPage.Size = new System.Drawing.Size(334, 402);
            this.saiparkTabPage.TabIndex = 3;
            this.saiparkTabPage.Text = "Saipark";
            this.saiparkTabPage.UseVisualStyleBackColor = true;
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
            this.temtem2Multiplier.ValueChanged += new System.EventHandler(this.Temtem2Multiplier_ValueChanged);
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
            this.temtem2NameSelect.SelectedIndexChanged += new System.EventHandler(this.Temtem2NameSelect_SelectedIndexChanged);
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
            this.temtem1Multiplier.ValueChanged += new System.EventHandler(this.Temtem1Multiplier_ValueChanged);
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
            this.temtem1NameSelect.SelectedIndexChanged += new System.EventHandler(this.Temtem1NameSelect_SelectedIndexChanged);
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
            this.checkBoxSaiparkMode.CheckedChanged += new System.EventHandler(this.CheckBoxSaiparkMode_CheckedChanged);
            // 
            // hotkeysTabPage
            // 
            this.hotkeysTabPage.Controls.Add(this.groupBox5);
            this.hotkeysTabPage.Controls.Add(this.groupBox4);
            this.hotkeysTabPage.Location = new System.Drawing.Point(4, 29);
            this.hotkeysTabPage.Name = "hotkeysTabPage";
            this.hotkeysTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.hotkeysTabPage.Size = new System.Drawing.Size(334, 402);
            this.hotkeysTabPage.TabIndex = 4;
            this.hotkeysTabPage.Text = "Hotkeys";
            this.hotkeysTabPage.UseVisualStyleBackColor = true;
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
            this.buttonRemapPauseTimerHotkey.Location = new System.Drawing.Point(209, 29);
            this.buttonRemapPauseTimerHotkey.Name = "buttonRemapPauseTimerHotkey";
            this.buttonRemapPauseTimerHotkey.Size = new System.Drawing.Size(103, 36);
            this.buttonRemapPauseTimerHotkey.TabIndex = 1;
            this.buttonRemapPauseTimerHotkey.Text = "Remap";
            this.buttonRemapPauseTimerHotkey.UseVisualStyleBackColor = true;
            this.buttonRemapPauseTimerHotkey.Click += new System.EventHandler(this.ButtonRemapPauseTimerHotkey_Click);
            // 
            // labelPauseTimerHotkey
            // 
            this.labelPauseTimerHotkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPauseTimerHotkey.Location = new System.Drawing.Point(6, 33);
            this.labelPauseTimerHotkey.Name = "labelPauseTimerHotkey";
            this.labelPauseTimerHotkey.Size = new System.Drawing.Size(197, 28);
            this.labelPauseTimerHotkey.TabIndex = 0;
            this.labelPauseTimerHotkey.Text = "Modifier + Key";
            this.labelPauseTimerHotkey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.buttonRemapResetTableHotkey.Location = new System.Drawing.Point(209, 29);
            this.buttonRemapResetTableHotkey.Name = "buttonRemapResetTableHotkey";
            this.buttonRemapResetTableHotkey.Size = new System.Drawing.Size(103, 36);
            this.buttonRemapResetTableHotkey.TabIndex = 1;
            this.buttonRemapResetTableHotkey.Text = "Remap";
            this.buttonRemapResetTableHotkey.UseVisualStyleBackColor = true;
            this.buttonRemapResetTableHotkey.Click += new System.EventHandler(this.ButtonRemapResetTableHotkey_Click);
            // 
            // labelResetTableHotkey
            // 
            this.labelResetTableHotkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResetTableHotkey.Location = new System.Drawing.Point(6, 33);
            this.labelResetTableHotkey.Name = "labelResetTableHotkey";
            this.labelResetTableHotkey.Size = new System.Drawing.Size(197, 28);
            this.labelResetTableHotkey.TabIndex = 0;
            this.labelResetTableHotkey.Text = "Modifier + Key";
            this.labelResetTableHotkey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 435);
            this.Controls.Add(this.settingsTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsWindow";
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsWindow_FormClosing);
            this.settingsTabControl.ResumeLayout(false);
            this.windowTabPage.ResumeLayout(false);
            this.windowTabPage.PerformLayout();
            this.inactivitySettings.ResumeLayout(false);
            this.inactivitySettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inactivityTreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autosaveInterval)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacityTrackBar)).EndInit();
            this.lumaChanceTabPage.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.saiparkTabPage.ResumeLayout(false);
            this.saiparkTabPage.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temtem2Multiplier)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temtem1Multiplier)).EndInit();
            this.hotkeysTabPage.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl settingsTabControl;
        private System.Windows.Forms.TabPage windowTabPage;
        private System.Windows.Forms.TabPage saiparkTabPage;
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
        private System.Windows.Forms.TabPage hotkeysTabPage;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelResetTableHotkey;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonRemapPauseTimerHotkey;
        private System.Windows.Forms.Label labelPauseTimerHotkey;
        private System.Windows.Forms.Button buttonRemapResetTableHotkey;
        private System.Windows.Forms.TabPage lumaChanceTabPage;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton radioButtonLuma9999Percent;
        private System.Windows.Forms.RadioButton radioButtonLuma50Percent;
        private System.Windows.Forms.RadioButton radioButtonLuma75Percent;
        private System.Windows.Forms.Label labelWindowStyle;
        private System.Windows.Forms.ComboBox comboBoxStyleSelect;
        private System.Windows.Forms.CheckBox checkBoxDisableWhileTimer;
        private System.Windows.Forms.Label labelAutosaveInterval;
        private System.Windows.Forms.NumericUpDown autosaveInterval;
        private System.Windows.Forms.GroupBox inactivitySettings;
        private System.Windows.Forms.NumericUpDown inactivityTreshold;
        private System.Windows.Forms.CheckBox checkboxInactivity;
        private System.Windows.Forms.Label labelInactivityPauseAfter;
    }
}