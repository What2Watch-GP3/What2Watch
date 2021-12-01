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
using Tools.Enums;

namespace DesktopClientWinforms
{
    public partial class CreateShowPage : UserControl
    {
        private IWhatToWatchApiClient _client;

        public CreateShowPage(IWhatToWatchApiClient client)
        {
            InitializeComponent();
            _client = client;
        }

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

        private void CreateShow()
        {
            Enum.TryParse(comboDub.SelectedItem.ToString(), out Language dubLanguage);
            Enum.TryParse(comboSubtitles.SelectedItem.ToString(), out Language subLanguage);
            Enum.TryParse(comboGraphic.SelectedItem.ToString(), out GraphicType graphicType);
            Enum.TryParse(comboSound.SelectedItem.ToString(), out SoundType soundType);
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
            loadLanguageComboBoxes();
            loadSoundComboBox();
            loadGraphicComboBox();
        }

        private void loadSoundComboBox()
        {
            foreach (var soundType in Enum.GetValues(typeof(SoundType)))
            {
                comboSound.Items.Add(soundType);
            }
        }

        private void loadGraphicComboBox()
        {
            foreach (var graphicType in Enum.GetValues(typeof(GraphicType)))
            {
                comboGraphic.Items.Add(graphicType);
            }
        }

        private void loadLanguageComboBoxes()
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
