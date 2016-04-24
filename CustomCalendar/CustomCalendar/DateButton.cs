using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomCalendarApplication
{
    public partial class DateButton : UserControl
    {
        // The color to use for the border when the date belongs to another month and is not currently selected.
        private Color _InactiveOtherMonthBorderColor = SystemColors.Control;

        [Description("The color to use for the border when the date belongs to another month and is not currently selected."), Category("Appearance")]
        public Color InactiveOtherMonthBorderColor
        {
            get { return _InactiveOtherMonthBorderColor; }
            set { _InactiveOtherMonthBorderColor = value; UpdateColors(); }
        }

        // The color to use for the border when the date belongs to the selected month and is not currently selected.
        private Color _InactiveSelectedMonthBorderColor = SystemColors.Control;

        [Description("The color to use for the border when the date belongs to the selected month and is not currently selected."), Category("Appearance")]
        public Color InactiveSelectedMonthBorderColor
        {
            get { return _InactiveSelectedMonthBorderColor; }
            set { _InactiveSelectedMonthBorderColor = value; UpdateColors(); }
        }

        // The color to use for the border when the mouse hovers over the date.
        private Color _HoverBorderColor = SystemColors.Highlight;

        [Description("The color to use for the border when the mouse hovers over the month."), Category("Appearance")]
        public Color HoverBorderColor
        {
            get { return _HoverBorderColor; }
            set { _HoverBorderColor = value; UpdateColors(); }
        }

        // The color to use for the border when the date is selected.
        private Color _ActiveBorderColor = SystemColors.Highlight;

        [Description("The color to use for the border when the mouse hovers over the month."), Category("Appearance")]
        public Color ActiveBorderColor
        {
            get { return _ActiveBorderColor; }
            set { _ActiveBorderColor = value; UpdateColors(); }
        }



        // The color to use for the number when the date belongs to another month and is not currently selected.
        private Color _InactiveOtherMonthNumberColor = SystemColors.InactiveCaption;

        [Description("The color to use for the number when the date belongs to another month and is not currently selected."), Category("Appearance")]
        public Color InactiveOtherMonthNumberColor
        {
            get { return _InactiveOtherMonthNumberColor; }
            set { _InactiveOtherMonthNumberColor = value; UpdateColors(); }
        }

        // The color to use for the number when the date belongs to the selected month and is not currently selected.
        private Color _InactiveSelectedMonthNumberColor = SystemColors.ControlText;

        [Description("The color to use for the number when the date belongs to the selected month and is not currently selected."), Category("Appearance")]
        public Color InactiveSelectedMonthNumberColor
        {
            get { return _InactiveSelectedMonthNumberColor; }
            set { _InactiveSelectedMonthNumberColor = value; UpdateColors(); }
        }

        // The color to use for the number when the mouse hovers over the date.
        private Color _HoverNumberColor = SystemColors.Highlight;

        [Description("The color to use for the number when the mouse hovers over the month."), Category("Appearance")]
        public Color HoverNumberColor
        {
            get { return _HoverNumberColor; }
            set { _HoverNumberColor = value; UpdateColors(); }
        }

        // The color to use for the number when the date is selected.
        private Color _ActiveNumberColor = SystemColors.HighlightText;

        [Description("The color to use for the number when the mouse hovers over the month."), Category("Appearance")]
        public Color ActiveNumberColor
        {
            get { return _ActiveNumberColor; }
            set { _ActiveNumberColor = value; UpdateColors(); }
        }



        // The color to use for the background when the date belongs to another month and is not currently selected.
        private Color _InactiveOtherMonthBackgroundColor = SystemColors.Control;

        [Description("The color to use for the background when the date belongs to another month and is not currently selected."), Category("Appearance")]
        public Color InactiveOtherMonthBackgroundColor
        {
            get { return _InactiveOtherMonthBackgroundColor; }
            set { _InactiveOtherMonthBackgroundColor = value; UpdateColors(); }
        }

        // The color to use for the background when the date belongs to the selected month and is not currently selected.
        private Color _InactiveSelectedMonthBackgroundColor = SystemColors.Control;

        [Description("The color to use for the background when the date belongs to the selected month and is not currently selected."), Category("Appearance")]
        public Color InactiveSelectedMonthBackgroundColor
        {
            get { return _InactiveSelectedMonthBackgroundColor; }
            set { _InactiveSelectedMonthBackgroundColor = value; UpdateColors(); }
        }

        // The color to use for the background when the mouse hovers over the date.
        private Color _HoverBackgroundColor = SystemColors.Control;

        [Description("The color to use for the background when the mouse hovers over the month."), Category("Appearance")]
        public Color HoverBackgroundColor
        {
            get { return _HoverBackgroundColor; }
            set { _HoverBackgroundColor = value; UpdateColors(); }
        }

        // The color to use for the background when the date is selected.
        private Color _ActiveBackgroundColor = SystemColors.Highlight;

        [Description("The color to use for the background when the mouse hovers over the month."), Category("Appearance")]
        public Color ActiveBackgroundColor
        {
            get { return _ActiveBackgroundColor; }
            set { _ActiveBackgroundColor = value; UpdateColors(); }
        }



        // The date to display on the button
        protected uint _DayNumber = 0;

        [Description("The day number to display on the button."), Category("Appearance")]
        public uint DayNumber
        {
            get { return _DayNumber; }
            set { _DayNumber = value; UpdateText(); }
        }

        // Which format to use for displaying the date
        private string _DayNumberFormat = "{DayNumber}";
        public string DayNumberFormat
        {
            get { return _DayNumberFormat; }
            set { _DayNumberFormat = value; UpdateText(); }
        }

        // Which object to get injection token from
        private object _InjectionObject = null;
        public object InjectionObject
        {
            get { return _InjectionObject; }
            set { _InjectionObject = value; UpdateText(); }
        }
        

        private void UpdateText()
        {
            customLabelDate.Text = _DayNumberFormat.Inject(_InjectionObject);
        }



        public enum DateButtonState
        {
            InactiveOtherMonth,
            InactiveSelectedMonth,
            HoveredOver,
            Active
        }



        // Whether the date belongs to the current month or not.
        private bool _BelongsToCurrentMonth = false;

        [Description("Whether the date belongs to the current month or not."), Category("Behavior")]
        public bool BelongsToCurrentMonth
        {
            get { return _BelongsToCurrentMonth; }
            set { _BelongsToCurrentMonth = value; UpdateState(); UpdateColors(); }
        }



        // Which state the button is currently in.
        private DateButtonState _ButtonState = DateButtonState.InactiveOtherMonth;

        [Description("Which state the button is currently in."), Category("Behavior")]
        protected DateButtonState ButtonState
        {
            get { return _ButtonState; }
            set { _ButtonState = value; UpdateColors(); }
        }



        // Which font the button uses.
        [Description("Which font the button uses."), Category("Appearance")]
        override public Font Font
        {
            get { return customLabelDate.Font; }
            set { customLabelDate.Font = value; UpdateColors(); }
        }



        protected bool IsMouseOver = false;



        public DateButton()
        {
            InitializeComponent();

            IsMouseOver = false;
            _DayNumber = UInt32.Parse(customLabelDate.Text);
            InjectionObject = this;

            UpdateState();
            UpdateColors();
        }


        public void UpdateState()
        {
            if (Focused)
            {
                ButtonState = DateButtonState.Active;
            }
            else if (IsMouseOver)
            {
                ButtonState = DateButtonState.HoveredOver;
            }
            else if (BelongsToCurrentMonth)
            {
                ButtonState = DateButtonState.InactiveSelectedMonth;
            }
            else
            {
                ButtonState = DateButtonState.InactiveOtherMonth;
            }
        }


        public void UpdateColors()
        {
            switch (_ButtonState)
            {
                case DateButtonState.InactiveOtherMonth:
                default:
                    customLabelDate.ForeColor = _InactiveOtherMonthNumberColor;
                    customPanelBorder.ForeColor = _InactiveOtherMonthBorderColor;
                    customLabelDate.BackColor = _InactiveOtherMonthBackgroundColor;
                    break;

                case DateButtonState.InactiveSelectedMonth:
                    customLabelDate.ForeColor = _InactiveSelectedMonthNumberColor;
                    customPanelBorder.ForeColor = _InactiveSelectedMonthBorderColor;
                    customLabelDate.BackColor = _InactiveSelectedMonthBackgroundColor;
                    break;

                case DateButtonState.HoveredOver:
                    customLabelDate.ForeColor = _HoverNumberColor;
                    customPanelBorder.ForeColor = _HoverBorderColor;
                    customLabelDate.BackColor = _HoverBackgroundColor;
                    break;

                case DateButtonState.Active:
                    customLabelDate.ForeColor = _ActiveNumberColor;
                    customPanelBorder.ForeColor = _ActiveBorderColor;
                    customLabelDate.BackColor = _ActiveBackgroundColor;
                    break;
            }
        }

        private void DateButton_Enter(object sender, EventArgs e)
        {
            UpdateState();
        }

        private void DateButton_Leave(object sender, EventArgs e)
        {
            UpdateState();
        }

        private void DateButton_MouseEnter(object sender, EventArgs e)
        {
            IsMouseOver = true;
            UpdateState();
        }

        private void DateButton_MouseLeave(object sender, EventArgs e)
        {
            IsMouseOver = false;
            UpdateState();
        }
    }
}
