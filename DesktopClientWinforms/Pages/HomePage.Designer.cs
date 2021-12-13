
namespace DesktopClientWinforms.Pages
{
    partial class HomePage
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
            this.btnCreateShow = new System.Windows.Forms.Button();
            this.btnCreateRoom = new System.Windows.Forms.Button();
            this.btnDeleteShow = new System.Windows.Forms.Button();
            this.btnDeleteRoom = new System.Windows.Forms.Button();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateShow
            // 
            this.btnCreateShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.btnCreateShow.FlatAppearance.BorderSize = 0;
            this.btnCreateShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateShow.Location = new System.Drawing.Point(0, 0);
            this.btnCreateShow.Name = "btnCreateShow";
            this.btnCreateShow.Size = new System.Drawing.Size(180, 108);
            this.btnCreateShow.TabIndex = 0;
            this.btnCreateShow.Text = "Create Show";
            this.btnCreateShow.UseVisualStyleBackColor = false;
            this.btnCreateShow.Click += new System.EventHandler(this.btnCreateShow_Click);
            // 
            // btnCreateRoom
            // 
            this.btnCreateRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.btnCreateRoom.Enabled = false;
            this.btnCreateRoom.FlatAppearance.BorderSize = 0;
            this.btnCreateRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateRoom.Location = new System.Drawing.Point(229, 0);
            this.btnCreateRoom.Name = "btnCreateRoom";
            this.btnCreateRoom.Size = new System.Drawing.Size(180, 108);
            this.btnCreateRoom.TabIndex = 1;
            this.btnCreateRoom.Text = "Create Room";
            this.btnCreateRoom.UseVisualStyleBackColor = false;
            // 
            // btnDeleteShow
            // 
            this.btnDeleteShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.btnDeleteShow.Enabled = false;
            this.btnDeleteShow.FlatAppearance.BorderSize = 0;
            this.btnDeleteShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteShow.Location = new System.Drawing.Point(0, 154);
            this.btnDeleteShow.Name = "btnDeleteShow";
            this.btnDeleteShow.Size = new System.Drawing.Size(180, 108);
            this.btnDeleteShow.TabIndex = 2;
            this.btnDeleteShow.Text = "Delete Show";
            this.btnDeleteShow.UseVisualStyleBackColor = false;
            // 
            // btnDeleteRoom
            // 
            this.btnDeleteRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(37)))));
            this.btnDeleteRoom.Enabled = false;
            this.btnDeleteRoom.FlatAppearance.BorderSize = 0;
            this.btnDeleteRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteRoom.Location = new System.Drawing.Point(229, 154);
            this.btnDeleteRoom.Name = "btnDeleteRoom";
            this.btnDeleteRoom.Size = new System.Drawing.Size(180, 108);
            this.btnDeleteRoom.TabIndex = 3;
            this.btnDeleteRoom.Text = "Delete Room";
            this.btnDeleteRoom.UseVisualStyleBackColor = false;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPanel.Controls.Add(this.btnCreateShow);
            this.buttonPanel.Controls.Add(this.btnDeleteRoom);
            this.buttonPanel.Controls.Add(this.btnCreateRoom);
            this.buttonPanel.Controls.Add(this.btnDeleteShow);
            this.buttonPanel.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.buttonPanel.Location = new System.Drawing.Point(192, 114);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(410, 262);
            this.buttonPanel.TabIndex = 4;
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.buttonPanel);
            this.Name = "HomePage";
            this.Size = new System.Drawing.Size(791, 515);
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateShow;
        private System.Windows.Forms.Button btnCreateRoom;
        private System.Windows.Forms.Button btnDeleteShow;
        private System.Windows.Forms.Button btnDeleteRoom;
        private System.Windows.Forms.Panel buttonPanel;
    }
}
