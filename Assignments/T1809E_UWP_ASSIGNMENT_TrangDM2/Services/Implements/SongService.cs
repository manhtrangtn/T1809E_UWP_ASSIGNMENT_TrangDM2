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
            HttpClient client = new HttpClient();
            return await HttpUploadFile(Constants.UPLOAD_SONG, "myFile", "music/mp3", file);
        }

        public async Task<string> HttpUploadFile(string url, string paramName, string contentType, StorageFile fi)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";

            Stream rs = await wr.GetRequestStreamAsync();
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string header = string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n", paramName, "path_file", contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);
                    
            // write file.
            Stream fileStream = await fi.OpenStreamForReadAsync();
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);

            WebResponse wresp = null;
            try
            {
                wresp = await wr.GetResponseAsync();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                var songUrl = reader2.ReadToEnd();
                return songUrl;
            }
            catch
            {
                if (wresp != null)
                {
                    wresp = null;
                }
                return null;
            };
        }
    }
}
