using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HRApplication_WPF.Models
{
    public static class Users
    {
        public const string UserName = "tw";
        public const string Password = "8B-E3-C9-43-B1-60-9F-FF-BF-C5-1A-AD-66-6D-0A-04-AD-F8-3C-9D";

        public static string GetSha1PasswordString(string password)
        {
            using (var sha1 = new SHA1Managed())
            {
                if (!string.IsNullOrEmpty(password))
                    return BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
                return string.Empty;
            }
        }

    }
}
