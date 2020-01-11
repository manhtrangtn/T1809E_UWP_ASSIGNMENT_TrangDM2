using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Models;
using Windows.Storage;

namespace T1809E_UWP_ASSIGNMENT_TrangDM2.Services
{
    interface ISongService
    {
        Task<String> GetNewSongs(String token);
        Task<String> GetMySongs(String token);
        Task<String> AddSong(Song song, String token);
        Task<string> UploadSongToDriver(StorageFile file);
    }
}
