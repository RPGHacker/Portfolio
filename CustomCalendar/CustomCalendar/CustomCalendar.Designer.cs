namespace CustomCalendarApplication
{
    partial class CustomCalendar
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
            this.buttonArrowLeft = new System.Windows.Forms.Button();
            this.buttonArrowRight = new System.Windows.Forms.Button();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.numericUpDownYear = new System.Windows.Forms.NumericUpDown();
            this.labelMonth = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.tableLayoutPanelDates = new System.Windows.Forms.TableLayoutPanel();
            this.labelSelectedDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYear)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonArrowLeft
            // 
            this.buttonArrowLeft.Location = new System.Drawing.Point(3, 15);
            this.buttonArrowLeft.Name = "buttonArrowLeft";
            this.buttonArrowLeft.Size = new System.Drawing.Size(16, 23);
            this.buttonArrowLeft.TabIndex = 0;
            this.buttonArrowLeft.Text = "◀";
            this.buttonArrowLeft.UseVisualStyleBackColor = true;
            this.buttonArrowLeft.Click += new System.EventHandler(this.buttonArrowLeft_Click);
            // 
            // buttonArrowRight
            // 
            this.buttonArrowRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonArrowRight.Location = new System.Drawing.Point(281, 15);
            this.buttonArrowRight.Name = "buttonArrowRight";
            this.buttonArrowRight.Size = new System.Drawing.Size(16, 23);
            this.buttonArrowRight.TabIndex = 1;
            this.buttonArrowRight.Text = "▶";
            this.buttonArrowRight.UseVisualStyleBackColor = true;
            this.buttonArrowRight.Click += new System.EventHandler(this.buttonArrowRight_Click);
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Location = new System.Drawing.Point(25, 16);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(183, 21);
            this.comboBoxMonth.TabIndex = 2;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // numericUpDownYear
            // 
            this.numericUpDownYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownYear.Location = new System.Drawing.Point(214, 17);
            this.numericUpDownYear.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownYear.Name = "numericUpDownYear";
            this.numericUpDownYear.Size = new System.Drawing.Size(61, 20);
            this.numericUpDownYear.TabIndex = 3;
            this.numericUpDownYear.ValueChanged += new System.EventHandler(this.numericUpDownYear_ValueChanged);
            // 
            // labelMonth
            // 
            this.labelMonth.AutoSize = true;
            this.labelMonth.Location = new System.Drawing.Point(22, 0);
            this.labelMonth.Name = "labelMonth";
            this.labelMonth.Size = new System.Drawing.Size(37, 13);
            this.labelMonth.TabIndex = 4;
            this.labelMonth.Text = "Month";
            // 
            // labelYear
            // 
            this.labelYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(211, 0);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(29, 13);
            this.labelYear.TabIndex = 5;
            this.labelYear.Text = "Year";
            // 
            // buttonSettings
            // 
            this.buttonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSettings.Location = new System.Drawing.Point(265, 265);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(32, 32);
            this.buttonSettings.TabIndex = 6;
            this.buttonSettings.Text = "⛭";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // tableLayoutPanelDates
            // 
            this.tableLayoutPanelDates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelDates.ColumnCount = 1;
            this.tableLayoutPanelDates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDates.Location = new System.Drawing.Point(3, 44);
            this.tableLayoutPanelDates.Name = "tableLayoutPanelDates";
            this.tableLayoutPanelDates.RowCount = 1;
            this.tableLayoutPanelDates.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDates.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 215F));
            this.tableLayoutPanelDates.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 215F));
            this.tableLayoutPanelDates.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 215F));
            this.tableLayoutPanelDates.Size = new System.Drawing.Size(294, 215);
            this.tableLayoutPanelDates.TabIndex = 7;
            // 
            // labelSelectedDate
            // 
            this.labelSelectedDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSelectedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedDate.Location = new System.Drawing.Point(3, 262);
            this.labelSelectedDate.Name = "labelSelectedDate";
            this.labelSelectedDate.Size = new System.Drawing.Size(256, 35);
            this.labelSelectedDate.TabIndex = 8;
            this.labelSelectedDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CustomCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelSelectedDate);
            this.Controls.Add(this.tableLayoutPanelDates);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.labelYear);
            this.Controls.Add(this.labelMonth);
            this.Controls.Add(this.numericUpDownYear);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.buttonArrowRight);
            this.Controls.Add(this.buttonArrowLeft);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "CustomCalendar";
            this.Size = new System.Drawing.Size(300, 300);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonArrowLeft;
        private System.Windows.Forms.Button buttonArrowRight;
        private System.Windows.Forms.NumericUpDown numericUpDownYear;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.Label labelMonth;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDates;
        private System.Windows.Forms.Label labelSelectedDate;
    }
}
