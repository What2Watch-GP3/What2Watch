using DesktopApiClient;
using DesktopApiClient.DTOs;
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
    public partial class LoginPage : UserControl, IPage

    {
        private IDesktopApiClient _client;
        private Panel _parent;
        public IButtonControl AcceptButton { get; set; }

        public LoginPage(IDesktopApiClient client, Panel parent)
        {
            _parent = parent;
            _client = client;
            InitializeComponent();
            AcceptButton = btnLogin;
        }

        private async Task Login()
        {
            UserDto userDto = new()
            {
                Email = txtEmail.Text,
                Password = txtPassword.Text
            };
            userDto = await _client.LoginAsync(userDto);
            if (userDto != null)
            {
                HomePage homePage = new HomePage(_client, _parent);
                homePage.Dock = DockStyle.Fill;
                _parent.Controls.Remove(this);
                _parent.Controls.Add(homePage);
            }
            errorPanel.Visible = true;
        }

        private void OnLoad()
        {
            inputPanel.Left = (this.ClientSize.Width - inputPanel.Width) / 2;
            inputPanel.Top = (this.ClientSize.Height - inputPanel.Height) / 2;
        }

        private void ErrorPanelPaint(Graphics graphics)
        {
            ControlPaint.DrawBorder(graphics, errorPanel.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
        }

        #region Component Events
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            await Login();
        }
        
        private void LoginPage_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        private void errorPanel_Paint(object sender, PaintEventArgs e)
        {
            ErrorPanelPaint(e.Graphics);
        }
        #endregion
    }
}

