using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1809E_UWP_ASSIGNMENT_TrangDM2.Models
{
    class Song
    {
        public string name { get; set; }
        public string description { get; set; }
        public string singer { get; set; }
        public string author { get; set; }
        public string thumbnail { get; set; }
        public string link { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(name) &&
                    !string.IsNullOrEmpty(description) &&
                    !string.IsNullOrEmpty(author) &&
                    !string.IsNullOrEmpty(singer) &&
                    !string.IsNullOrEmpty(thumbnail);
        }

    }
}
