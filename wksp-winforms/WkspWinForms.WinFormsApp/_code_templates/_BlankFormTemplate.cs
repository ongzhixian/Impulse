using System.Windows.Forms;

namespace WkspWinForms.WinFormsApp
{
    public partial class BlankFormTemplate : Form
    {
        private System.ComponentModel.IContainer components = null;
        public BlankFormTemplate()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 365);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }
    }
}
