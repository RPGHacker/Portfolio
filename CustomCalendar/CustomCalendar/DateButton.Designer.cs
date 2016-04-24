namespace CustomCalendarApplication
{
    partial class DateButton
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
            this.customPanelBorder = new CustomCalendarApplication.CustomPanel();
            this.customLabelDate = new CustomCalendarApplication.CustomLabel();
            this.customPanelBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // customPanelBorder
            // 
            this.customPanelBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanelBorder.Controls.Add(this.customLabelDate);
            this.customPanelBorder.ForeColor = System.Drawing.SystemColors.Control;
            this.customPanelBorder.Location = new System.Drawing.Point(0, 0);
            this.customPanelBorder.Name = "customPanelBorder";
            this.customPanelBorder.Size = new System.Drawing.Size(150, 150);
            this.customPanelBorder.TabIndex = 0;
            // 
            // customLabelDate
            // 
            this.customLabelDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customLabelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLabelDate.Location = new System.Drawing.Point(3, 3);
            this.customLabelDate.Name = "customLabelDate";
            this.customLabelDate.Size = new System.Drawing.Size(144, 144);
            this.customLabelDate.TabIndex = 0;
            this.customLabelDate.Text = "0";
            this.customLabelDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DateButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customPanelBorder);
            this.Name = "DateButton";
            this.Enter += new System.EventHandler(this.DateButton_Enter);
            this.Leave += new System.EventHandler(this.DateButton_Leave);
            this.MouseEnter += new System.EventHandler(this.DateButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.DateButton_MouseLeave);
            this.customPanelBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomPanel customPanelBorder;
        private CustomLabel customLabelDate;
    }
}
