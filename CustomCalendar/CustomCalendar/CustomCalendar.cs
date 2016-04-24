using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using CustomCalendarApplication.Properties;

namespace CustomCalendarApplication
{
    public partial class CustomCalendar : UserControl
    {
        protected CalendarProperties Properties = new CalendarProperties();

        // Contains helper data for working with months
        protected List<MonthHelperdata> MonthHelpers = new List<MonthHelperdata>();


        public int SelectedMonthIndex
        {
            get { return comboBoxMonth.SelectedIndex; }
            set
            {
                if (value >= 0 && value < comboBoxMonth.Items.Count)
                {
                    comboBoxMonth.SelectedIndex = value;
                }
            }
        }

        public int SelectedYear
        {
            get { return (int)numericUpDownYear.Value; }
            set
            {
                if (value >= numericUpDownYear.Minimum && value <= numericUpDownYear.Maximum)
                {
                    numericUpDownYear.Value = value;
                }
            }
        }


        public CustomCalendar()
        {
            InitializeComponent();

            Properties.InitializeToDefault();

            if (Settings.Default.CalendarSettings != null)
            {
                Properties = Settings.Default.CalendarSettings;
            }

            UpdateCalendar();
        }

        protected void UpdateCalendar()
        {
            // Update month helpers
            MonthHelpers.Clear();
            ulong prevMonthAccumulatedDaysRegularYear = 0;
            ulong prevMonthAccumulatedDaysLeapYear = 0;

            for (int i = 0; i < Properties.Months.Count; i++)
            {
                uint numDaysRegularYear = Properties.Months[i].NumberOfDays;
                uint numDaysLeapYear = Properties.Months[i].NumberOfDays + (Properties.Months[i].HasLeapDay ? (uint)1 : (uint)0);
                ulong accumulatedDaysRegularYear = prevMonthAccumulatedDaysRegularYear + numDaysRegularYear;
                ulong accumulatedDaysLeapYear = prevMonthAccumulatedDaysLeapYear + numDaysLeapYear;

                MonthHelpers.Add(new MonthHelperdata(numDaysRegularYear, numDaysLeapYear, accumulatedDaysRegularYear, accumulatedDaysLeapYear));

                prevMonthAccumulatedDaysRegularYear = accumulatedDaysRegularYear;
                prevMonthAccumulatedDaysLeapYear = accumulatedDaysLeapYear;
            }

            // Add months
            int lastSelectedMonth = comboBoxMonth.SelectedIndex;

            comboBoxMonth.Items.Clear();
            uint largestPossibleMonth = 0;

            for (int i = 0; i < Properties.Months.Count; i++)
            {
                comboBoxMonth.Items.Add(Properties.Months[i].FullName);
                uint MaxDaysInMonth = Properties.Months[i].NumberOfDays + (Properties.Months[i].HasLeapDay ? (uint)1 : (uint)0);
                if (MaxDaysInMonth > largestPossibleMonth)
                {
                    largestPossibleMonth = MaxDaysInMonth;
                }
            }

            if (lastSelectedMonth > comboBoxMonth.Items.Count)
            {
                comboBoxMonth.SelectedIndex = comboBoxMonth.Items.Count - 1;
            }
            else if (lastSelectedMonth < 0 && comboBoxMonth.Items.Count > 0)
            {
                comboBoxMonth.SelectedIndex = 0;
            }
            else if (comboBoxMonth.Items.Count <= 0)
            {
                comboBoxMonth.SelectedIndex = -1;
            }
            else
            {
                comboBoxMonth.SelectedIndex = lastSelectedMonth;
            }

            // Update grid view
            int columnCount = Properties.WeekDays.Count + 1;
            int largestPossibleMonthPlusShift = (int)(largestPossibleMonth + Properties.WeekDays.Count - 1);
            int rowCount = (largestPossibleMonthPlusShift / Properties.WeekDays.Count) + 1 + (largestPossibleMonthPlusShift % Properties.WeekDays.Count != 0 ? 1 : 0);
            tableLayoutPanelDates.ColumnCount = columnCount;
            tableLayoutPanelDates.RowCount = rowCount;

            tableLayoutPanelDates.ColumnStyles.Clear();
            for (int i = 0; i < columnCount; i++)
            {
                tableLayoutPanelDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (1.0f / (float)columnCount) * 100.0f));
            }

