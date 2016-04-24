namespace CustomCalendarApplication
{
    partial class FormattingHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormattingHelp));
            this.labelHeader = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.textBoxMonth = new System.Windows.Forms.TextBox();
            this.labelMonth = new System.Windows.Forms.Label();
            this.textBoxMonthShort = new System.Windows.Forms.TextBox();
            this.labelMonthShort = new System.Windows.Forms.Label();
            this.textBoxMonthNumeric = new System.Windows.Forms.TextBox();
            this.labelMonthNumeric = new System.Windows.Forms.Label();
            this.textBoxDayOfMonth = new System.Windows.Forms.TextBox();
            this.labelDayOfMonth = new System.Windows.Forms.Label();
            this.textBoxCalendarWeek = new System.Windows.Forms.TextBox();
            this.labelCalendarWeek = new System.Windows.Forms.Label();
            this.textBoxWeekDay = new System.Windows.Forms.TextBox();
            this.labelWeekDay = new System.Windows.Forms.Label();
            this.textBoxWeekDayShort = new System.Windows.Forms.TextBox();
            this.labelWeekDayShort = new System.Windows.Forms.Label();
            this.textBoxWeekDayNumeric = new System.Windows.Forms.TextBox();
            this.labelWeekDayNumeric = new System.Windows.Forms.Label();
            this.textBoxTotalDay = new System.Windows.Forms.TextBox();
            this.labelTotalDay = new System.Windows.Forms.Label();
            this.textBoxDayOfYear = new System.Windows.Forms.TextBox();
            this.labelDayOfYear = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHeader.Location = new System.Drawing.Point(12, 9);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(615, 59);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Formatting Help\r\n\r\nWith these tokens, you can control how the calendar displays c" +
    "ertain dates (the tokens will be replaced by the respective values)";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelYear
            // 
            this.labelYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelYear.Location = new System.Drawing.Point(133, 59);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(494, 20);
            this.labelYear.TabIndex = 2;
            this.labelYear.Text = "Displays the current year as a number";
            this.labelYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxYear
            // 
            this.textBoxYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxYear.Location = new System.Drawing.Point(12, 63);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.ReadOnly = true;
            this.textBoxYear.Size = new System.Drawing.Size(100, 13);
            this.textBoxYear.TabIndex = 3;
            this.textBoxYear.TabStop = false;
            this.textBoxYear.Text = "{Year}";
            // 
            // textBoxMonth
            // 
            this.textBoxMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMonth.Location = new System.Drawing.Point(12, 83);
            this.textBoxMonth.Name = "textBoxMonth";
            this.textBoxMonth.ReadOnly = true;
            this.textBoxMonth.Size = new System.Drawing.Size(100, 13);
            this.textBoxMonth.TabIndex = 5;
            this.textBoxMonth.TabStop = false;
            this.textBoxMonth.Text = "{Month}";
            // 
            // labelMonth
            // 
            this.labelMonth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMonth.Location = new System.Drawing.Point(133, 79);
            this.labelMonth.Name = "labelMonth";
            this.labelMonth.Size = new System.Drawing.Size(494, 20);
            this.labelMonth.TabIndex = 4;
            this.labelMonth.Text = "Displays the name of the current month";
            this.labelMonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxMonthShort
            // 
            this.textBoxMonthShort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMonthShort.Location = new System.Drawing.Point(12, 103);
            this.textBoxMonthShort.Name = "textBoxMonthShort";
            this.textBoxMonthShort.ReadOnly = true;
            this.textBoxMonthShort.Size = new System.Drawing.Size(100, 13);
            this.textBoxMonthShort.TabIndex = 7;
            this.textBoxMonthShort.TabStop = false;
            this.textBoxMonthShort.Text = "{MonthShort}";
            // 
            // labelMonthShort
            // 
            this.labelMonthShort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMonthShort.Location = new System.Drawing.Point(133, 99);
            this.labelMonthShort.Name = "labelMonthShort";
            this.labelMonthShort.Size = new System.Drawing.Size(494, 20);
            this.labelMonthShort.TabIndex = 6;
            this.labelMonthShort.Text = "Displays the short name of the current month";
            this.labelMonthShort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxMonthNumeric
            // 
            this.textBoxMonthNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMonthNumeric.Location = new System.Drawing.Point(12, 123);
            this.textBoxMonthNumeric.Name = "textBoxMonthNumeric";
            this.textBoxMonthNumeric.ReadOnly = true;
            this.textBoxMonthNumeric.Size = new System.Drawing.Size(100, 13);
            this.textBoxMonthNumeric.TabIndex = 9;
            this.textBoxMonthNumeric.TabStop = false;
            this.textBoxMonthNumeric.Text = "{MonthNumeric}";
            // 
            // labelMonthNumeric
            // 
            this.labelMonthNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMonthNumeric.Location = new System.Drawing.Point(132, 119);
            this.labelMonthNumeric.Name = "labelMonthNumeric";
            this.labelMonthNumeric.Size = new System.Drawing.Size(494, 20);
            this.labelMonthNumeric.TabIndex = 8;
            this.labelMonthNumeric.Text = "Displays the current month as a number, starting at 1";
            this.labelMonthNumeric.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxDayOfMonth
            // 
            this.textBoxDayOfMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDayOfMonth.Location = new System.Drawing.Point(12, 143);
            this.textBoxDayOfMonth.Name = "textBoxDayOfMonth";
            this.textBoxDayOfMonth.ReadOnly = true;
            this.textBoxDayOfMonth.Size = new System.Drawing.Size(100, 13);
            this.textBoxDayOfMonth.TabIndex = 11;
            this.textBoxDayOfMonth.TabStop = false;
            this.textBoxDayOfMonth.Text = "{DayOfMonth}";
            // 
            // labelDayOfMonth
            // 
            this.labelDayOfMonth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDayOfMonth.Location = new System.Drawing.Point(133, 139);
            this.labelDayOfMonth.Name = "labelDayOfMonth";
            this.labelDayOfMonth.Size = new System.Drawing.Size(494, 20);
            this.labelDayOfMonth.TabIndex = 10;
            this.labelDayOfMonth.Text = "Displays the current day of the month as a number, starting at 1";
            this.labelDayOfMonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxCalendarWeek
            // 
            this.textBoxCalendarWeek.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCalendarWeek.Location = new System.Drawing.Point(12, 163);
            this.textBoxCalendarWeek.Name = "textBoxCalendarWeek";
            this.textBoxCalendarWeek.ReadOnly = true;
            this.textBoxCalendarWeek.Size = new System.Drawing.Size(100, 13);
            this.textBoxCalendarWeek.TabIndex = 13;
            this.textBoxCalendarWeek.TabStop = false;
            this.textBoxCalendarWeek.Text = "{CalendarWeek}";
            // 
            // labelCalendarWeek
            // 
            this.labelCalendarWeek.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCalendarWeek.Location = new System.Drawing.Point(133, 159);
            this.labelCalendarWeek.Name = "labelCalendarWeek";
            this.labelCalendarWeek.Size = new System.Drawing.Size(494, 20);
            this.labelCalendarWeek.TabIndex = 12;
            this.labelCalendarWeek.Text = "Displays the current calendar week as a number, starting at 1";
            this.labelCalendarWeek.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxWeekDay
            // 
            this.textBoxWeekDay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxWeekDay.Location = new System.Drawing.Point(12, 183);
            this.textBoxWeekDay.Name = "textBoxWeekDay";
            this.textBoxWeekDay.ReadOnly = true;
            this.textBoxWeekDay.Size = new System.Drawing.Size(100, 13);
            this.textBoxWeekDay.TabIndex = 15;
            this.textBoxWeekDay.TabStop = false;
            this.textBoxWeekDay.Text = "{WeekDay}";
            // 
            // labelWeekDay
            // 
            this.labelWeekDay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWeekDay.Location = new System.Drawing.Point(133, 179);
            this.labelWeekDay.Name = "labelWeekDay";
            this.labelWeekDay.Size = new System.Drawing.Size(494, 20);
            this.labelWeekDay.TabIndex = 14;
            this.labelWeekDay.Text = "Displays the name of the current weekday";
            this.labelWeekDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxWeekDayShort
            // 
            this.textBoxWeekDayShort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxWeekDayShort.Location = new System.Drawing.Point(12, 203);
            this.textBoxWeekDayShort.Name = "textBoxWeekDayShort";
            this.textBoxWeekDayShort.ReadOnly = true;
            this.textBoxWeekDayShort.Size = new System.Drawing.Size(100, 13);
            this.textBoxWeekDayShort.TabIndex = 17;
            this.textBoxWeekDayShort.TabStop = false;
            this.textBoxWeekDayShort.Text = "{WeekDayShort}";
            // 
            // labelWeekDayShort
            // 
            this.labelWeekDayShort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWeekDayShort.Location = new System.Drawing.Point(133, 199);
            this.labelWeekDayShort.Name = "labelWeekDayShort";
            this.labelWeekDayShort.Size = new System.Drawing.Size(494, 20);
            this.labelWeekDayShort.TabIndex = 16;
            this.labelWeekDayShort.Text = "Displays the short name of the current weekday";
            this.labelWeekDayShort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxWeekDayNumeric
            // 
            this.textBoxWeekDayNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxWeekDayNumeric.Location = new System.Drawing.Point(12, 223);
            this.textBoxWeekDayNumeric.Name = "textBoxWeekDayNumeric";
            this.textBoxWeekDayNumeric.ReadOnly = true;
            this.textBoxWeekDayNumeric.Size = new System.Drawing.Size(100, 13);
            this.textBoxWeekDayNumeric.TabIndex = 19;
            this.textBoxWeekDayNumeric.TabStop = false;
            this.textBoxWeekDayNumeric.Text = "{WeekDayNumeric}";
            // 
            // labelWeekDayNumeric
            // 
            this.labelWeekDayNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWeekDayNumeric.Location = new System.Drawing.Point(132, 219);
            this.labelWeekDayNumeric.Name = "labelWeekDayNumeric";
            this.labelWeekDayNumeric.Size = new System.Drawing.Size(494, 20);
            this.labelWeekDayNumeric.TabIndex = 18;
            this.labelWeekDayNumeric.Text = "Displays the current weekday as a number, starting at 1";
            this.labelWeekDayNumeric.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxTotalDay
            // 
            this.textBoxTotalDay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTotalDay.Location = new System.Drawing.Point(12, 243);
            this.textBoxTotalDay.Name = "textBoxTotalDay";
            this.textBoxTotalDay.ReadOnly = true;
            this.textBoxTotalDay.Size = new System.Drawing.Size(66, 13);
            this.textBoxTotalDay.TabIndex = 21;
            this.textBoxTotalDay.TabStop = false;
            this.textBoxTotalDay.Text = "{TotalDay}";
            // 
            // labelTotalDay
            // 
            this.labelTotalDay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotalDay.Location = new System.Drawing.Point(84, 239);
            this.labelTotalDay.Name = "labelTotalDay";
            this.labelTotalDay.Size = new System.Drawing.Size(543, 20);
            this.labelTotalDay.TabIndex = 20;
            this.labelTotalDay.Text = "Displays the current day, counting from the calendar\'s beginning, as a number, st" +
    "arting at 1";
            this.labelTotalDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxDayOfYear
            // 
            this.textBoxDayOfYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDayOfYear.Location = new System.Drawing.Point(12, 263);
            this.textBoxDayOfYear.Name = "textBoxDayOfYear";
            this.textBoxDayOfYear.ReadOnly = true;
            this.textBoxDayOfYear.Size = new System.Drawing.Size(100, 13);
            this.textBoxDayOfYear.TabIndex = 23;
            this.textBoxDayOfYear.TabStop = false;
            this.textBoxDayOfYear.Text = "{DayOfYear}";
            // 
            // labelDayOfYear
            // 
            this.labelDayOfYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDayOfYear.Location = new System.Drawing.Point(133, 259);
            this.labelDayOfYear.Name = "labelDayOfYear";
            this.labelDayOfYear.Size = new System.Drawing.Size(494, 20);
            this.labelDayOfYear.TabIndex = 22;
            this.labelDayOfYear.Text = "Displays the current day of the year as a number, starting at 1";
            this.labelDayOfYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonConfirm.Location = new System.Drawing.Point(281, 293);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 24;
            this.buttonConfirm.Text = "OK";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // FormattingHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 328);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.textBoxDayOfYear);
            this.Controls.Add(this.labelDayOfYear);
            this.Controls.Add(this.textBoxTotalDay);
            this.Controls.Add(this.labelTotalDay);
            this.Controls.Add(this.textBoxWeekDayNumeric);
            this.Controls.Add(this.labelWeekDayNumeric);
            this.Controls.Add(this.textBoxWeekDayShort);
            this.Controls.Add(this.labelWeekDayShort);
            this.Controls.Add(this.textBoxWeekDay);
            this.Controls.Add(this.labelWeekDay);
            this.Controls.Add(this.textBoxCalendarWeek);
            this.Controls.Add(this.labelCalendarWeek);
            this.Controls.Add(this.textBoxDayOfMonth);
            this.Controls.Add(this.labelDayOfMonth);
            this.Controls.Add(this.textBoxMonthNumeric);
            this.Controls.Add(this.labelMonthNumeric);
            this.Controls.Add(this.textBoxMonthShort);
            this.Controls.Add(this.labelMonthShort);
            this.Controls.Add(this.textBoxMonth);
            this.Controls.Add(this.labelMonth);
            this.Controls.Add(this.textBoxYear);
            this.Controls.Add(this.labelYear);
            this.Controls.Add(this.labelHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(655, 367);
            this.Name = "FormattingHelp";
            this.Text = "Custom Calendar - Formatting Help";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.TextBox textBoxMonth;
        private System.Windows.Forms.Label labelMonth;
        private System.Windows.Forms.TextBox textBoxMonthShort;
        private System.Windows.Forms.Label labelMonthShort;
        private System.Windows.Forms.TextBox textBoxMonthNumeric;
        private System.Windows.Forms.Label labelMonthNumeric;
        private System.Windows.Forms.TextBox textBoxDayOfMonth;
        private System.Windows.Forms.Label labelDayOfMonth;
        private System.Windows.Forms.TextBox textBoxCalendarWeek;
        private System.Windows.Forms.Label labelCalendarWeek;
        private System.Windows.Forms.TextBox textBoxWeekDay;
        private System.Windows.Forms.Label labelWeekDay;
        private System.Windows.Forms.TextBox textBoxWeekDayShort;
        private System.Windows.Forms.Label labelWeekDayShort;
        private System.Windows.Forms.TextBox textBoxWeekDayNumeric;
        private System.Windows.Forms.Label labelWeekDayNumeric;
        private System.Windows.Forms.TextBox textBoxTotalDay;
        private System.Windows.Forms.Label labelTotalDay;
        private System.Windows.Forms.TextBox textBoxDayOfYear;
        private System.Windows.Forms.Label labelDayOfYear;
        private System.Windows.Forms.Button buttonConfirm;
    }
}