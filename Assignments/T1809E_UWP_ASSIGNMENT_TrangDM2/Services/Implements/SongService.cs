using DocumentFormat.OpenXml.Office2010.CustomUI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Models;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Utils;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace T1809E_UWP_ASSIGNMENT_TrangDM2.Services.Implements
{
    class SongService: ISongService
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly IFileIoService fileIoService = new FileIoService();
        public async Task<String> GetNewSongs(string token)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, Constants.GET_NEW_SONG_URL);
            httpRequestMessage.Headers.Add("Authorization", token);
            var resp = await httpClient.SendAsync(httpRequestMessage);
            return await resp.Content.ReadAsStringAsync();
        }

        public async Task<String> GetMySongs(string token)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, Constants.GET_MY_SONG_URL);
            httpRequestMessage.Headers.Add("Authorization", token);
            var resp = await httpClient.SendAsync(httpRequestMessage);
            return await resp.Content.ReadAsStringAsync();
        }

        public async Task<String> AddSong(Song song, string token)
        {

            Debug.WriteLine("Songservice: "+song.link);
            var jsonData = JsonConvert.SerializeObject(song);
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, Constants.JSON_CONTENT_TYPE);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            var resp = await httpClient.PostAsync(Constants.ADD_SONG_URL, content);
            return await resp.Content.ReadAsStringAsync();
        }

        public async Task<string> UploadSongToDriver(StorageFile file)
        {
            return await fileIoService.HttpUploadFile(Constants.UPLOAD_SONG, "myFile", "music/mp3", file);
        }
    }
}
