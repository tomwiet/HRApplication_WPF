using HRApplication_WPF.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HRApplication_WPF.Models
{
    public class UserSettings
    {
        
		public string ServerAddress
		{
			get { 
				return Settings.Default.ServerAddress; 
			}
			set 
            { 
				Settings.Default.ServerAddress = value;
               
			}
		}

        public string ServerName
        {
            get
            {
                return Settings.Default.ServerName;
            }
            set
            {
                Settings.Default.ServerName = value;
            }
        }

        public string DataBaseName
        {
            get
            {
                return Settings.Default.DataBaseName;
            }
            set
            {
                Settings.Default.DataBaseName = value;
            }
        }
        public string UserName
        {
            get
            {
                return Settings.Default.UserName;
            }
            set
            {
                Settings.Default.UserName = value;
            }
        }
        public string UserPassword
        {
            get
            {
                return Settings.Default.UserPassword;
            }
            set
            {
                Settings.Default.UserPassword = value;
            }
        }

        public void Save()
        {
            Settings.Default.Save();
        }
    }
}
