using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
