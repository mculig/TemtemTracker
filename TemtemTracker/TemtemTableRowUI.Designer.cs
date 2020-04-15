namespace TemtemTracker
{
    partial class TemtemTableRowUI
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
            this.labelEncounteredPercent = new System.Windows.Forms.Label();
            this.labelChanceLuma = new System.Windows.Forms.Label();
            this.labelEncounters = new System.Windows.Forms.Label();
            this.labelTemtemName = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.labelTimeToLuma = new System.Windows.Forms.Label();
            this.buttonShowIndividualWindow = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66611F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66611F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66611F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66611F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66611F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.334721F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.334721F));
            this.tableLayoutPanel1.Controls.Add(this.buttonShowIndividualWindow, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelEncounteredPercent, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelChanceLuma, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelEncounters, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelTemtemName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelTimeToLuma, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.deleteButton, 5, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(824, 38);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelEncounteredPercent
            // 
            this.labelEncounteredPercent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEncounteredPercent.AutoSize = true;
            this.labelEncounteredPercent.Location = new System.Drawing.Point(420, 9);
            this.labelEncounteredPercent.Name = "labelEncounteredPercent";
            this.labelEncounteredPercent.Size = new System.Drawing.Size(119, 20);
            this.labelEncounteredPercent.TabIndex = 5;
            this.labelEncounteredPercent.Text = "Encountered %";
            // 
            // labelChanceLuma
            // 
            this.labelChanceLuma.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelChanceLuma.AutoSize = true;
            this.labelChanceLuma.Location = new System.Drawing.Point(288, 9);
            this.labelChanceLuma.Name = "labelChanceLuma";
            this.labelChanceLuma.Size = new System.Drawing.Size(108, 20);
            this.labelChanceLuma.TabIndex = 4;
            this.labelChanceLuma.Text = "Chance Luma";
            // 
            // labelEncounters
            // 
            this.labelEncounters.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEncounters.AutoSize = true;
            this.labelEncounters.Location = new System.Drawing.Point(160, 9);
            this.labelEncounters.Name = "labelEncounters";
            this.labelEncounters.Size = new System.Drawing.Size(91, 20);
            this.labelEncounters.TabIndex = 3;
            this.labelEncounters.Text = "Encounters";
            // 
            // labelTemtemName
            // 
            this.labelTemtemName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTemtemName.AutoSize = true;
            this.labelTemtemName.Location = new System.Drawing.Point(35, 9);
            this.labelTemtemName.Name = "labelTemtemName";
            this.labelTemtemName.Size = new System.Drawing.Size(67, 20);
            this.labelTemtemName.TabIndex = 2;
            this.labelTemtemName.Text = "Temtem";
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(688, 3);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(62, 32);
            this.deleteButton.TabIndex = 0;
            this.deleteButton.Text = "X";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // labelTimeToLuma
            // 
            this.labelTimeToLuma.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTimeToLuma.AutoSize = true;
            this.labelTimeToLuma.Location = new System.Drawing.Point(564, 9);
            this.labelTimeToLuma.Name = "labelTimeToLuma";
            this.labelTimeToLuma.Size = new System.Drawing.Size(105, 20);
            this.labelTimeToLuma.TabIndex = 1;
            this.labelTimeToLuma.Text = "Time to Luma";
            // 
            // buttonShowIndividualWindow
            // 
            this.buttonShowIndividualWindow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonShowIndividualWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowIndividualWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowIndividualWindow.Location = new System.Drawing.Point(757, 3);
            this.buttonShowIndividualWindow.Name = "buttonShowIndividualWindow";
            this.buttonShowIndividualWindow.Size = new System.Drawing.Size(62, 32);
            this.buttonShowIndividualWindow.TabIndex = 6;
            this.buttonShowIndividualWindow.Text = "W";
            this.buttonShowIndividualWindow.UseVisualStyleBackColor = true;
            this.buttonShowIndividualWindow.Click += new System.EventHandler(this.ButtonShowIndividualWindow_Click);
            // 
            // TemtemTableRowUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TemtemTableRowUI";
            this.Size = new System.Drawing.Size(830, 45);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelEncounteredPercent;
        private System.Windows.Forms.Label labelChanceLuma;
        private System.Windows.Forms.Label labelEncounters;
        private System.Windows.Forms.Label labelTimeToLuma;
        private System.Windows.Forms.Label labelTemtemName;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button buttonShowIndividualWindow;
    }
}
