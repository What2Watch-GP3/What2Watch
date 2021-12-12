using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopApiClient;
using DesktopApiClient.DTOs;
using Tools.Enums;

namespace DesktopClientWinforms.Pages
{
    public partial class CreateShowPage : UserControl
    {
        private IDesktopApiClient _client;

        public CreateShowPage(IDesktopApiClient client)
        {
            _client = client;
            InitializeComponent();
        }

        private void CreateShow()
        {
            ShowDto show = new()
            {
                StartTime = datePicker.Value.Date + timePicker.Value.TimeOfDay,
                RoomId = int.Parse(txtRoomId.Text),
                MovieId = ((MovieDto)comboMovies.SelectedItem).Id,
                DubLanguage = (Language)comboDub.SelectedItem,
                SubtitlesLanguage = (Language)comboSubtitles.SelectedItem,
                GraphicType = (GraphicType)comboGraphic.SelectedItem,
                SoundType = (SoundType)comboSound.SelectedItem
            };
            _client.CreateShowAsync(show);
        }

        private async Task OnLoad()
        {
            LoadLanguageComboBoxes();
            LoadSoundComboBox();
            LoadGraphicComboBox();
            await LoadAllMoviesComboBox();
        }

        private async Task LoadAllMoviesComboBox()
        {
            comboMovies.DataSource = await _client.GetAllMoviesAsync();
            
        }

        private void LoadSoundComboBox()
        {
            foreach (var soundType in Enum.GetValues(typeof(SoundType)))
            {
                comboSound.Items.Add(soundType);
            }
        }

        private void LoadGraphicComboBox()
        {
            foreach (var graphicType in Enum.GetValues(typeof(GraphicType)))
            {
                comboGraphic.Items.Add(graphicType);
            }
        }

        private void LoadLanguageComboBoxes()
        {
            foreach(var language in Enum.GetValues(typeof(Language)))
            {
                comboSubtitles.Items.Add(language);
                comboDub.Items.Add(language);
            }
        }

        #region Component events
        private void btnCreateShow_Click(object sender, EventArgs e)
        {
            CreateShow();

            comboMovies.Text = "";
            txtRoomId.Clear();
            comboDub.Text = "";
            comboGraphic.Text = "";
            comboSound.Text = "";
            comboSubtitles.Text = "";
        }

        private void txtRoomId_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar));
        }

        private void txtMovieId_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar));
        }

        private async void CreateShowPage_Load(object sender, EventArgs e)
        {
            await OnLoad();
        }
        #endregion
    }
}