            tableLayoutPanelDates.RowStyles.Clear();
            for (int i = 0; i < rowCount; i++)
            {
                tableLayoutPanelDates.RowStyles.Add(new RowStyle(SizeType.Percent, (1.0f / (float)rowCount) * 100.0f));
            }

            // Add week day names as stubs
            tableLayoutPanelDates.Controls.Clear();
            for (int i = 0; i < Properties.WeekDays.Count; i++)
            {
                Label weekDayLabel = new Label();
                weekDayLabel.Text = "";
                weekDayLabel.AutoSize = false;
                weekDayLabel.TextAlign = ContentAlignment.MiddleCenter;
                weekDayLabel.Font = Properties.WeekDayFont;
                tableLayoutPanelDates.Controls.Add(weekDayLabel, i + 1, 0);
                weekDayLabel.Dock = DockStyle.Fill;
            }

            // Add calendar weeks as stubs
            for (int i = 1; i < tableLayoutPanelDates.RowCount; i++)
            {
                Label weekLabel = new Label();
                weekLabel.Text = "";
                weekLabel.AutoSize = false;
                weekLabel.TextAlign = ContentAlignment.MiddleCenter;
                weekLabel.Font = Properties.WeekNumberFont;
                tableLayoutPanelDates.Controls.Add(weekLabel, 0, i);
                weekLabel.Dock = DockStyle.Fill;
            }

            // Add dates as stubs
            for (int i = 1; i < tableLayoutPanelDates.ColumnCount; i++)
            {
                for (int j = 1; j < tableLayoutPanelDates.RowCount; j++)
                {
                    DateButton dateButton = new DateButton();
                    dateButton.DayNumber = 0;
                    dateButton.BelongsToCurrentMonth = true;
                    dateButton.Font = Properties.DayOfMonthFont;
                    dateButton.Enter += dateButton_Focused;
                    dateButton.Leave += dateButton_Leave;
                    tableLayoutPanelDates.Controls.Add(dateButton, i, j);
                    dateButton.Dock = DockStyle.Fill;
                }
            }

            labelSelectedDate.Font = Properties.SelectedDateFont;

