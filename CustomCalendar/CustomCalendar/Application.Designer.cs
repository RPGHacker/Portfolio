namespace CustomCalendarApplication
{
    partial class Application
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Application));
            this.customCalendar = new CustomCalendarApplication.CustomCalendar();
            this.SuspendLayout();
            // 
            // customCalendar
            // 
            this.customCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customCalendar.Location = new System.Drawing.Point(12, 12);
            this.customCalendar.MinimumSize = new System.Drawing.Size(300, 300);
            this.customCalendar.Name = "customCalendar";
            this.customCalendar.SelectedMonthIndex = 0;
            this.customCalendar.SelectedYear = 0;
            this.customCalendar.Size = new System.Drawing.Size(300, 331);
            this.customCalendar.TabIndex = 0;
            // 
            // Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 355);
            this.Controls.Add(this.customCalendar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(340, 394);
            this.Name = "Application";
            this.Text = "Custom Calendar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Application_FormClosing);
            this.LocationChanged += new System.EventHandler(this.Application_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.Application_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomCalendar customCalendar;
    }
}

