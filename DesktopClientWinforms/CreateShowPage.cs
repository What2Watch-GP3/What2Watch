using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopApiClient;
using DesktopApiClient.DTOs;

namespace DesktopClientWinforms
{
    public partial class CreateShowPage : UserControl
    {
        private IWhatToWatchApiClient _client;

        public CreateShowPage(IWhatToWatchApiClient client)
        {
            _client = client;
        }

        public CreateShowPage()
        {
            InitializeComponent();
        }

        private void btnCreateShow_Click(object sender, EventArgs e)
        {
            CreateShow();
        }

        private void CreateShow()
        {
            ShowDto show = new ShowDto() 
            { 
                StartTime = datePicker.Value,
                RoomId = int.Parse(txtRoomId.Text),
                MovieId = int.Parse(txtMovieId.Text)
            };
            _client.CreateShowAsync(show);
        }

        private void OnLoad()
        {
            datePicker.CalendarMonthBackground = Color.FromArgb(60,60,65);
            datePicker.CalendarTitleBackColor = Color.FromArgb(40,40,50);
        }

        private void txtRoomId_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar));
        }

        private void txtMovieId_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar));
        }

        private void CreateShowPage_Load(object sender, EventArgs e)
        {
            OnLoad();
        }
    }
}
