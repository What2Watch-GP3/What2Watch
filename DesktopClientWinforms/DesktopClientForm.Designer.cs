
using System.Windows.Forms;

namespace DesktopClientWinforms
{
    partial class DesktopClientForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.currentPagePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // currentPagePanel
            // 
            this.currentPagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentPagePanel.Location = new System.Drawing.Point(0, 0);
            this.currentPagePanel.Name = "currentPagePanel";
            this.currentPagePanel.Size = new System.Drawing.Size(938, 525);
            this.currentPagePanel.TabIndex = 0;
            // 
            // DesktopClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 525);
            this.Controls.Add(this.currentPagePanel);
            this.Name = "DesktopClientForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Panel currentPagePanel;
    }
}

