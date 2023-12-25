using HRApplication_WPF.Commands;
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
        public UserLoginViewModel()
        {
            ConfirmCommand = new RelayCommand(Confirm);
            CancelCommand = new RelayCommand(Cancel);
                
        }

        private void Confirm(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void Cancel(object obj)
        {
            Application.Current.MainWindow.Close();
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

    }
}
