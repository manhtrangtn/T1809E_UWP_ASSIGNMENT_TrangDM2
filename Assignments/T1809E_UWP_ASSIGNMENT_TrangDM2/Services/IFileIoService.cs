using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace T1809E_UWP_ASSIGNMENT_TrangDM2.Services
{
    interface IFileIoService
    {
        Task<string> ReadFile(string fileName);
        void WriteToFile(string fileName, string content);
        Task<string> HttpUploadFile(string url, string paramName, string contentType, StorageFile fi);
    }
}
