using HRApplication_WPF.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HRApplication_WPF.Models
{
    public class UserSettings :IDataErrorInfo
    {
        public string this[string columnName]
        { 
            get
            {
                switch (columnName)
                {
                    case nameof(ServerAddress):
                        if (string.IsNullOrWhiteSpace(ServerAddress))
                        {
                            Error = "Adres serwera bazy danych jest wymagany";
                            _isServerAddressValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isServerAddressValid = true;
                        }
                    break;
                    case nameof(ServerName):
                        if (string.IsNullOrWhiteSpace(ServerName))
                        {
                            Error = "Nazwa serwera bazy danych jest wymagany";
                            _isServerNameValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isServerNameValid = true;
                        }
                    break;
                    case nameof(DataBaseName):
                        if (string.IsNullOrWhiteSpace(DataBaseName))
                        {
                            Error = "Nazwa bazy danych jest wymagana";
                            _isDataBaseNameValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isDataBaseNameValid = true;
                        }
                    break;
                    case nameof(DbUserName):
                        if (string.IsNullOrWhiteSpace(DbUserName))
                        {
                            Error = "Nazwa użytkownika bazy danych jest wymagana";
                            _isDbUserNameValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isDbUserNameValid = true;
                        }
                    break;
                    case nameof(DbUserPassword):
                        if (string.IsNullOrWhiteSpace(DbUserPassword))
                        {
                            Error = "Hasło użytkownika bazy danych jest wymagane";
                            _isDbUserPasswordValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isDbUserPasswordValid = true;
                        }
                    break;

                    default:
                    break;
                }
                return Error;
            }
        }

        private bool _isServerAddressValid;
        private bool _isServerNameValid;
        private bool _isDataBaseNameValid;
        private bool _isDbUserNameValid;
        private bool _isDbUserPasswordValid;
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
        public string DbUserName
        {
            get
            {
                return Settings.Default.DbUserName;
            }
            set
            {
                Settings.Default.DbUserName = value;
            }
        }
        public string DbUserPassword
        {
            get
            {
                return Settings.Default.DbUserPassword;
            }
            set
            {
                Settings.Default.DbUserPassword = value;
            }
        }
        public string Error { set; get; }
        public bool IsValid
        {
            get
            {
                return _isServerAddressValid &&
                _isServerNameValid &&
                _isDataBaseNameValid &&
                _isDbUserNameValid &&
                _isDbUserPasswordValid;
            }
        }

        public void Save()
        {   
            Settings.Default.Save();
        }
    }

}
