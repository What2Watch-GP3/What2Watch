
namespace DesktopClientWinforms
{
    partial class CreateShowPage
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
            this.backgroundPanel = new System.Windows.Forms.Panel();
            this.btnCreateShow = new System.Windows.Forms.Button();
            this.txtRoomId = new System.Windows.Forms.TextBox();
            this.lblRoomId = new System.Windows.Forms.Label();
            this.txtMovieId = new System.Windows.Forms.TextBox();
            this.lblMovieId = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.backgroundPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundPanel
            // 
            this.backgroundPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.backgroundPanel.Controls.Add(this.btnCreateShow);
            this.backgroundPanel.Controls.Add(this.txtRoomId);
            this.backgroundPanel.Controls.Add(this.lblRoomId);
            this.backgroundPanel.Controls.Add(this.txtMovieId);
            this.backgroundPanel.Controls.Add(this.lblMovieId);
            this.backgroundPanel.Controls.Add(this.datePicker);
            this.backgroundPanel.Controls.Add(this.lblDate);
            this.backgroundPanel.Controls.Add(this.lblTitle);
            this.backgroundPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundPanel.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.backgroundPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.backgroundPanel.Location = new System.Drawing.Point(0, 0);
            this.backgroundPanel.Margin = new System.Windows.Forms.Padding(4);
            this.backgroundPanel.Name = "backgroundPanel";
            this.backgroundPanel.Size = new System.Drawing.Size(1084, 660);
            this.backgroundPanel.TabIndex = 0;
            // 
            // btnCreateShow
            // 
            this.btnCreateShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.btnCreateShow.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreateShow.FlatAppearance.BorderSize = 0;
            this.btnCreateShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateShow.Location = new System.Drawing.Point(0, 249);
            this.btnCreateShow.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateShow.Name = "btnCreateShow";
            this.btnCreateShow.Size = new System.Drawing.Size(1084, 56);
            this.btnCreateShow.TabIndex = 5;
            this.btnCreateShow.Text = "Create";
            this.btnCreateShow.UseVisualStyleBackColor = false;
            this.btnCreateShow.Click += new System.EventHandler(this.btnCreateShow_Click);
            // 
            // txtRoomId
            // 
            this.txtRoomId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.txtRoomId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRoomId.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtRoomId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtRoomId.Location = new System.Drawing.Point(0, 215);
            this.txtRoomId.Margin = new System.Windows.Forms.Padding(4);
            this.txtRoomId.Name = "txtRoomId";
            this.txtRoomId.Size = new System.Drawing.Size(1084, 34);
            this.txtRoomId.TabIndex = 9;
            this.txtRoomId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRoomId_KeyPress);
            // 
            // lblRoomId
            // 
            this.lblRoomId.AutoSize = true;
            this.lblRoomId.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRoomId.Location = new System.Drawing.Point(0, 180);
            this.lblRoomId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRoomId.Name = "lblRoomId";
            this.lblRoomId.Size = new System.Drawing.Size(115, 35);
            this.lblRoomId.TabIndex = 8;
            this.lblRoomId.Text = "Room Id:";
            // 
            // txtMovieId
            // 
            this.txtMovieId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.txtMovieId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMovieId.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtMovieId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtMovieId.Location = new System.Drawing.Point(0, 146);
            this.txtMovieId.Margin = new System.Windows.Forms.Padding(4);
            this.txtMovieId.Name = "txtMovieId";
            this.txtMovieId.Size = new System.Drawing.Size(1084, 34);
            this.txtMovieId.TabIndex = 7;
            this.txtMovieId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMovieId_KeyPress);
            // 
            // lblMovieId
            // 
            this.lblMovieId.AutoSize = true;
            this.lblMovieId.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMovieId.Location = new System.Drawing.Point(0, 111);
            this.lblMovieId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMovieId.Name = "lblMovieId";
            this.lblMovieId.Size = new System.Drawing.Size(117, 35);
            this.lblMovieId.TabIndex = 6;
            this.lblMovieId.Text = "Movie Id:";
            // 
            // datePicker
            // 
            this.datePicker.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.datePicker.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.datePicker.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.datePicker.Dock = System.Windows.Forms.DockStyle.Top;
            this.datePicker.Location = new System.Drawing.Point(0, 70);
            this.datePicker.Margin = new System.Windows.Forms.Padding(4);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(1084, 41);
            this.datePicker.TabIndex = 10;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDate.Location = new System.Drawing.Point(0, 35);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(72, 35);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(153, 35);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Create Show";
            // 
            // CreateShowPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.backgroundPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CreateShowPage";
            this.Size = new System.Drawing.Size(1084, 660);
            this.Load += new System.EventHandler(this.CreateShowPage_Load);
            this.backgroundPanel.ResumeLayout(false);
            this.backgroundPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel backgroundPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnCreateShow;
        private System.Windows.Forms.TextBox txtRoomId;
        private System.Windows.Forms.Label lblRoomId;
        private System.Windows.Forms.TextBox txtMovieId;
        private System.Windows.Forms.Label lblMovieId;
        private System.Windows.Forms.DateTimePicker datePicker;
    }
}
