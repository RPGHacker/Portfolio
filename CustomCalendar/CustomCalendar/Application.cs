using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomCalendarApplication.Properties;

namespace CustomCalendarApplication
{
    public partial class Application : Form
    {
        public Application()
        {
            InitializeComponent();

            System.Drawing.Size formSize = Settings.Default.FormSize;
            if (formSize.Width >= Size.Width && formSize.Height >= Size.Height)
            {
                Size = formSize;
            }

            System.Drawing.Point formPosition = Settings.Default.FormLocation;
            if (formPosition.X >= 0 && formPosition.Y >= 0)
            {
                StartPosition = FormStartPosition.Manual;
                Location = formPosition;
            }

            if (Settings.Default.FormMaximized)
            {
                WindowState = FormWindowState.Maximized;
            }

            customCalendar.SelectedMonthIndex = (int)Settings.Default.SelectedMonthIndex;
            customCalendar.SelectedYear = (int)Settings.Default.SelectedYear;
        }

        private void Application_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.FormMaximized = (WindowState == FormWindowState.Maximized);
            Settings.Default.SelectedMonthIndex = (uint)customCalendar.SelectedMonthIndex;
            Settings.Default.SelectedYear = (uint)customCalendar.SelectedYear;
            Settings.Default.Save();
        }

        private void Application_LocationChanged(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                Settings.Default.FormLocation = Location;
            }
        }

        private void Application_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                Settings.Default.FormSize = Size;
            }
        }
    }
}
