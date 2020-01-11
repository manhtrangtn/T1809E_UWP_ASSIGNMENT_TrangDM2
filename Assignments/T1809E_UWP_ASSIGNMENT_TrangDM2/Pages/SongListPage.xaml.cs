using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Models;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Services;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Services.Implements;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
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
    public sealed partial class SongListPage : Page
    {
        private Song currentSong;
        private ISongService _songService = new SongService();
        private bool _isPlaying = false;
        private List<Song> songs = new List<Song>();
        private static bool IsLoop = false;
        private static bool IsShuffle = false;
        public SongListPage()
        {
            this.InitializeComponent();
            //this.MyPlayer.MediaPlayer.MediaEnded += this.PlayerEndedHandle;
        }
        private async void LoadSongList(object sender, RoutedEventArgs e)
        {
            StartLoad();
            var listSong = await _songService.GetMySongs(ApplicationLayout.token);
            songs = JsonConvert.DeserializeObject<List<Song>>(listSong);
            Songs.ItemsSource = songs;
            LoadDone();
        }
        private void SongSelectedHandle(object sender, ItemClickEventArgs e)
        {
            currentSong = e.ClickedItem as Song;
            PlaySong(currentSong);
        }
        [Obsolete]
        private void PlayPauseHandle(object sender, RoutedEventArgs e)
        {
            if (Songs.ItemsSource == null) return;
            if (currentSong == null)
            {
                try
                {
                    currentSong = songs.FirstOrDefault();
                    MyPlayer.Source = MediaSource.CreateFromUri(new Uri(currentSong.link));
                    Songs.SelectedIndex = 0;
                } catch
                {
                    return;
                }
                
            }

            if (_isPlaying)
            {
                MyPlayer.MediaPlayer.Pause();
                PlayButton.Icon = new SymbolIcon(Symbol.Play);
                StatusText.Text = "Paused";
                _isPlaying = false;
            }
            else
            {
                MyPlayer.MediaPlayer.Play();
                PlayButton.Icon = new SymbolIcon(Symbol.Pause);
                StatusText.Text = "Now Playing: " + currentSong.name;
                _isPlaying = true;
            }
        }
        private void NextHandle(object sender, RoutedEventArgs e)
        {
            var currentIndex = Songs.SelectedIndex;
            currentIndex++;
            if (currentIndex >= Songs.Items.Count)
            {
                currentIndex = 0;
            }
            PlaySongAtIndex(currentIndex);
        }
        private void PreviousHandle(object sender, RoutedEventArgs e)
        {
            var currentIndex = Songs.SelectedIndex;
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = Songs.Items.Count-1;
            }
            PlaySongAtIndex(currentIndex);
        }
        private void MySongsHandle(object sender, RoutedEventArgs e)
        {
            LoadSongList(sender, e);
        }
        private async void NewSongsHandle(object sender, RoutedEventArgs e)
        {
            StartLoad();
            var listSong = await _songService.GetNewSongs(ApplicationLayout.token);
            songs = JsonConvert.DeserializeObject<List<Song>>(listSong);
            Songs.ItemsSource = songs;
            LoadDone();
        }
        private void RepeatHandle(object sender, RoutedEventArgs e)
        {
            IsLoop = !IsLoop;
            MyPlayer.MediaPlayer.IsLoopingEnabled = IsLoop;
        }
        private void ShuffleHandle(object sender, RoutedEventArgs e)
        {
            IsShuffle = !IsShuffle;
        }
        private void PlayerEndedHandle(MediaPlayer sender, object args)
        {
            if (IsShuffle)
            {
                ShufflePlay();
            }
            else
            {
                NextHandle(sender, new RoutedEventArgs());
            }
        }
        private void ShufflePlay()
        {
            Random r = new Random();
            PlaySongAtIndex(r.Next(0, songs.Count));
        }
        private void StartLoad()
        {
            ListSongs.Visibility = Visibility.Collapsed;
            loading.Visibility = Visibility.Visible;
            loading.IsActive = true;
        }
        private void LoadDone()
        {
            ListSongs.Visibility = Visibility.Visible;
            loading.IsActive = false;
            loading.Visibility = Visibility.Collapsed;
        }
        private void PlaySongAtIndex(int currentIndex)
        {
            currentSong = Songs.Items[currentIndex] as Song;
            Songs.SelectedIndex = currentIndex;
            PlaySong(currentSong);
        }
        private void PlaySong(Song song)
        {
            MyPlayer.Source = MediaSource.CreateFromUri(new Uri(song.link));
            MyPlayer.MediaPlayer.Play();
            PlayButton.Icon = new SymbolIcon(Symbol.Pause);
            _isPlaying = true;
            StatusText.Text = "Now Playing: " + currentSong.name;
        }
    }
}
