namespace CustomCalendarApplication
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
            this.labelSettings = new System.Windows.Forms.Label();
            this.tableLayoutPanelGridViews = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxMonths = new System.Windows.Forms.GroupBox();
            this.buttonClearMonhts = new System.Windows.Forms.Button();
            this.buttonMinusMonths = new System.Windows.Forms.Button();
            this.buttonPlusMonth = new System.Windows.Forms.Button();
            this.dataGridViewMonths = new System.Windows.Forms.DataGridView();
            this.MonthName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonthNameShort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HasLeapDay = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBoxWeekDays = new System.Windows.Forms.GroupBox();
            this.buttonClearWeekDays = new System.Windows.Forms.Button();
            this.buttonMinusWeekDays = new System.Windows.Forms.Button();
            this.dataGridViewWeekDays = new System.Windows.Forms.DataGridView();
            this.WeekDayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeekDayNameShort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonPlusWeekDays = new System.Windows.Forms.Button();
            this.labelFirstLeapYear = new System.Windows.Forms.Label();
            this.numericUpDownFirstLeapYear = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLeapYearTimeSpan = new System.Windows.Forms.NumericUpDown();
            this.labelLeapYearTimeSpan = new System.Windows.Forms.Label();
            this.labelEvery = new System.Windows.Forms.Label();
            this.labelYearNo = new System.Windows.Forms.Label();
            this.labelYears = new System.Windows.Forms.Label();
            this.tableLayoutPanelFormats = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxDisplayFormats = new System.Windows.Forms.GroupBox();
            this.buttonFormatHelp = new System.Windows.Forms.Button();
            this.textBoxSelectedDateFormat = new System.Windows.Forms.TextBox();
            this.labelSelectedDateFormat = new System.Windows.Forms.Label();
            this.textBoxDayOfMonthFormat = new System.Windows.Forms.TextBox();
            this.labelDayOfMonthFormat = new System.Windows.Forms.Label();
            this.textBoxWeekNumberFormat = new System.Windows.Forms.TextBox();
            this.labelWeekNumberFormat = new System.Windows.Forms.Label();
            this.textBoxWeekDayFormat = new System.Windows.Forms.TextBox();
            this.labelWeekDayFormat = new System.Windows.Forms.Label();
            this.groupBoxFonts = new System.Windows.Forms.GroupBox();
            this.buttonSelectedDateFont = new System.Windows.Forms.Button();
            this.buttonDayOfMonthFont = new System.Windows.Forms.Button();
            this.buttonWeekNumberFont = new System.Windows.Forms.Button();
            this.buttonWeekDayFont = new System.Windows.Forms.Button();
            this.labelSelectedDateSample = new System.Windows.Forms.Label();
            this.labelWeekDaySample = new System.Windows.Forms.Label();
            this.labelDayOfMonthSample = new System.Windows.Forms.Label();
            this.labelWeekNumberSample = new System.Windows.Forms.Label();
            this.labelSelectedDateFont = new System.Windows.Forms.Label();
            this.labelWeekDayFont = new System.Windows.Forms.Label();
            this.labelDayOfMonthFont = new System.Windows.Forms.Label();
            this.labelWeekNumberFont = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tableLayoutPanelGridViews.SuspendLayout();
            this.groupBoxMonths.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMonths)).BeginInit();
            this.groupBoxWeekDays.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeekDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFirstLeapYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLeapYearTimeSpan)).BeginInit();
            this.tableLayoutPanelFormats.SuspendLayout();
            this.groupBoxDisplayFormats.SuspendLayout();
            this.groupBoxFonts.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSettings
            // 
            this.labelSettings.AutoSize = true;
            this.labelSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettings.Location = new System.Drawing.Point(12, 9);
            this.labelSettings.Name = "labelSettings";
            this.labelSettings.Size = new System.Drawing.Size(56, 16);
            this.labelSettings.TabIndex = 0;
            this.labelSettings.Text = "Settings";
            // 
            // tableLayoutPanelGridViews
            // 
            this.tableLayoutPanelGridViews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelGridViews.ColumnCount = 1;
            this.tableLayoutPanelGridViews.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGridViews.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGridViews.Controls.Add(this.groupBoxMonths, 0, 0);
            this.tableLayoutPanelGridViews.Controls.Add(this.groupBoxWeekDays, 0, 1);
            this.tableLayoutPanelGridViews.Location = new System.Drawing.Point(12, 28);
            this.tableLayoutPanelGridViews.Name = "tableLayoutPanelGridViews";
            this.tableLayoutPanelGridViews.RowCount = 2;
            this.tableLayoutPanelGridViews.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGridViews.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGridViews.Size = new System.Drawing.Size(580, 330);
            this.tableLayoutPanelGridViews.TabIndex = 1;
            // 
            // groupBoxMonths
            // 
            this.groupBoxMonths.Controls.Add(this.buttonClearMonhts);
            this.groupBoxMonths.Controls.Add(this.buttonMinusMonths);
            this.groupBoxMonths.Controls.Add(this.buttonPlusMonth);
            this.groupBoxMonths.Controls.Add(this.dataGridViewMonths);
            this.groupBoxMonths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMonths.Location = new System.Drawing.Point(3, 3);
            this.groupBoxMonths.Name = "groupBoxMonths";
            this.groupBoxMonths.Size = new System.Drawing.Size(574, 159);
            this.groupBoxMonths.TabIndex = 0;
            this.groupBoxMonths.TabStop = false;
            this.groupBoxMonths.Text = "Months";
            // 
            // buttonClearMonhts
            // 
            this.buttonClearMonhts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearMonhts.Location = new System.Drawing.Point(437, 130);
            this.buttonClearMonhts.Name = "buttonClearMonhts";
            this.buttonClearMonhts.Size = new System.Drawing.Size(75, 23);
            this.buttonClearMonhts.TabIndex = 3;
            this.buttonClearMonhts.Text = "Clear";
            this.buttonClearMonhts.UseVisualStyleBackColor = true;
            this.buttonClearMonhts.Click += new System.EventHandler(this.buttonClearMonhts_Click);
            // 
            // buttonMinusMonths
            // 
            this.buttonMinusMonths.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMinusMonths.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMinusMonths.Location = new System.Drawing.Point(518, 130);
            this.buttonMinusMonths.Name = "buttonMinusMonths";
            this.buttonMinusMonths.Size = new System.Drawing.Size(22, 23);
            this.buttonMinusMonths.TabIndex = 2;
            this.buttonMinusMonths.Text = "-";
            this.buttonMinusMonths.UseVisualStyleBackColor = true;
            this.buttonMinusMonths.Click += new System.EventHandler(this.buttonMinusMonths_Click);
            // 
            // buttonPlusMonth
            // 
            this.buttonPlusMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPlusMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlusMonth.Location = new System.Drawing.Point(546, 130);
            this.buttonPlusMonth.Name = "buttonPlusMonth";
            this.buttonPlusMonth.Size = new System.Drawing.Size(22, 23);
            this.buttonPlusMonth.TabIndex = 1;
            this.buttonPlusMonth.Text = "+";
            this.buttonPlusMonth.UseVisualStyleBackColor = true;
            this.buttonPlusMonth.Click += new System.EventHandler(this.buttonPlusMonth_Click);
            // 
            // dataGridViewMonths
            // 
            this.dataGridViewMonths.AllowUserToAddRows = false;
            this.dataGridViewMonths.AllowUserToDeleteRows = false;
            this.dataGridViewMonths.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMonths.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMonths.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MonthName,
            this.MonthNameShort,
            this.NumDays,
            this.HasLeapDay});
            this.dataGridViewMonths.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewMonths.Name = "dataGridViewMonths";
            this.dataGridViewMonths.Size = new System.Drawing.Size(568, 108);
            this.dataGridViewMonths.TabIndex = 0;
            // 
            // MonthName
            // 
            this.MonthName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MonthName.HeaderText = "Name";
            this.MonthName.Name = "MonthName";
            this.MonthName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MonthNameShort
            // 
            this.MonthNameShort.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MonthNameShort.HeaderText = "Short Name";
            this.MonthNameShort.Name = "MonthNameShort";
            this.MonthNameShort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NumDays
            // 
            this.NumDays.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NumDays.HeaderText = "Number of Days";
            this.NumDays.Name = "NumDays";
            this.NumDays.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // HasLeapDay
            // 
            this.HasLeapDay.HeaderText = "Has Leap Day?";
            this.HasLeapDay.Name = "HasLeapDay";
            this.HasLeapDay.Width = 50;
            // 
            // groupBoxWeekDays
            // 
            this.groupBoxWeekDays.Controls.Add(this.buttonClearWeekDays);
            this.groupBoxWeekDays.Controls.Add(this.buttonMinusWeekDays);
            this.groupBoxWeekDays.Controls.Add(this.dataGridViewWeekDays);
            this.groupBoxWeekDays.Controls.Add(this.buttonPlusWeekDays);
            this.groupBoxWeekDays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxWeekDays.Location = new System.Drawing.Point(3, 168);
            this.groupBoxWeekDays.Name = "groupBoxWeekDays";
            this.groupBoxWeekDays.Size = new System.Drawing.Size(574, 159);
            this.groupBoxWeekDays.TabIndex = 1;
            this.groupBoxWeekDays.TabStop = false;
            this.groupBoxWeekDays.Text = "Weekdays";
            // 
            // buttonClearWeekDays
            // 
            this.buttonClearWeekDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearWeekDays.Location = new System.Drawing.Point(437, 130);
            this.buttonClearWeekDays.Name = "buttonClearWeekDays";
            this.buttonClearWeekDays.Size = new System.Drawing.Size(75, 23);
            this.buttonClearWeekDays.TabIndex = 5;
            this.buttonClearWeekDays.Text = "Clear";
            this.buttonClearWeekDays.UseVisualStyleBackColor = true;
            this.buttonClearWeekDays.Click += new System.EventHandler(this.buttonClearWeekDays_Click);
            // 
            // buttonMinusWeekDays
            // 
            this.buttonMinusWeekDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMinusWeekDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMinusWeekDays.Location = new System.Drawing.Point(518, 130);
            this.buttonMinusWeekDays.Name = "buttonMinusWeekDays";
            this.buttonMinusWeekDays.Size = new System.Drawing.Size(22, 23);
            this.buttonMinusWeekDays.TabIndex = 4;
            this.buttonMinusWeekDays.Text = "-";
            this.buttonMinusWeekDays.UseVisualStyleBackColor = true;
            this.buttonMinusWeekDays.Click += new System.EventHandler(this.buttonMinusWeekDays_Click);
            // 
            // dataGridViewWeekDays
            // 
            this.dataGridViewWeekDays.AllowUserToAddRows = false;
            this.dataGridViewWeekDays.AllowUserToDeleteRows = false;
            this.dataGridViewWeekDays.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewWeekDays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWeekDays.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WeekDayName,
            this.WeekDayNameShort});
            this.dataGridViewWeekDays.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewWeekDays.Name = "dataGridViewWeekDays";
            this.dataGridViewWeekDays.Size = new System.Drawing.Size(568, 108);
            this.dataGridViewWeekDays.TabIndex = 0;
            // 
            // WeekDayName
            // 
            this.WeekDayName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WeekDayName.HeaderText = "Name";
            this.WeekDayName.Name = "WeekDayName";
            this.WeekDayName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WeekDayNameShort
            // 
            this.WeekDayNameShort.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WeekDayNameShort.HeaderText = "Short Name";
            this.WeekDayNameShort.Name = "WeekDayNameShort";
            this.WeekDayNameShort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // buttonPlusWeekDays
            // 
            this.buttonPlusWeekDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPlusWeekDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlusWeekDays.Location = new System.Drawing.Point(546, 130);
            this.buttonPlusWeekDays.Name = "buttonPlusWeekDays";
            this.buttonPlusWeekDays.Size = new System.Drawing.Size(22, 23);
            this.buttonPlusWeekDays.TabIndex = 3;
            this.buttonPlusWeekDays.Text = "+";
            this.buttonPlusWeekDays.UseVisualStyleBackColor = true;
            this.buttonPlusWeekDays.Click += new System.EventHandler(this.buttonPlusWeekDays_Click);
            // 
            // labelFirstLeapYear
            // 
            this.labelFirstLeapYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFirstLeapYear.AutoSize = true;
            this.labelFirstLeapYear.Location = new System.Drawing.Point(12, 372);
            this.labelFirstLeapYear.Name = "labelFirstLeapYear";
            this.labelFirstLeapYear.Size = new System.Drawing.Size(81, 13);
            this.labelFirstLeapYear.TabIndex = 2;
            this.labelFirstLeapYear.Text = "First Leap Year:";
            // 
            // numericUpDownFirstLeapYear
            // 
            this.numericUpDownFirstLeapYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownFirstLeapYear.Location = new System.Drawing.Point(194, 370);
            this.numericUpDownFirstLeapYear.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownFirstLeapYear.Name = "numericUpDownFirstLeapYear";
            this.numericUpDownFirstLeapYear.Size = new System.Drawing.Size(358, 20);
            this.numericUpDownFirstLeapYear.TabIndex = 3;
            // 
            // numericUpDownLeapYearTimeSpan
            // 
            this.numericUpDownLeapYearTimeSpan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownLeapYearTimeSpan.Location = new System.Drawing.Point(194, 396);
            this.numericUpDownLeapYearTimeSpan.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownLeapYearTimeSpan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLeapYearTimeSpan.Name = "numericUpDownLeapYearTimeSpan";
            this.numericUpDownLeapYearTimeSpan.Size = new System.Drawing.Size(358, 20);
            this.numericUpDownLeapYearTimeSpan.TabIndex = 5;
            this.numericUpDownLeapYearTimeSpan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelLeapYearTimeSpan
            // 
            this.labelLeapYearTimeSpan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelLeapYearTimeSpan.AutoSize = true;
            this.labelLeapYearTimeSpan.Location = new System.Drawing.Point(12, 398);
            this.labelLeapYearTimeSpan.Name = "labelLeapYearTimeSpan";
            this.labelLeapYearTimeSpan.Size = new System.Drawing.Size(113, 13);
            this.labelLeapYearTimeSpan.TabIndex = 4;
            this.labelLeapYearTimeSpan.Text = "Leap Year Time Span:";
            // 
            // labelEvery
            // 
            this.labelEvery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelEvery.Location = new System.Drawing.Point(132, 398);
            this.labelEvery.Name = "labelEvery";
            this.labelEvery.Size = new System.Drawing.Size(56, 18);
            this.labelEvery.TabIndex = 7;
            this.labelEvery.Text = "Every";
            this.labelEvery.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelYearNo
            // 
            this.labelYearNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelYearNo.Location = new System.Drawing.Point(129, 372);
            this.labelYearNo.Name = "labelYearNo";
            this.labelYearNo.Size = new System.Drawing.Size(59, 18);
            this.labelYearNo.TabIndex = 6;
            this.labelYearNo.Text = "Year No.";
            this.labelYearNo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelYears
            // 
            this.labelYears.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelYears.AutoSize = true;
            this.labelYears.Location = new System.Drawing.Point(558, 398);
            this.labelYears.Name = "labelYears";
            this.labelYears.Size = new System.Drawing.Size(34, 13);
            this.labelYears.TabIndex = 8;
            this.labelYears.Text = "Years";
            // 
            // tableLayoutPanelFormats
            // 
            this.tableLayoutPanelFormats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelFormats.ColumnCount = 2;
            this.tableLayoutPanelFormats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFormats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFormats.Controls.Add(this.groupBoxDisplayFormats, 0, 0);
            this.tableLayoutPanelFormats.Controls.Add(this.groupBoxFonts, 1, 0);
            this.tableLayoutPanelFormats.Location = new System.Drawing.Point(12, 422);
            this.tableLayoutPanelFormats.Name = "tableLayoutPanelFormats";
            this.tableLayoutPanelFormats.RowCount = 1;
            this.tableLayoutPanelFormats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFormats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFormats.Size = new System.Drawing.Size(580, 158);
            this.tableLayoutPanelFormats.TabIndex = 9;
            // 
            // groupBoxDisplayFormats
            // 
            this.groupBoxDisplayFormats.Controls.Add(this.buttonFormatHelp);
            this.groupBoxDisplayFormats.Controls.Add(this.textBoxSelectedDateFormat);
            this.groupBoxDisplayFormats.Controls.Add(this.labelSelectedDateFormat);
            this.groupBoxDisplayFormats.Controls.Add(this.textBoxDayOfMonthFormat);
            this.groupBoxDisplayFormats.Controls.Add(this.labelDayOfMonthFormat);
            this.groupBoxDisplayFormats.Controls.Add(this.textBoxWeekNumberFormat);
            this.groupBoxDisplayFormats.Controls.Add(this.labelWeekNumberFormat);
            this.groupBoxDisplayFormats.Controls.Add(this.textBoxWeekDayFormat);
            this.groupBoxDisplayFormats.Controls.Add(this.labelWeekDayFormat);
            this.groupBoxDisplayFormats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDisplayFormats.Location = new System.Drawing.Point(3, 3);
            this.groupBoxDisplayFormats.Name = "groupBoxDisplayFormats";
            this.groupBoxDisplayFormats.Size = new System.Drawing.Size(284, 152);
            this.groupBoxDisplayFormats.TabIndex = 0;
            this.groupBoxDisplayFormats.TabStop = false;
            this.groupBoxDisplayFormats.Text = "Display Formats";
            // 
            // buttonFormatHelp
            // 
            this.buttonFormatHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFormatHelp.Location = new System.Drawing.Point(203, 123);
            this.buttonFormatHelp.Name = "buttonFormatHelp";
            this.buttonFormatHelp.Size = new System.Drawing.Size(75, 23);
            this.buttonFormatHelp.TabIndex = 8;
            this.buttonFormatHelp.Text = "Help";
            this.buttonFormatHelp.UseVisualStyleBackColor = true;
            this.buttonFormatHelp.Click += new System.EventHandler(this.buttonFormatHelp_Click);
            // 
            // textBoxSelectedDateFormat
            // 
            this.textBoxSelectedDateFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSelectedDateFormat.Location = new System.Drawing.Point(93, 97);
            this.textBoxSelectedDateFormat.Name = "textBoxSelectedDateFormat";
            this.textBoxSelectedDateFormat.Size = new System.Drawing.Size(185, 20);
            this.textBoxSelectedDateFormat.TabIndex = 7;
            // 
            // labelSelectedDateFormat
            // 
            this.labelSelectedDateFormat.Location = new System.Drawing.Point(6, 97);
            this.labelSelectedDateFormat.Name = "labelSelectedDateFormat";
            this.labelSelectedDateFormat.Size = new System.Drawing.Size(81, 20);
            this.labelSelectedDateFormat.TabIndex = 6;
            this.labelSelectedDateFormat.Text = "Selected Date:";
            this.labelSelectedDateFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxDayOfMonthFormat
            // 
            this.textBoxDayOfMonthFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDayOfMonthFormat.Location = new System.Drawing.Point(93, 71);
            this.textBoxDayOfMonthFormat.Name = "textBoxDayOfMonthFormat";
            this.textBoxDayOfMonthFormat.Size = new System.Drawing.Size(185, 20);
            this.textBoxDayOfMonthFormat.TabIndex = 5;
            // 
            // labelDayOfMonthFormat
            // 
            this.labelDayOfMonthFormat.Location = new System.Drawing.Point(6, 71);
            this.labelDayOfMonthFormat.Name = "labelDayOfMonthFormat";
            this.labelDayOfMonthFormat.Size = new System.Drawing.Size(81, 20);
            this.labelDayOfMonthFormat.TabIndex = 4;
            this.labelDayOfMonthFormat.Text = "Day of Month:";
            this.labelDayOfMonthFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxWeekNumberFormat
            // 
            this.textBoxWeekNumberFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWeekNumberFormat.Location = new System.Drawing.Point(93, 45);
            this.textBoxWeekNumberFormat.Name = "textBoxWeekNumberFormat";
            this.textBoxWeekNumberFormat.Size = new System.Drawing.Size(185, 20);
            this.textBoxWeekNumberFormat.TabIndex = 3;
            // 
            // labelWeekNumberFormat
            // 
            this.labelWeekNumberFormat.Location = new System.Drawing.Point(6, 45);
            this.labelWeekNumberFormat.Name = "labelWeekNumberFormat";
            this.labelWeekNumberFormat.Size = new System.Drawing.Size(81, 20);
            this.labelWeekNumberFormat.TabIndex = 2;
            this.labelWeekNumberFormat.Text = "Week Number:";
            this.labelWeekNumberFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxWeekDayFormat
            // 
            this.textBoxWeekDayFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWeekDayFormat.Location = new System.Drawing.Point(93, 19);
            this.textBoxWeekDayFormat.Name = "textBoxWeekDayFormat";
            this.textBoxWeekDayFormat.Size = new System.Drawing.Size(185, 20);
            this.textBoxWeekDayFormat.TabIndex = 1;
            // 
            // labelWeekDayFormat
            // 
            this.labelWeekDayFormat.Location = new System.Drawing.Point(6, 19);
            this.labelWeekDayFormat.Name = "labelWeekDayFormat";
            this.labelWeekDayFormat.Size = new System.Drawing.Size(72, 20);
            this.labelWeekDayFormat.TabIndex = 0;
            this.labelWeekDayFormat.Text = "Weekday:";
            this.labelWeekDayFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxFonts
            // 
            this.groupBoxFonts.Controls.Add(this.buttonSelectedDateFont);
            this.groupBoxFonts.Controls.Add(this.buttonDayOfMonthFont);
            this.groupBoxFonts.Controls.Add(this.buttonWeekNumberFont);
            this.groupBoxFonts.Controls.Add(this.buttonWeekDayFont);
            this.groupBoxFonts.Controls.Add(this.labelSelectedDateSample);
            this.groupBoxFonts.Controls.Add(this.labelWeekDaySample);
            this.groupBoxFonts.Controls.Add(this.labelDayOfMonthSample);
            this.groupBoxFonts.Controls.Add(this.labelWeekNumberSample);
            this.groupBoxFonts.Controls.Add(this.labelSelectedDateFont);
            this.groupBoxFonts.Controls.Add(this.labelWeekDayFont);
            this.groupBoxFonts.Controls.Add(this.labelDayOfMonthFont);
            this.groupBoxFonts.Controls.Add(this.labelWeekNumberFont);
            this.groupBoxFonts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFonts.Location = new System.Drawing.Point(293, 3);
            this.groupBoxFonts.Name = "groupBoxFonts";
            this.groupBoxFonts.Size = new System.Drawing.Size(284, 152);
            this.groupBoxFonts.TabIndex = 1;
            this.groupBoxFonts.TabStop = false;
            this.groupBoxFonts.Text = "Display Fonts";
            // 
            // buttonSelectedDateFont
            // 
            this.buttonSelectedDateFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectedDateFont.Location = new System.Drawing.Point(203, 106);
            this.buttonSelectedDateFont.Name = "buttonSelectedDateFont";
            this.buttonSelectedDateFont.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectedDateFont.TabIndex = 19;
            this.buttonSelectedDateFont.Text = "Change";
            this.buttonSelectedDateFont.UseVisualStyleBackColor = true;
            this.buttonSelectedDateFont.Click += new System.EventHandler(this.buttonChangeFont_Click);
            // 
            // buttonDayOfMonthFont
            // 
            this.buttonDayOfMonthFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDayOfMonthFont.Location = new System.Drawing.Point(203, 77);
            this.buttonDayOfMonthFont.Name = "buttonDayOfMonthFont";
            this.buttonDayOfMonthFont.Size = new System.Drawing.Size(75, 23);
            this.buttonDayOfMonthFont.TabIndex = 18;
            this.buttonDayOfMonthFont.Text = "Change";
            this.buttonDayOfMonthFont.UseVisualStyleBackColor = true;
            this.buttonDayOfMonthFont.Click += new System.EventHandler(this.buttonChangeFont_Click);
            // 
            // buttonWeekNumberFont
            // 
            this.buttonWeekNumberFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWeekNumberFont.Location = new System.Drawing.Point(203, 48);
            this.buttonWeekNumberFont.Name = "buttonWeekNumberFont";
            this.buttonWeekNumberFont.Size = new System.Drawing.Size(75, 23);
            this.buttonWeekNumberFont.TabIndex = 17;
            this.buttonWeekNumberFont.Text = "Change";
            this.buttonWeekNumberFont.UseVisualStyleBackColor = true;
            this.buttonWeekNumberFont.Click += new System.EventHandler(this.buttonChangeFont_Click);
            // 
            // buttonWeekDayFont
            // 
            this.buttonWeekDayFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWeekDayFont.Location = new System.Drawing.Point(203, 19);
            this.buttonWeekDayFont.Name = "buttonWeekDayFont";
            this.buttonWeekDayFont.Size = new System.Drawing.Size(75, 23);
            this.buttonWeekDayFont.TabIndex = 16;
            this.buttonWeekDayFont.Text = "Change";
            this.buttonWeekDayFont.UseVisualStyleBackColor = true;
            this.buttonWeekDayFont.Click += new System.EventHandler(this.buttonChangeFont_Click);
            // 
            // labelSelectedDateSample
            // 
            this.labelSelectedDateSample.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSelectedDateSample.Location = new System.Drawing.Point(86, 107);
            this.labelSelectedDateSample.Name = "labelSelectedDateSample";
            this.labelSelectedDateSample.Size = new System.Drawing.Size(111, 20);
            this.labelSelectedDateSample.TabIndex = 15;
            this.labelSelectedDateSample.Text = "Sample";
            this.labelSelectedDateSample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelWeekDaySample
            // 
            this.labelWeekDaySample.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWeekDaySample.Location = new System.Drawing.Point(86, 20);
            this.labelWeekDaySample.Name = "labelWeekDaySample";
            this.labelWeekDaySample.Size = new System.Drawing.Size(111, 20);
            this.labelWeekDaySample.TabIndex = 12;
            this.labelWeekDaySample.Text = "Sample";
            this.labelWeekDaySample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDayOfMonthSample
            // 
            this.labelDayOfMonthSample.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDayOfMonthSample.Location = new System.Drawing.Point(86, 78);
            this.labelDayOfMonthSample.Name = "labelDayOfMonthSample";
            this.labelDayOfMonthSample.Size = new System.Drawing.Size(111, 20);
            this.labelDayOfMonthSample.TabIndex = 14;
            this.labelDayOfMonthSample.Text = "Sample";
            this.labelDayOfMonthSample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelWeekNumberSample
            // 
            this.labelWeekNumberSample.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWeekNumberSample.Location = new System.Drawing.Point(86, 49);
            this.labelWeekNumberSample.Name = "labelWeekNumberSample";
            this.labelWeekNumberSample.Size = new System.Drawing.Size(111, 20);
            this.labelWeekNumberSample.TabIndex = 13;
            this.labelWeekNumberSample.Text = "Sample";
            this.labelWeekNumberSample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSelectedDateFont
            // 
            this.labelSelectedDateFont.Location = new System.Drawing.Point(6, 107);
            this.labelSelectedDateFont.Name = "labelSelectedDateFont";
            this.labelSelectedDateFont.Size = new System.Drawing.Size(82, 20);
            this.labelSelectedDateFont.TabIndex = 11;
            this.labelSelectedDateFont.Text = "Selected Date:";
            this.labelSelectedDateFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelWeekDayFont
            // 
            this.labelWeekDayFont.Location = new System.Drawing.Point(6, 20);
            this.labelWeekDayFont.Name = "labelWeekDayFont";
            this.labelWeekDayFont.Size = new System.Drawing.Size(63, 20);
            this.labelWeekDayFont.TabIndex = 9;
            this.labelWeekDayFont.Text = "Weekday:";
            this.labelWeekDayFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDayOfMonthFont
            // 
            this.labelDayOfMonthFont.Location = new System.Drawing.Point(6, 78);
            this.labelDayOfMonthFont.Name = "labelDayOfMonthFont";
            this.labelDayOfMonthFont.Size = new System.Drawing.Size(82, 20);
            this.labelDayOfMonthFont.TabIndex = 10;
            this.labelDayOfMonthFont.Text = "Day of Month:";
            this.labelDayOfMonthFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelWeekNumberFont
            // 
            this.labelWeekNumberFont.Location = new System.Drawing.Point(6, 49);
            this.labelWeekNumberFont.Name = "labelWeekNumberFont";
            this.labelWeekNumberFont.Size = new System.Drawing.Size(82, 20);
            this.labelWeekNumberFont.TabIndex = 9;
            this.labelWeekNumberFont.Text = "Week Number:";
            this.labelWeekNumberFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(517, 586);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Location = new System.Drawing.Point(436, 586);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 621);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.tableLayoutPanelFormats);
            this.Controls.Add(this.labelYears);
            this.Controls.Add(this.labelEvery);
            this.Controls.Add(this.labelYearNo);
            this.Controls.Add(this.numericUpDownLeapYearTimeSpan);
            this.Controls.Add(this.labelLeapYearTimeSpan);
            this.Controls.Add(this.numericUpDownFirstLeapYear);
            this.Controls.Add(this.labelFirstLeapYear);
            this.Controls.Add(this.tableLayoutPanelGridViews);
            this.Controls.Add(this.labelSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(620, 660);
            this.Name = "SettingsWindow";
            this.Text = "Custom Calendar - Settings";
            this.tableLayoutPanelGridViews.ResumeLayout(false);
            this.groupBoxMonths.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMonths)).EndInit();
            this.groupBoxWeekDays.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeekDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFirstLeapYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLeapYearTimeSpan)).EndInit();
            this.tableLayoutPanelFormats.ResumeLayout(false);
            this.groupBoxDisplayFormats.ResumeLayout(false);
            this.groupBoxDisplayFormats.PerformLayout();
            this.groupBoxFonts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGridViews;
        private System.Windows.Forms.GroupBox groupBoxMonths;
        private System.Windows.Forms.GroupBox groupBoxWeekDays;
        private System.Windows.Forms.DataGridView dataGridViewMonths;
        private System.Windows.Forms.DataGridView dataGridViewWeekDays;
        private System.Windows.Forms.Label labelFirstLeapYear;
        private System.Windows.Forms.NumericUpDown numericUpDownFirstLeapYear;
        private System.Windows.Forms.NumericUpDown numericUpDownLeapYearTimeSpan;
        private System.Windows.Forms.Label labelLeapYearTimeSpan;
        private System.Windows.Forms.Label labelEvery;
        private System.Windows.Forms.Label labelYearNo;
        private System.Windows.Forms.Label labelYears;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFormats;
        private System.Windows.Forms.GroupBox groupBoxDisplayFormats;
        private System.Windows.Forms.GroupBox groupBoxFonts;
        private System.Windows.Forms.Button buttonMinusMonths;
        private System.Windows.Forms.Button buttonPlusMonth;
        private System.Windows.Forms.Button buttonMinusWeekDays;
        private System.Windows.Forms.Button buttonPlusWeekDays;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelWeekDayFormat;
        private System.Windows.Forms.TextBox textBoxWeekDayFormat;
        private System.Windows.Forms.TextBox textBoxWeekNumberFormat;
        private System.Windows.Forms.Label labelWeekNumberFormat;
        private System.Windows.Forms.TextBox textBoxDayOfMonthFormat;
        private System.Windows.Forms.Label labelDayOfMonthFormat;
        private System.Windows.Forms.TextBox textBoxSelectedDateFormat;
        private System.Windows.Forms.Label labelSelectedDateFormat;
        private System.Windows.Forms.Button buttonFormatHelp;
        private System.Windows.Forms.Label labelSelectedDateFont;
        private System.Windows.Forms.Label labelWeekDayFont;
        private System.Windows.Forms.Label labelDayOfMonthFont;
        private System.Windows.Forms.Label labelWeekNumberFont;
        private System.Windows.Forms.Button buttonSelectedDateFont;
        private System.Windows.Forms.Button buttonDayOfMonthFont;
        private System.Windows.Forms.Button buttonWeekNumberFont;
        private System.Windows.Forms.Button buttonWeekDayFont;
        private System.Windows.Forms.Label labelSelectedDateSample;
        private System.Windows.Forms.Label labelWeekDaySample;
        private System.Windows.Forms.Label labelDayOfMonthSample;
        private System.Windows.Forms.Label labelWeekNumberSample;
        private System.Windows.Forms.Button buttonClearMonhts;
        private System.Windows.Forms.Button buttonClearWeekDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeekDayNameShort;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeekDayName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HasLeapDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonthNameShort;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonthName;
    }
}