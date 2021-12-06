using System;
using System.Windows.Forms;
using DesktopApiClient;
using DesktopApiClient.DTOs;
using Tools.Enums;

namespace DesktopClientWinforms
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
                MovieId = int.Parse(txtMovieId.Text),
                DubLanguage = (Language)comboDub.SelectedItem,
                SubtitlesLanguage = (Language)comboSubtitles.SelectedItem,
                GraphicType = (GraphicType)comboGraphic.SelectedItem,
                SoundType = (SoundType)comboSound.SelectedItem
            };
            _client.CreateShowAsync(show);
        }

        private void OnLoad()
        {
            LoadLanguageComboBoxes();
            LoadSoundComboBox();
            LoadGraphicComboBox();
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
            }
            foreach (var language in Enum.GetValues(typeof(Language)))
            {
                comboDub.Items.Add(language);
            }
        }

        #region Component events
        private void btnCreateShow_Click(object sender, EventArgs e)
        {
            CreateShow();

            txtMovieId.Clear();
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

        private void CreateShowPage_Load(object sender, EventArgs e)
        {
            OnLoad();
        }
        #endregion
    }
}