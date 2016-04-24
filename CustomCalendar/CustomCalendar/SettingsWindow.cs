using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomCalendarApplication
{
    public partial class SettingsWindow : Form
    {
        private CalendarProperties _CalendarProperties = null;
        public CalendarProperties CalendarProperties
        {
            get { return _CalendarProperties; }
            set { _CalendarProperties = value; UpdateControlsWithCalendarProperties(); }
        }

        public SettingsWindow()
        {
            InitializeComponent();

            _CalendarProperties = new CalendarProperties();
            UpdateControlsWithCalendarProperties();
        }

        public SettingsWindow(CalendarProperties calendarProperties)
        {
            InitializeComponent();

            _CalendarProperties = calendarProperties;
            UpdateControlsWithCalendarProperties();
        }

        protected void UpdateControlsWithCalendarProperties()
        {
            dataGridViewMonths.Rows.Clear();
            for (int i = 0; i < _CalendarProperties.Months.Count; i++)
            {
                dataGridViewMonths.Rows.Add(_CalendarProperties.Months[i].FullName, _CalendarProperties.Months[i].ShortName, _CalendarProperties.Months[i].NumberOfDays.ToString(), _CalendarProperties.Months[i].HasLeapDay);
            }

            dataGridViewWeekDays.Rows.Clear();
            for (int i = 0; i < _CalendarProperties.WeekDays.Count; i++)
            {
                dataGridViewWeekDays.Rows.Add(_CalendarProperties.WeekDays[i].FullName, _CalendarProperties.WeekDays[i].ShortName);
            }

            numericUpDownFirstLeapYear.Value = _CalendarProperties.FirstLeapYear;
            numericUpDownLeapYearTimeSpan.Value = _CalendarProperties.LeapYearSpan;

            textBoxWeekDayFormat.Text = _CalendarProperties.WeekDayFormat;
            textBoxWeekNumberFormat.Text = _CalendarProperties.WeekNumberFormat;
            textBoxDayOfMonthFormat.Text = _CalendarProperties.DayOfMonthFormat;
            textBoxSelectedDateFormat.Text = _CalendarProperties.SelectedDateFormat;

            labelWeekDaySample.Font = _CalendarProperties.WeekDayFont;
            labelWeekNumberSample.Font = _CalendarProperties.WeekNumberFont;
            labelDayOfMonthSample.Font = _CalendarProperties.DayOfMonthFont;
            labelSelectedDateSample.Font = _CalendarProperties.SelectedDateFont;
        }

        protected void UpdateCalendarPropertiesWithControls()
        {
            _CalendarProperties.Months.Clear();
            for (int i = 0; i < dataGridViewMonths.Rows.Count; i++)
            {
                DataGridViewTextBoxCell textBoxName = dataGridViewMonths.Rows[i].Cells[0] as DataGridViewTextBoxCell;
                DataGridViewTextBoxCell textBoxShortName = dataGridViewMonths.Rows[i].Cells[1] as DataGridViewTextBoxCell;
                DataGridViewTextBoxCell textBoxNumDays = dataGridViewMonths.Rows[i].Cells[2] as DataGridViewTextBoxCell;
                DataGridViewCheckBoxCell checkBoxLeapDay = dataGridViewMonths.Rows[i].Cells[3] as DataGridViewCheckBoxCell;

                uint parsedValue = 0;
                if (textBoxName != null && textBoxShortName != null && textBoxNumDays != null && checkBoxLeapDay != null && UInt32.TryParse((string)textBoxNumDays.Value, out parsedValue))
                {
                    _CalendarProperties.Months.Add(new MonthProperties((string)textBoxName.Value, (string)textBoxShortName.Value, parsedValue, (bool)checkBoxLeapDay.Value));
                }
            }

            _CalendarProperties.WeekDays.Clear();
            for (int i = 0; i < dataGridViewWeekDays.Rows.Count; i++)
            {
                DataGridViewTextBoxCell textBoxName = dataGridViewWeekDays.Rows[i].Cells[0] as DataGridViewTextBoxCell;
                DataGridViewTextBoxCell textBoxShortName = dataGridViewWeekDays.Rows[i].Cells[1] as DataGridViewTextBoxCell;
                
                if (textBoxName != null && textBoxShortName != null)
                {
                    _CalendarProperties.WeekDays.Add(new WeekDayProperties((string)textBoxName.Value, (string)textBoxShortName.Value));
                }
            }

             _CalendarProperties.FirstLeapYear = (uint)numericUpDownFirstLeapYear.Value;
             _CalendarProperties.LeapYearSpan = (uint)numericUpDownLeapYearTimeSpan.Value;

            _CalendarProperties.WeekDayFormat = textBoxWeekDayFormat.Text;
            _CalendarProperties.WeekNumberFormat = textBoxWeekNumberFormat.Text;
            _CalendarProperties.DayOfMonthFormat = textBoxDayOfMonthFormat.Text;
            _CalendarProperties.SelectedDateFormat = textBoxSelectedDateFormat.Text;

            _CalendarProperties.WeekDayFont = labelWeekDaySample.Font;
            _CalendarProperties.WeekNumberFont = labelWeekNumberSample.Font;
            _CalendarProperties.DayOfMonthFont = labelDayOfMonthSample.Font;
             _CalendarProperties.SelectedDateFont = labelSelectedDateSample.Font;
        }

        protected bool ValidateInputs()
        {
            if (dataGridViewMonths.Rows.Count == 0)
            {
                MessageBox.Show("The calendar needs to contain at least a single month.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dataGridViewWeekDays.Rows.Count == 0)
            {
                MessageBox.Show("The calendar needs to contain at least a single weekday.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            for (int i = 0; i < dataGridViewMonths.Rows.Count; i++)
            {
                DataGridViewTextBoxCell textBoxName = dataGridViewMonths.Rows[i].Cells[0] as DataGridViewTextBoxCell;
                DataGridViewTextBoxCell textBoxNumDays = dataGridViewMonths.Rows[i].Cells[2] as DataGridViewTextBoxCell;

                if (textBoxName != null && textBoxNumDays != null)
                {
                    uint parsedValue = 0;
                    if (!UInt32.TryParse((string)textBoxNumDays.Value, out parsedValue))
                    {
                        MessageBox.Show(String.Format("\"Number of Days\" for month number {0} ('{1}') contains an illegal value: '{2}'. Please use only numeric values.", i, (string)textBoxName.Value, (string)textBoxNumDays.Value), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else if (parsedValue == 0)
                    {
                        MessageBox.Show(String.Format("\"Number of Days\" for month number {0} ('{1}') contains an illegal value: '{2}'. Please use only values > 0.", i, (string)textBoxName.Value, (string)textBoxNumDays.Value), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }

        private void buttonPlusMonth_Click(object sender, EventArgs e)
        {
            if (dataGridViewMonths.SelectedRows.Count > 0)
            {
                dataGridViewMonths.Rows.Insert(dataGridViewMonths.SelectedRows[dataGridViewMonths.SelectedRows.Count - 1].Index, "", "", "1", false);
            }
            else
            {
                dataGridViewMonths.Rows.Add("", "", "1", false);
            }
        }

        private void buttonPlusWeekDays_Click(object sender, EventArgs e)
        {
            if (dataGridViewWeekDays.SelectedRows.Count > 0)
            {
                dataGridViewWeekDays.Rows.Insert(dataGridViewWeekDays.SelectedRows[dataGridViewWeekDays.SelectedRows.Count - 1].Index, "", "");
            }
            else
            {
                dataGridViewWeekDays.Rows.Add("", "");
            }
        }

        private void buttonMinusMonths_Click(object sender, EventArgs e)
        {
            if (dataGridViewMonths.SelectedRows.Count > 0)
            {
                for (int i = dataGridViewMonths.SelectedRows.Count - 1; i >= 0; i--)
                {
                    dataGridViewMonths.Rows.Remove(dataGridViewMonths.SelectedRows[i]);
                }
            }
        }

        private void buttonMinusWeekDays_Click(object sender, EventArgs e)
        {
            if (dataGridViewWeekDays.SelectedRows.Count > 0)
            {
                for (int i = dataGridViewWeekDays.SelectedRows.Count - 1; i >= 0; i--)
                {
                    dataGridViewWeekDays.Rows.Remove(dataGridViewWeekDays.SelectedRows[i]);
                }
            }
        }

        private void buttonClearMonhts_Click(object sender, EventArgs e)
        {
            dataGridViewMonths.Rows.Clear();
        }

        private void buttonClearWeekDays_Click(object sender, EventArgs e)
        {
            dataGridViewWeekDays.Rows.Clear();
        }

        private void buttonFormatHelp_Click(object sender, EventArgs e)
        {
            new FormattingHelp().Show();
        }

        private void buttonChangeFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();

            if (sender == buttonWeekDayFont)
            {
                fontDialog.Font = labelWeekDaySample.Font;
            }
            else if (sender == buttonWeekNumberFont)
            {
                fontDialog.Font = labelWeekNumberSample.Font;
            }
            else if (sender == buttonDayOfMonthFont)
            {
                fontDialog.Font = labelDayOfMonthSample.Font;
            }
            else if (sender == buttonSelectedDateFont)
            {
                fontDialog.Font = labelSelectedDateSample.Font;
            }

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                if (sender == buttonWeekDayFont)
                {
                    labelWeekDaySample.Font = fontDialog.Font;
                }
                else if (sender == buttonWeekNumberFont)
                {
                    labelWeekNumberSample.Font = fontDialog.Font;
                }
                else if (sender == buttonDayOfMonthFont)
                {
                    labelDayOfMonthSample.Font = fontDialog.Font;
                }
                else if (sender == buttonSelectedDateFont)
                {
                    labelSelectedDateSample.Font = fontDialog.Font;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                UpdateCalendarPropertiesWithControls();
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }
    }
}
