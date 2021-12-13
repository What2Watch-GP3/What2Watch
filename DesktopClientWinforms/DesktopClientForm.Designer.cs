
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
            this.TitleBarPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnMinimise = new System.Windows.Forms.Button();
            this.btnMaximise = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.TitleBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // currentPagePanel
            // 
            this.currentPagePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(32)))));
            this.currentPagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentPagePanel.Location = new System.Drawing.Point(0, 60);
            this.currentPagePanel.Margin = new System.Windows.Forms.Padding(4);
            this.currentPagePanel.Name = "currentPagePanel";
            this.currentPagePanel.Size = new System.Drawing.Size(1172, 606);
            this.currentPagePanel.TabIndex = 0;
            this.currentPagePanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.currentPagePanel_ControlAdded);
            // 
            // TitleBarPanel
            // 
            this.TitleBarPanel.BackColor = System.Drawing.Color.Black;
            this.TitleBarPanel.Controls.Add(this.pictureBox1);
            this.TitleBarPanel.Controls.Add(this.lblTitle);
            this.TitleBarPanel.Controls.Add(this.btnMinimise);
            this.TitleBarPanel.Controls.Add(this.btnMaximise);
            this.TitleBarPanel.Controls.Add(this.btnExit);
            this.TitleBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBarPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TitleBarPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.TitleBarPanel.Location = new System.Drawing.Point(0, 0);
            this.TitleBarPanel.Margin = new System.Windows.Forms.Padding(4);
            this.TitleBarPanel.Name = "TitleBarPanel";
            this.TitleBarPanel.Size = new System.Drawing.Size(1172, 60);
            this.TitleBarPanel.TabIndex = 0;
            this.TitleBarPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DesktopClientWinforms.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(17, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(126, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(149, 15);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(66, 29);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Title";
            // 
            // btnMinimise
            // 
            this.btnMinimise.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimise.FlatAppearance.BorderSize = 0;
            this.btnMinimise.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnMinimise.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(70)))));
            this.btnMinimise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimise.Location = new System.Drawing.Point(977, 0);
            this.btnMinimise.Margin = new System.Windows.Forms.Padding(0);
            this.btnMinimise.Name = "btnMinimise";
            this.btnMinimise.Padding = new System.Windows.Forms.Padding(4, 0, 0, 2);
            this.btnMinimise.Size = new System.Drawing.Size(65, 60);
            this.btnMinimise.TabIndex = 2;
            this.btnMinimise.TabStop = false;
            this.btnMinimise.Text = "🗕";
            this.btnMinimise.UseVisualStyleBackColor = true;
            this.btnMinimise.Click += new System.EventHandler(this.btnMinimise_Click);
            // 
            // btnMaximise
            // 
            this.btnMaximise.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMaximise.FlatAppearance.BorderSize = 0;
            this.btnMaximise.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnMaximise.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(70)))));
            this.btnMaximise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximise.Location = new System.Drawing.Point(1042, 0);
            this.btnMaximise.Margin = new System.Windows.Forms.Padding(0);
            this.btnMaximise.Name = "btnMaximise";
            this.btnMaximise.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnMaximise.Size = new System.Drawing.Size(65, 60);
            this.btnMaximise.TabIndex = 1;
            this.btnMaximise.TabStop = false;
            this.btnMaximise.Text = "🗗";
            this.btnMaximise.UseVisualStyleBackColor = true;
            this.btnMaximise.Click += new System.EventHandler(this.btnMaximise_Click);
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(70)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(1107, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(4, 4, 0, 0);
            this.btnExit.Size = new System.Drawing.Size(65, 60);
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "✕";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // DesktopClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(1172, 666);
            this.Controls.Add(this.currentPagePanel);
            this.Controls.Add(this.TitleBarPanel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(744, 611);
            this.Name = "DesktopClientForm";
            this.Text = "Admin Panel";
            this.Load += new System.EventHandler(this.DesktopClientForm_Load);
            this.TitleBarPanel.ResumeLayout(false);
            this.TitleBarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel currentPagePanel;
        private Panel TitleBarPanel;
        private Button btnMinimise;
        private Button btnMaximise;
        private Button btnExit;
        private Label lblTitle;
        private PictureBox pictureBox1;
    }
}

