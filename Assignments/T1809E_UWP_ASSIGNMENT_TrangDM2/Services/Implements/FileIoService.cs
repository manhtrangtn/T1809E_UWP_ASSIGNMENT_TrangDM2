using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace T1809E_UWP_ASSIGNMENT_TrangDM2.Services.Implements
{
    class FileIoService : IFileIoService
    {
        public async Task<string> ReadFile(string fileName)
        {
            try
            {
                var storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                var sampleFile = await storageFolder.CreateFileAsync(fileName,
                    Windows.Storage.CreationCollisionOption.OpenIfExists);
                return await FileIO.ReadTextAsync(sampleFile);
            } catch
            {
                return null;
            }
            
        }
        public async void WriteToFile(string fileName, string content)
        {
            var storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var sampleFile = await storageFolder.CreateFileAsync(fileName,
                    Windows.Storage.CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(sampleFile, content);
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
