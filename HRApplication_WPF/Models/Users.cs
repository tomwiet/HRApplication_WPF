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
        public const string Password = "Password";

        public static string GetSha1PasswordString(string password)
        {
            using (var sha1 = new SHA1Managed())
            {
                return BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }

    }
}
