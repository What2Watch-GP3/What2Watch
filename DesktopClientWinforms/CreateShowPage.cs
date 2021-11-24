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

namespace DesktopClientWinforms
{
    public partial class CreateShowPage : UserControl
    {
        private WhatToWatchApiClient _client;

        public CreateShowPage(WhatToWatchApiClient client)
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
            //TODO call desktop api client to create the show
        }

        private void txtRoomId_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar));
        }

        private void txtMovieId_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar));
        }
    }
}
