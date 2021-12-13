using DesktopApiClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopClientWinforms.Pages
{
    public partial class HomePage : UserControl
    {
        private IDesktopApiClient _client;
        private Panel _parent;

        public HomePage(IDesktopApiClient client, Panel parent)
        {
            _parent = parent;
            _client = client;
            InitializeComponent();
        }

        private async Task OpenPage(UserControl page)
        {
            page.Dock = DockStyle.Fill;
            _parent.Controls.Remove(this);
            _parent.Controls.Add(page);
        }

        private async Task OnLoad()
        {
            buttonPanel.Left = (this.ClientSize.Width - buttonPanel.Width) / 2;
            buttonPanel.Top = (this.ClientSize.Height - buttonPanel.Height) / 2;
        }

        private async void btnCreateShow_Click(object sender, EventArgs e)
        {
            await OpenPage(new CreateShowPage(_client));
        }

        private async void HomePage_Load(object sender, EventArgs e)
        {
            await OnLoad();
        }
    }
}
