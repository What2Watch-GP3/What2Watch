using DesktopClientWinforms.Components;
using System.Windows.Forms;

namespace DesktopClientWinforms.Pages
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
            this.components = new System.ComponentModel.Container();
            this.backgroundPanel = new System.Windows.Forms.Panel();
            this.btnCreateShow = new System.Windows.Forms.Button();
            this.comboSound = new DesktopClientWinforms.Components.FlatComboBox();
            this.lblSound = new System.Windows.Forms.Label();
            this.comboGraphic = new DesktopClientWinforms.Components.FlatComboBox();
            this.lblGraphic = new System.Windows.Forms.Label();
            this.comboSubtitles = new DesktopClientWinforms.Components.FlatComboBox();
            this.lblSub = new System.Windows.Forms.Label();
            this.comboDub = new DesktopClientWinforms.Components.FlatComboBox();
            this.lblDubLanguage = new System.Windows.Forms.Label();
            this.txtRoomId = new System.Windows.Forms.TextBox();
            this.lblRoomId = new System.Windows.Forms.Label();
            this.comboMovies = new DesktopClientWinforms.Components.FlatComboBox();
            this.lblMovie = new System.Windows.Forms.Label();
            this.datePickePanel = new System.Windows.Forms.Panel();
            this.datePicker = new DesktopClientWinforms.Components.FlatDatePicker();
            this.timePicker = new DesktopClientWinforms.Components.FlatDatePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tooltipSuccess = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundPanel.SuspendLayout();
            this.datePickePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundPanel
            // 
            this.backgroundPanel.AutoScroll = true;
            this.backgroundPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.backgroundPanel.Controls.Add(this.btnCreateShow);
            this.backgroundPanel.Controls.Add(this.comboSound);
            this.backgroundPanel.Controls.Add(this.lblSound);
            this.backgroundPanel.Controls.Add(this.comboGraphic);
            this.backgroundPanel.Controls.Add(this.lblGraphic);
            this.backgroundPanel.Controls.Add(this.comboSubtitles);
            this.backgroundPanel.Controls.Add(this.lblSub);
            this.backgroundPanel.Controls.Add(this.comboDub);
            this.backgroundPanel.Controls.Add(this.lblDubLanguage);
            this.backgroundPanel.Controls.Add(this.txtRoomId);
            this.backgroundPanel.Controls.Add(this.lblRoomId);
            this.backgroundPanel.Controls.Add(this.comboMovies);
            this.backgroundPanel.Controls.Add(this.lblMovie);
            this.backgroundPanel.Controls.Add(this.datePickePanel);
            this.backgroundPanel.Controls.Add(this.lblDate);
            this.backgroundPanel.Controls.Add(this.lblTitle);
            this.backgroundPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundPanel.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.backgroundPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.backgroundPanel.Location = new System.Drawing.Point(0, 0);
            this.backgroundPanel.Margin = new System.Windows.Forms.Padding(4);
            this.backgroundPanel.Name = "backgroundPanel";
            this.backgroundPanel.Size = new System.Drawing.Size(1126, 675);
            this.backgroundPanel.TabIndex = 0;
            // 
            // btnCreateShow
            // 
            this.btnCreateShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.btnCreateShow.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreateShow.FlatAppearance.BorderSize = 0;
            this.btnCreateShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateShow.Location = new System.Drawing.Point(0, 573);
            this.btnCreateShow.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateShow.Name = "btnCreateShow";
            this.btnCreateShow.Size = new System.Drawing.Size(1126, 56);
            this.btnCreateShow.TabIndex = 5;
            this.btnCreateShow.Text = "Create";
            this.btnCreateShow.UseVisualStyleBackColor = false;
            this.btnCreateShow.Click += new System.EventHandler(this.btnCreateShow_Click);
            // 
            // comboSound
            // 
            this.comboSound.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.comboSound.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboSound.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboSound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.comboSound.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.comboSound.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.comboSound.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboSound.ForeColor = System.Drawing.SystemColors.Window;
            this.comboSound.FormattingEnabled = true;
            this.comboSound.Location = new System.Drawing.Point(0, 530);
            this.comboSound.Margin = new System.Windows.Forms.Padding(4);
            this.comboSound.Name = "comboSound";
            this.comboSound.Size = new System.Drawing.Size(1126, 43);
            this.comboSound.TabIndex = 18;
            // 
            // lblSound
            // 
            this.lblSound.AutoSize = true;
            this.lblSound.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSound.Location = new System.Drawing.Point(0, 495);
            this.lblSound.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSound.Name = "lblSound";
            this.lblSound.Size = new System.Drawing.Size(150, 35);
            this.lblSound.TabIndex = 17;
            this.lblSound.Text = "Sound Type:";
            // 
            // comboGraphic
            // 
            this.comboGraphic.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.comboGraphic.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboGraphic.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboGraphic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.comboGraphic.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.comboGraphic.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.comboGraphic.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboGraphic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboGraphic.ForeColor = System.Drawing.SystemColors.Window;
            this.comboGraphic.FormattingEnabled = true;
            this.comboGraphic.Location = new System.Drawing.Point(0, 452);
            this.comboGraphic.Margin = new System.Windows.Forms.Padding(4);
            this.comboGraphic.Name = "comboGraphic";
            this.comboGraphic.Size = new System.Drawing.Size(1126, 43);
            this.comboGraphic.TabIndex = 16;
            // 
            // lblGraphic
            // 
            this.lblGraphic.AutoSize = true;
            this.lblGraphic.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGraphic.Location = new System.Drawing.Point(0, 417);
            this.lblGraphic.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGraphic.Name = "lblGraphic";
            this.lblGraphic.Size = new System.Drawing.Size(165, 35);
            this.lblGraphic.TabIndex = 15;
            this.lblGraphic.Text = "Graphic Type:";
            // 
            // comboSubtitles
            // 
            this.comboSubtitles.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.comboSubtitles.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboSubtitles.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboSubtitles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.comboSubtitles.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.comboSubtitles.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.comboSubtitles.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboSubtitles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboSubtitles.ForeColor = System.Drawing.SystemColors.Window;
            this.comboSubtitles.FormattingEnabled = true;
            this.comboSubtitles.Location = new System.Drawing.Point(0, 374);
            this.comboSubtitles.Margin = new System.Windows.Forms.Padding(4);
            this.comboSubtitles.Name = "comboSubtitles";
            this.comboSubtitles.Size = new System.Drawing.Size(1126, 43);
            this.comboSubtitles.TabIndex = 13;
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSub.Location = new System.Drawing.Point(0, 339);
            this.lblSub.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(230, 35);
            this.lblSub.TabIndex = 14;
            this.lblSub.Text = "Subtitles Language:";
            // 
            // comboDub
            // 
            this.comboDub.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.comboDub.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboDub.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboDub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.comboDub.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.comboDub.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.comboDub.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboDub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboDub.ForeColor = System.Drawing.SystemColors.Window;
            this.comboDub.FormattingEnabled = true;
            this.comboDub.Location = new System.Drawing.Point(0, 296);
            this.comboDub.Margin = new System.Windows.Forms.Padding(4);
            this.comboDub.Name = "comboDub";
            this.comboDub.Size = new System.Drawing.Size(1126, 43);
            this.comboDub.TabIndex = 12;
            // 
            // lblDubLanguage
            // 
            this.lblDubLanguage.AutoSize = true;
            this.lblDubLanguage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDubLanguage.Location = new System.Drawing.Point(0, 261);
            this.lblDubLanguage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDubLanguage.Name = "lblDubLanguage";
            this.lblDubLanguage.Size = new System.Drawing.Size(183, 35);
            this.lblDubLanguage.TabIndex = 11;
            this.lblDubLanguage.Text = "Dub Language:";
            // 
            // txtRoomId
            // 
            this.txtRoomId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.txtRoomId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRoomId.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtRoomId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtRoomId.Location = new System.Drawing.Point(0, 227);
            this.txtRoomId.Margin = new System.Windows.Forms.Padding(4);
            this.txtRoomId.Name = "txtRoomId";
            this.txtRoomId.Size = new System.Drawing.Size(1126, 34);
            this.txtRoomId.TabIndex = 9;
            this.txtRoomId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRoomId_KeyPress);
            // 
            // lblRoomId
            // 
            this.lblRoomId.AutoSize = true;
            this.lblRoomId.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRoomId.Location = new System.Drawing.Point(0, 192);
            this.lblRoomId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRoomId.Name = "lblRoomId";
            this.lblRoomId.Size = new System.Drawing.Size(115, 35);
            this.lblRoomId.TabIndex = 8;
            this.lblRoomId.Text = "Room Id:";
            // 
            // comboMovies
            // 
            this.comboMovies.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.comboMovies.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboMovies.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboMovies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.comboMovies.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.comboMovies.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.comboMovies.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboMovies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboMovies.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.comboMovies.FormattingEnabled = true;
            this.comboMovies.Location = new System.Drawing.Point(0, 149);
            this.comboMovies.Margin = new System.Windows.Forms.Padding(4);
            this.comboMovies.Name = "comboMovies";
            this.comboMovies.Size = new System.Drawing.Size(1126, 43);
            this.comboMovies.TabIndex = 20;
            // 
            // lblMovie
            // 
            this.lblMovie.AutoSize = true;
            this.lblMovie.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMovie.Location = new System.Drawing.Point(0, 114);
            this.lblMovie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMovie.Name = "lblMovie";
            this.lblMovie.Size = new System.Drawing.Size(88, 35);
            this.lblMovie.TabIndex = 6;
            this.lblMovie.Text = "Movie:";
            // 
            // datePickePanel
            // 
            this.datePickePanel.Controls.Add(this.datePicker);
            this.datePickePanel.Controls.Add(this.timePicker);
            this.datePickePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.datePickePanel.Location = new System.Drawing.Point(0, 70);
            this.datePickePanel.Margin = new System.Windows.Forms.Padding(4);
            this.datePickePanel.Name = "datePickePanel";
            this.datePickePanel.Size = new System.Drawing.Size(1126, 44);
            this.datePickePanel.TabIndex = 19;
            // 
            // datePicker
            // 
            this.datePicker.BorderColor = System.Drawing.Color.Empty;
            this.datePicker.BorderSize = 0;
            this.datePicker.CalendarIcon = global::DesktopClientWinforms.Properties.Resources.clockWhite;
            this.datePicker.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.datePicker.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(32)))));
            this.datePicker.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.datePicker.CalendarTrailingForeColor = System.Drawing.Color.Red;
            this.datePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datePicker.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.datePicker.Location = new System.Drawing.Point(569, 0);
            this.datePicker.Margin = new System.Windows.Forms.Padding(4);
            this.datePicker.MinimumSize = new System.Drawing.Size(4, 35);
            this.datePicker.Name = "datePicker";
            this.datePicker.ShowUpDown = true;
            this.datePicker.Size = new System.Drawing.Size(557, 41);
            this.datePicker.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.datePicker.TabIndex = 10;
            this.datePicker.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            // 
            // timePicker
            // 
            this.timePicker.BorderColor = System.Drawing.Color.Transparent;
            this.timePicker.BorderSize = 0;
            this.timePicker.CalendarIcon = global::DesktopClientWinforms.Properties.Resources.calendarWhite;
            this.timePicker.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.timePicker.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(32)))));
            this.timePicker.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.timePicker.CalendarTrailingForeColor = System.Drawing.Color.Red;
            this.timePicker.Dock = System.Windows.Forms.DockStyle.Left;
            this.timePicker.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timePicker.Location = new System.Drawing.Point(0, 0);
            this.timePicker.Margin = new System.Windows.Forms.Padding(0);
            this.timePicker.MinimumSize = new System.Drawing.Size(4, 35);
            this.timePicker.Name = "timePicker";
            this.timePicker.Size = new System.Drawing.Size(569, 41);
            this.timePicker.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.timePicker.TabIndex = 11;
            this.timePicker.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
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
            // tooltipSuccess
            // 
            this.tooltipSuccess.BackColor = System.Drawing.Color.PaleGreen;
            this.tooltipSuccess.ForeColor = System.Drawing.Color.DarkGreen;
            this.tooltipSuccess.OwnerDraw = true;
            this.tooltipSuccess.ToolTipTitle = "Success";
            this.tooltipSuccess.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.tooltipSuccess_Draw);
            // 
            // CreateShowPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.backgroundPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(800, 425);
            this.Name = "CreateShowPage";
            this.Size = new System.Drawing.Size(1126, 675);
            this.Load += new System.EventHandler(this.CreateShowPage_Load);
            this.backgroundPanel.ResumeLayout(false);
            this.backgroundPanel.PerformLayout();
            this.datePickePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel backgroundPanel;
        private Label lblTitle;
        private Label lblDate;
        private Button btnCreateShow;
        private TextBox txtRoomId;
        private Label lblRoomId;
        private Label lblMovie;
        private FlatDatePicker datePicker;
        private FlatComboBox comboDub;
        private Label lblDubLanguage;
        private Label lblSub;
        private FlatComboBox comboSubtitles;
        private FlatComboBox comboSound;
        private Label lblSound;
        private FlatComboBox comboGraphic;
        private Label lblGraphic;
        private Panel datePickePanel;
        private FlatDatePicker timePicker;
        private FlatComboBox comboMovies;
        private ToolTip tooltipSuccess;
    }
}