            UpdateMonth();
        }

        protected ulong CalculateNumDaysInYearUntilMonth(uint month, bool isLeapYear)
        {
            if (!isLeapYear)
            {
                return MonthHelpers[(int)month].AccumulatedDaysRegularYear - MonthHelpers[(int)month].NumDaysRegularYear;
            }
            else
            {
                return MonthHelpers[(int)month].AccumulatedDaysLeapYear - MonthHelpers[(int)month].NumDaysLeapYear;
            }

        }

        // Calculate the total number of days that need to pass until the passed date is reached
        // currentMonth and currentDay use base 0 instead of base 1 (currentYear is already 0-based, anyways)
        protected ulong CalculateTotalNumDays(uint currentYear, uint currentMonth, uint currentDay)
        {
            int leapYearShift = (int)Properties.LeapYearSpan - (int)(Properties.FirstLeapYear + 1);
            uint yearPlusShift = (uint)Math.Max(0, (int)currentYear + leapYearShift);
            uint numLeapYears = (yearPlusShift / Properties.LeapYearSpan);
            uint numRegularYears = currentYear - numLeapYears;

            bool currentYearIsLeapYear = (currentYear >= Properties.FirstLeapYear && (yearPlusShift + 1) % Properties.LeapYearSpan == 0);

            return (numRegularYears * MonthHelpers.Last().AccumulatedDaysRegularYear)
                + (numLeapYears * MonthHelpers.Last().AccumulatedDaysLeapYear)
                + CalculateNumDaysInYearUntilMonth(currentMonth, currentYearIsLeapYear)
                + currentDay;
        }


        // Calculates the current year from the total number of days passed
        protected uint CalculateYearFromTotalNumDays(ulong numDays, ref ulong remainingDays)
        {
            int leapYearShift = (int)Properties.LeapYearSpan - (int)(Properties.FirstLeapYear + 1);
            ulong totalNumConsecutiveDaysRegularYears = (Properties.LeapYearSpan - 1) * MonthHelpers.Last().AccumulatedDaysRegularYear;
            ulong leapYearDaySpan = MonthHelpers.Last().AccumulatedDaysLeapYear + totalNumConsecutiveDaysRegularYears;
            ulong daysPlusShift = (uint)Math.Max(0, (int)numDays + (leapYearShift * (int)MonthHelpers.Last().AccumulatedDaysRegularYear));

            uint numLeapYears = (uint)(daysPlusShift / leapYearDaySpan);

            bool currentYearIsLeapYear = (daysPlusShift % leapYearDaySpan >= totalNumConsecutiveDaysRegularYears);

            ulong daysWithoutCompletedLeapYears = numDays - (numLeapYears * MonthHelpers.Last().AccumulatedDaysLeapYear);

            if (currentYearIsLeapYear)
            {
                // Make sure a current leap year doesn't throw off our calculation
                daysWithoutCompletedLeapYears -= ((daysPlusShift % leapYearDaySpan) - totalNumConsecutiveDaysRegularYears);
            }

            uint numRegularYears = (uint)(daysWithoutCompletedLeapYears / MonthHelpers.Last().AccumulatedDaysRegularYear);

            uint returnYear = (uint)(numRegularYears + numLeapYears);

            remainingDays = numDays
                - ((numRegularYears * MonthHelpers.Last().AccumulatedDaysRegularYear)
                + (numLeapYears * MonthHelpers.Last().AccumulatedDaysLeapYear));

            return returnYear;
        }

        protected uint CalculateYearFromTotalNumDays(ulong numDays)
        {
            ulong unused = 0;
            return CalculateYearFromTotalNumDays(numDays, ref unused);
        }


        // Calculates the current month from the total number of days passed (a 0-based result is returned)
        protected uint CalculateMonthFromTotalNumDays(ulong numDays, ref ulong remainingDays)
        {
            ulong remainingDaysCurrentYear = 0;

            uint currentYear = CalculateYearFromTotalNumDays(numDays, ref remainingDaysCurrentYear);

            int leapYearShift = (int)Properties.LeapYearSpan - (int)(Properties.FirstLeapYear + 1);
            uint yearPlusShift = (uint)Math.Max(0, (int)currentYear + leapYearShift);

            bool currentYearIsLeapYear = (currentYear >= Properties.FirstLeapYear && (yearPlusShift + 1) % Properties.LeapYearSpan == 0);

            for (int i = 0; i < MonthHelpers.Count; i++)
            {
                if (!currentYearIsLeapYear)
                {
                    if (remainingDaysCurrentYear < MonthHelpers[i].AccumulatedDaysRegularYear)
                    {
                        remainingDays = remainingDaysCurrentYear
                            - CalculateNumDaysInYearUntilMonth((uint)i, currentYearIsLeapYear);
                        return (uint)i;
                    }
                }
                else
                {
                    if (remainingDaysCurrentYear < MonthHelpers[i].AccumulatedDaysLeapYear)
                    {
                        remainingDays = remainingDaysCurrentYear
                            - CalculateNumDaysInYearUntilMonth((uint)i, currentYearIsLeapYear);
                        return (uint)i;
                    }
                }
            }

            // We should never get here - if we do, something went wrong
            System.Diagnostics.Debug.Print("[Error] We reached a code path in CalculateMonthFromTotalNumDays() that should not be reached.\n        Parameters:\n            numDays = " + numDays.ToString() + "\n");
            remainingDays = 0;
            return 0;
        }

        protected uint CalculateMonthFromTotalNumDays(ulong numDays)
        {
            ulong unused = 0;
            return CalculateMonthFromTotalNumDays(numDays, ref unused);
        }


        // Calculates the current day of month from the total number of days passed (a 0-based result is returned)
        protected uint CalculateDayOfMonthFromTotalNumDays(ulong numDays)
        {
            ulong remainingDaysCurrentMonth = 0;

            CalculateMonthFromTotalNumDays(numDays, ref remainingDaysCurrentMonth);

            return (uint)remainingDaysCurrentMonth;
        }


        // Calculates the current week number from the total number of days (a 0-based result is returned)
        protected uint CalculateWeekOfYearFromTotalNumDays(ulong numDays)
        {
            ulong remainingDaysInCurrentYear = 0;
            uint currentYear = CalculateYearFromTotalNumDays(numDays - (numDays % (uint)Properties.WeekDays.Count), ref remainingDaysInCurrentYear);
            ulong totalDaysUntilStartOfYear = numDays - remainingDaysInCurrentYear;

            ulong remainingDaysInNextYear = 0;
            ulong projectedDayNextYear = numDays - (numDays % (uint)Properties.WeekDays.Count) + (uint)Properties.WeekDays.Count - 1;
            uint nextYear = CalculateYearFromTotalNumDays(projectedDayNextYear, ref remainingDaysInNextYear);

            if (nextYear > currentYear && (projectedDayNextYear - remainingDaysInNextYear) % (uint)Properties.WeekDays.Count < (float)Properties.WeekDays.Count / 2)
            {
                return 0;
            }

            if (totalDaysUntilStartOfYear % (uint)Properties.WeekDays.Count >= (float)Properties.WeekDays.Count / 2)
            {
                return (uint)(remainingDaysInCurrentYear / (uint)Properties.WeekDays.Count);
            }

            return (uint)((remainingDaysInCurrentYear + (uint)Properties.WeekDays.Count - 1) / (uint)Properties.WeekDays.Count);
        }


        protected void UpdateMonth()
        {
            uint currentYear = (uint)numericUpDownYear.Value;
            uint currentMonth = (uint)Math.Max(0, comboBoxMonth.SelectedIndex);

            int leapYearShift = (int)Properties.LeapYearSpan - (int)(Properties.FirstLeapYear + 1);
            uint yearPlusShift = (uint)Math.Max(0, (int)currentYear + leapYearShift);
            bool currentYearIsLeapYear = (currentYear >= Properties.FirstLeapYear && (yearPlusShift + 1) % Properties.LeapYearSpan == 0);

            ulong totalDaysUntilMonth = CalculateTotalNumDays(currentYear, currentMonth, 0);
            ulong totalDaysUntilDisplayedMonth = totalDaysUntilMonth - (totalDaysUntilMonth % (uint)Properties.WeekDays.Count);
            ulong totalDaysUntilNextMonth = totalDaysUntilMonth
                + (!currentYearIsLeapYear ? MonthHelpers[(int)currentMonth].NumDaysRegularYear : MonthHelpers[(int)currentMonth].NumDaysLeapYear);

            // Add week days, calendar weeks and days of month
            for (int i = 0; i < tableLayoutPanelDates.RowCount; i++)
            {
                for (int j = 0; j < tableLayoutPanelDates.ColumnCount; j++)
                {
                    if (i == 0 && j > 0)
                    {
                        // Week days
                        Label weekDayLabel = tableLayoutPanelDates.GetControlFromPosition(j, i) as Label;
                        if (weekDayLabel != null)
                        {
                            weekDayLabel.Text = Properties.WeekDayFormat.Inject(new CalendarTokens(this, totalDaysUntilDisplayedMonth + (ulong)j - 1));
                        }
                    }
                    else if (j == 0 && i > 0)
                    {
                        // Calendar week
                        Label weekLabel = tableLayoutPanelDates.GetControlFromPosition(j, i) as Label;
                        if (weekLabel != null)
                        {
                            weekLabel.Text = Properties.WeekNumberFormat.Inject(new CalendarTokens(this, totalDaysUntilDisplayedMonth));
                        }
                    }
                    else if (j > 0 && i > 0)
                    {
                        // Month day
                        DateButton dateButton = tableLayoutPanelDates.GetControlFromPosition(j, i) as DateButton;
                        if (dateButton != null)
                        {
                            uint dayOfMonth = CalculateDayOfMonthFromTotalNumDays(totalDaysUntilDisplayedMonth);
                            dateButton.DayNumber = dayOfMonth + 1;
                            dateButton.DayNumberFormat = Properties.DayOfMonthFormat;
                            dateButton.InjectionObject = new CalendarTokens(this, totalDaysUntilDisplayedMonth);
                            if (totalDaysUntilDisplayedMonth < totalDaysUntilMonth || totalDaysUntilDisplayedMonth >= totalDaysUntilNextMonth)
                            {
                                dateButton.BelongsToCurrentMonth = false;
                            }
                            else
                            {
                                dateButton.BelongsToCurrentMonth = true;
                            }
                        }

                        totalDaysUntilDisplayedMonth++;
                    }

                }
            }

            //UpdateDay();
        }

        protected void UpdateDay()
        {

        }

        private void numericUpDownYear_ValueChanged(object sender, EventArgs e)
        {
            UpdateMonth();
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMonth();
        }

        private void buttonArrowLeft_Click(object sender, EventArgs e)
        {
            int currentMonth = comboBoxMonth.SelectedIndex;

            currentMonth--;

            if (currentMonth < 0)
            {
                if (numericUpDownYear.Value > numericUpDownYear.Minimum)
                {
                    numericUpDownYear.Value--;
                    comboBoxMonth.SelectedIndex = comboBoxMonth.Items.Count - 1;
                }
            }
            else
            {
                comboBoxMonth.SelectedIndex = currentMonth;
            }
        }

        private void buttonArrowRight_Click(object sender, EventArgs e)
        {
            int currentMonth = comboBoxMonth.SelectedIndex;

            currentMonth++;

            if (currentMonth >= comboBoxMonth.Items.Count)
            {
                if (numericUpDownYear.Value < numericUpDownYear.Maximum)
                {
                    numericUpDownYear.Value++;
                    if (comboBoxMonth.Items.Count > 0)
                        comboBoxMonth.SelectedIndex = 0;
                    else
                        comboBoxMonth.SelectedIndex = -1;
                }
            }
            else
            {
                comboBoxMonth.SelectedIndex = currentMonth;
            }
        }

        private void dateButton_Focused(object sender, EventArgs e)
        {
            DateButton dateButton = sender as DateButton;

            if (dateButton != null)
            {
                CalendarTokens tokens = dateButton.InjectionObject as CalendarTokens;

                if (tokens != null)
                {
                    labelSelectedDate.Text = Properties.SelectedDateFormat.Inject(tokens);
                }
            }
        }

        private void dateButton_Leave(object sender, EventArgs e)
        {
            labelSelectedDate.Text = "";
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow(Properties);

            if (settingsWindow.ShowDialog() == DialogResult.OK)
            {
                Properties = settingsWindow.CalendarProperties;

                UpdateCalendar();

                Settings.Default.CalendarSettings = Properties;
                Settings.Default.Save();
            }
        }


        // A class containing all the properties that can be used for displaying dates
        class CalendarTokens
        {
            // The current year
            private uint _Year = 0;
            public uint Year
            {
                get { return _Year; }
                set { _Year = value; }
            }

            // The name of the current month
            private string _Month = "";
            public string Month
            {
                get { return _Month; }
                set { _Month = value; }
            }

            // The name of the current month (short version)
            private string _MonthShort = "";
            public string MonthShort
            {
                get { return _MonthShort; }
                set { _MonthShort = value; }
            }

            // The numeric representation of the current month (1-based)
            private uint _MonthNumeric = 1;
            public uint MonthNumeric
            {
                get { return _MonthNumeric; }
                set { _MonthNumeric = value; }
            }

            // The day of the current month (1-based)
            private uint _DayOfMonth = 1;
            public uint DayOfMonth
            {
                get { return _DayOfMonth; }
                set { _DayOfMonth = value; }
            }

            // The current calendar week (1-based)
            private uint _CalendarWeek = 1;
            public uint CalendarWeek
            {
                get { return _CalendarWeek; }
                set { _CalendarWeek = value; }
            }

            // The name of the current day of the week
            private string _WeekDay = "";
            public string WeekDay
            {
                get { return _WeekDay; }
                set { _WeekDay = value; }
            }

            // The name of the current day of the week (short version)
            private string _WeekDayShort = "";
            public string WeekDayShort
            {
                get { return _WeekDayShort; }
                set { _WeekDayShort = value; }
            }

            // The numeric representation of the current day of the week (1-based)
            private uint _WeekDayNumeric = 1;
            public uint WeekDayNumeric
            {
                get { return _WeekDayNumeric; }
                set { _WeekDayNumeric = value; }
            }

            // The total day number (from the beginning of the calendar, 1-based)
            private ulong _TotalDay = 1;
            public ulong TotalDay
            {
                get { return _TotalDay; }
                set { _TotalDay = value; }
            }

            // The day of the current year (1-based)
            private ulong _DayOfYear = 1;
            public ulong DayOfYear
            {
                get { return _DayOfYear; }
                set { _DayOfYear = value; }
            }


            public CalendarTokens(CustomCalendar calendar, ulong currentTotalDay)
            {
                _TotalDay = currentTotalDay + 1;

                ulong remainingDaysInYear = 0;
                _Year = calendar.CalculateYearFromTotalNumDays(currentTotalDay, ref remainingDaysInYear);

                _DayOfYear = remainingDaysInYear + 1;

                ulong remainingDaysInMonth = 0;
                uint currentMonth = calendar.CalculateMonthFromTotalNumDays(currentTotalDay, ref remainingDaysInMonth);

                if (currentMonth < calendar.Properties.Months.Count)
                {
                    _Month = calendar.Properties.Months[(int)currentMonth].FullName;
                    _MonthShort = calendar.Properties.Months[(int)currentMonth].ShortName;
                }

                _MonthNumeric = currentMonth + 1;
                _DayOfMonth = (uint)remainingDaysInMonth + 1;

                _CalendarWeek = calendar.CalculateWeekOfYearFromTotalNumDays(currentTotalDay) + 1;

                if (calendar.Properties.WeekDays.Count > 0)
                {
                    uint dayOfWeek = (uint)(currentTotalDay % (uint)calendar.Properties.WeekDays.Count);

                    if (dayOfWeek < calendar.Properties.WeekDays.Count)
                    {
                        _WeekDay = calendar.Properties.WeekDays[(int)dayOfWeek].FullName;
                        _WeekDayShort = calendar.Properties.WeekDays[(int)dayOfWeek].ShortName;
                    }

                    _WeekDayNumeric = dayOfWeek + 1;
                }
            }
        }
    }


    // Contains all properties of a single month
    [Serializable]
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public class MonthProperties
    {
        // The full name of the month
        protected string _FullName = "";
        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }

        // The short name of the month
        protected string _ShortName = "";
        public string ShortName
        {
            get { return _ShortName; }
            set { _ShortName = value; }
        }

        // The number of days in a month
        protected uint _NumberOfDays = 1;
        public uint NumberOfDays
        {
            get { return _NumberOfDays; }
            set { _NumberOfDays = value; }
        }

        // Whether a month has a leap day in a leap year
        protected bool _HasLeapDay = false;
        public bool HasLeapDay
        {
            get { return _HasLeapDay; }
            set { _HasLeapDay = value; }
        }

        public MonthProperties()
        {
        }

        public MonthProperties(string FullName, string ShortName, uint NumberOfDays, bool HasLeapDay)
        {
            _FullName = FullName;
            _ShortName = ShortName;
            _NumberOfDays = NumberOfDays;
            if (_NumberOfDays == 0)
            {
                _NumberOfDays = 1;
            }
            _HasLeapDay = HasLeapDay;
        }
    }

    // Contains helper data for working with months
    public class MonthHelperdata
    {
        // The number of days in this month during a regular year
        public readonly uint NumDaysRegularYear;

        // The number of days in this month during a leap year
        public readonly uint NumDaysLeapYear;

        // The accumulated number of days in regular year after this month has passed
        public readonly ulong AccumulatedDaysRegularYear;

        // The accumulated number of days in leap year after this month has passed
        public readonly ulong AccumulatedDaysLeapYear;

        public MonthHelperdata(uint NumDaysRegularYear, uint NumDaysLeapYear, ulong AccumulatedDaysRegularYear, ulong AccumulatedDaysLeapYear)
        {
            this.NumDaysRegularYear = NumDaysRegularYear;
            this.NumDaysLeapYear = NumDaysLeapYear;
            this.AccumulatedDaysRegularYear = AccumulatedDaysRegularYear;
            this.AccumulatedDaysLeapYear = AccumulatedDaysLeapYear;
        }
    }

    // Contains all propertes of a single week day
    [Serializable]
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public class WeekDayProperties
    {
        // The full name of the week day
        protected string _FullName = "";
        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }

        // The short name of the week day
        protected string _ShortName = "";
        public string ShortName
        {
            get { return _ShortName; }
            set { _ShortName = value; }
        }

        public WeekDayProperties()
        {
        }

        public WeekDayProperties(string FullName, string ShortName)
        {
            _FullName = FullName;
            _ShortName = ShortName;
        }
    }


    // A helper class for serializing and deserializing fonts
    [Serializable]
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public class SerializableFont
    {
        // The name of the font
        protected string _FontName = "Microsoft Sans Serif";
        public string FontName
        {
            get { return _FontName; }
            set { _FontName = value; }
        }

        // The font size
        protected float _FontSize = 9.0f;
        public float FontSize
        {
            get { return _FontSize; }
            set { _FontSize = value; }
        }

        // A string representing the font style
        protected string _FontStyle = "Regular";
        public string FontStyle
        {
            get { return _FontStyle; }
            set { _FontStyle = value; }
        }

        // Define conversion from font
        public static implicit operator SerializableFont(Font font)
        {
            SerializableFont serializableFont = new SerializableFont();

            serializableFont._FontName = font.Name;
            serializableFont._FontSize = font.Size;
            serializableFont._FontStyle = font.Style.ToString();

            return serializableFont;
        }

        // Define conversion to font
        public static implicit operator Font(SerializableFont serializableFont)
        {
            try
            {
                System.Drawing.FontStyle fontStyle = System.Drawing.FontStyle.Regular;

                if (Enum.TryParse(serializableFont._FontStyle, true, out fontStyle))
                {
                    Font returnFont = new Font(serializableFont._FontName, serializableFont._FontSize, fontStyle);

                    if (returnFont != null)
                    {
                        return returnFont;
                    }
                }
            }
            catch (System.Exception)
            {            	
            }

            return new Font("Microsoft Sans Serif", 9.0f, System.Drawing.FontStyle.Regular);
        }

        public SerializableFont()
        {
        }
    }


    // A wrapper class for all properties of a calendar
    [Serializable]
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public class CalendarProperties
    {
        // A list of all months
        protected List<MonthProperties> _Months = new List<MonthProperties>();
        public List<MonthProperties> Months
        {
            get { return _Months; }
            set { _Months = value; }
        }

        // A list of all week days
        protected List<WeekDayProperties> _WeekDays = new List<WeekDayProperties>();
        public List<WeekDayProperties> WeekDays
        {
            get { return _WeekDays; }
            set { _WeekDays = value; }
        }

        // The first leap year in the calendar
        protected uint _FirstLeapYear = 7;
        public uint FirstLeapYear
        {
            get { return _FirstLeapYear; }
            set { _FirstLeapYear = value; }
        }

        // After how many years each leap day occurs
        protected uint _LeapYearSpan = 15;
        public uint LeapYearSpan
        {
            get { return _LeapYearSpan; }
            set { _LeapYearSpan = value; }
        }


        // The format for displaying the week number
        protected string _WeekNumberFormat = "{CalendarWeek}.";
        public string WeekNumberFormat
        {
            get { return _WeekNumberFormat; }
            set { _WeekNumberFormat = value; }
        }

        // The format for displaying the week day
        protected string _WeekDayFormat = "{WeekDayShort}";
        public string WeekDayFormat
        {
            get { return _WeekDayFormat; }
            set { _WeekDayFormat = value; }
        }

        // The format for displaying the day of month
        protected string _DayOfMonthFormat = "{DayOfMonth}";
        public string DayOfMonthFormat
        {
            get { return _DayOfMonthFormat; }
            set { _DayOfMonthFormat = value; }
        }

        // The format for the selected date
        protected string _SelectedDateFormat = "{WeekDay} - {Month} {DayOfMonth}, {Year}";
        public string SelectedDateFormat
        {
            get { return _SelectedDateFormat; }
            set { _SelectedDateFormat = value; }
        }


        // Font for displaying week number
        protected SerializableFont _WeekNumberFont = new Font("Microsoft Sans Serif", 9.0f, FontStyle.Bold);
        public SerializableFont WeekNumberFont
        {
            get { return _WeekNumberFont; }
            set { _WeekNumberFont = value; }
        }

        // Font for displaying the week day
        protected SerializableFont _WeekDayFont = new Font("Microsoft Sans Serif", 9.0f, FontStyle.Bold);
        public SerializableFont WeekDayFont
        {
            get { return _WeekDayFont; }
            set { _WeekDayFont = value; }
        }

        // Font for displaying the day of month
        protected SerializableFont _DayOfMonthFont = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold);
        public SerializableFont DayOfMonthFont
        {
            get { return _DayOfMonthFont; }
            set { _DayOfMonthFont = value; }
        }

        // Font for displaying the selected date
        protected SerializableFont _SelectedDateFont = new Font("Microsoft Sans Serif", 10.0f, FontStyle.Bold);
        public SerializableFont SelectedDateFont
        {
            get { return _SelectedDateFont; }
            set { _SelectedDateFont = value; }
        }


        public CalendarProperties()
        {
        }

        public void InitializeToDefault()
        {
            _Months = new List<MonthProperties>()
            {
                new MonthProperties("Neinuar", "Nein", 27, false),
                new MonthProperties("Fabruar", "Fabr", 26, false),
                new MonthProperties("Määäährz", "Mäh", 26, false),
                new MonthProperties("Apriiiiil", "Apr", 27, true),
                new MonthProperties("Yum", "Yum", 26, false),
                new MonthProperties("Loonie", "Loo", 26, false),
                new MonthProperties("Toonie", "Too", 27, false),
                new MonthProperties("Schlaugust", "Schl", 26, false),
                new MonthProperties("Fabtember", "Fabt", 26, false),
                new MonthProperties("Cocktober", "Cock", 27, false),
                new MonthProperties("Növember", "Növ", 26, false),
                new MonthProperties("Gayzember", "Gay", 26, true),
                new MonthProperties("Markus Wall", "Mark", 27, false),
                new MonthProperties("Vierzehn", "Vier", 26, false),
                new MonthProperties("Einfalslos", "Einf", 26, false),
                new MonthProperties("Ende", "Ende", 27, false)
            };
            
            _WeekDays = new List<WeekDayProperties>()
            {
                new WeekDayProperties("Mohntag", "Mo"),
                new WeekDayProperties("Deenstag", "Dee"),
                new WeekDayProperties("Fickwoch", "Fi"),
                new WeekDayProperties("Blitztag", "Bli"),
                new WeekDayProperties("Schreitag", "Sch"),
            };
            
            _FirstLeapYear = 7;
            _LeapYearSpan = 15;
            _WeekNumberFormat = "{CalendarWeek}.";
            _WeekDayFormat = "{WeekDayShort}";
            _DayOfMonthFormat = "{DayOfMonth}";
            _SelectedDateFormat = "{WeekDay} - {Month} {DayOfMonth}, {Year}";
            _WeekNumberFont = new Font("Microsoft Sans Serif", 9.0f, FontStyle.Bold);
            _WeekDayFont = new Font("Microsoft Sans Serif", 9.0f, FontStyle.Bold);
            _DayOfMonthFont = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold);
            _SelectedDateFont = new Font("Microsoft Sans Serif", 10.0f, FontStyle.Bold);
        }
    }
}
