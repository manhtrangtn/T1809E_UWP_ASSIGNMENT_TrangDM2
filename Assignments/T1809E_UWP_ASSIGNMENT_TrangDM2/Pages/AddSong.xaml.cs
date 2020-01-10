using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Models;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Services;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Services.Implements;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace T1809E_UWP_ASSIGNMENT_TrangDM2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddSong : Page
    {
        private ISongService songService = new SongService();
        private StorageFile songFile;
        public AddSong()
        {
            this.InitializeComponent();
        }

        private async void SelectSong(object sender, RoutedEventArgs e)
        {
            var filePicker = new Windows.Storage.Pickers.FileOpenPicker();
            filePicker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            filePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            filePicker.FileTypeFilter.Add(".mp3");

            Windows.Storage.StorageFile file = await filePicker.PickSingleFileAsync();

            try
            {
                if (file != null)
                {
                    songFile = file;
                    songNameVisis.Text = songFile.Name;
                }
                else
                {
                    songAlert.Text = "Please choose the song!";
                }
            }
            catch
            {
                songAlert.Text = "Failed to upload song!";
            }

        }

        private async void UploadSong(object sender, RoutedEventArgs e)
        {
            Song song = new Song();
            song.author = AuthorName.Text;
            song.name = SongName.Text;
            song.thumbnail = Thubnail.Text;
            song.description = Description.Text;
            song.singer = Singer.Text;
            try
            {
                Debug.WriteLine("TOKEN: "+ApplicationLayout.token);
                if (song.IsValid())
                {
                    LoadingRing();
                    var songUrl = await songService.UploadSongToDriver(songFile);
                    song.link = (string)JObject.Parse(songUrl)["url"];
                    var songUpload = await songService.AddSong(song, ApplicationLayout.token);
                    var status = (string)JObject.Parse(songUpload)["status"];
                    if (status == "1")
                    {
                        songAlert.Text = "Upload successfully!";
                        submit.IsEnabled = false;
                    }
                }
                else
                {
                    songAlert.Text = "Please fill all field before upload.";
                }
            } catch
            {
                songAlert.Text = "Failed to upload song!";
            }
            loading.Visibility = Visibility.Collapsed;
            loading.IsActive = false;
            MainContent.Visibility = Visibility.Visible;
        }

        private void LoadingRing()
        {
            MainContent.Visibility = Visibility.Collapsed;
            loading.Visibility = Visibility.Visible;
            loading.IsActive = true;
        }
    }
}
