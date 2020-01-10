using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1809E_UWP_ASSIGNMENT_TrangDM2.Utils
{
    public class Constants
    {
        //Regex
        public static readonly string EMAIL_RULE = "^[a-z][a-z0-9_.]{5,32}@[a-z0-9]{2,}(.[a-z0-9]{2,4}){1,2}$";
        public static readonly string PHONE_RULE = "^[+][8][4](09|08|03|01[1-9])+([0-9]{8})$";
        public static readonly string VALID_INPUT = "^[a-zA-Z0-9.,-_ ]{0,2000}$";
        public static readonly string VALID_MUSIC_LINK = "^.+(.mp3|.wav|.m4a)$";
        //Content Type
        public static readonly string JSON_CONTENT_TYPE = "application/json";
        //URL
        public static readonly string UPLOAD_SONG = "http://2-dot-backup-server-002.appspot.com/upload-file-handle";
        public static readonly string ADD_SONG_URL = "https://2-dot-backup-server-002.appspot.com/_api/v2/songs";
        public static readonly string GET_MY_SONG_URL = "https://2-dot-backup-server-002.appspot.com/_api/v2/songs/get-mine";
        public static readonly string GET_NEW_SONG_URL = "https://2-dot-backup-server-002.appspot.com/_api/v2/songs";
        public static readonly string REGISTER_URL = "https://2-dot-backup-server-002.appspot.com/_api/v2/members";
        public static readonly string LOGIN_URL = "https://2-dot-backup-server-002.appspot.com/_api/v2/members/authentication";
        public static readonly string GETMEMBER_URL = "https://2-dot-backup-server-002.appspot.com/_api/v2/members/information";
    }
}
