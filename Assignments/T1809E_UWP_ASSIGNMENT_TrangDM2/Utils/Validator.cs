using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace T1809E_UWP_ASSIGNMENT_TrangDM2.Utils
{
    class Validator
    {
        public bool IsNotNullAndNotEmpty(string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        public bool IsPasswordMatch(string password1, string password2)
        {
            return password1.Equals(password2);
        }

        public bool IsPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, Constants.PHONE_RULE);
        }

        public bool IsEmail(string email)
        {
            return Regex.IsMatch(email, Constants.EMAIL_RULE);
        }

        public bool IsValidInput(string str)
        {
            return Regex.IsMatch(str, Constants.VALID_INPUT);
        }

        public bool IsMusicLink(string link)
        {
            return Regex.IsMatch(link, Constants.VALID_MUSIC_LINK);
        }
    }
}
