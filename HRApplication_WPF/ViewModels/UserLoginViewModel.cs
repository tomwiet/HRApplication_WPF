using HRApplication_WPF.Commands;
using HRApplication_WPF.Models;
using HRApplication_WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HRApplication_WPF.ViewModels
{
    internal class UserLoginViewModel :ViewModelBase
    {
        private bool _isLoged = false;
        public UserLoginViewModel()
        {
            ConfirmCommand = new RelayCommand(Confirm);
            CancelCommand = new RelayCommand(Cancel);
      
        }

        private bool IfLoginDataValid()
        {
            var passwordSha1 = Users.GetSha1PasswordString(UserPassword);
            
            return Users.UserName == UserLogin &&
                    Users.Password == passwordSha1;
                
        }

        private void Confirm(object obj)
        {
            if (IfLoginDataValid())
                CloseWindow(obj as Window);
            else
                ErrorLoginMessage = "Nieprawidłowe dane logowania";
            
        }

        private void Cancel(object obj)
        {
            Application.Current.Shutdown();
        }
        private void CloseWindow(Window window)
        {
            window.Close();
        }

        public ICommand CancelCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }

        private string _userlogin;
        public string UserLogin
        {
            get 
            { 
                return _userlogin; 
            }
            set 
            { 
                _userlogin = value;
                OnPropertyChanged();
            }
        }
        private string _userPassword;
        public string UserPassword
        {
            get 
            { 
                return _userPassword; 
            }
            set 
            { 
                _userPassword = value;
                OnPropertyChanged();
            }
        }
        private string _errorLoginMessage;
        public string ErrorLoginMessage
        {
            get 
            { 
                return _errorLoginMessage; 
            }
            set 
            { 
                _errorLoginMessage = value;
                OnPropertyChanged();
            }
        }


    }
}
