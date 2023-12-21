using HRApplication_WPF.Commands;
using HRApplication_WPF.Models;
using HRApplication_WPF.Properties;
using HRApplication_WPF.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HRApplication_WPF.ViewModels
{
    public class UserSettingsViewModel : ViewModelBase
    {
        private UserSettings _userSettings;
        public UserSettingsViewModel()
        {
            ConfirmCommand = new RelayCommand(Confirm);
            CloseCommand = new RelayCommand(Close);

            _userSettings = new UserSettings();



        }

        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void CloseWindow(Window window)
        {
            window.Close();
        }

        private void Confirm(object obj)
        {
            //walidacja
            UserSettings.Save();
            RestartApplication();
        }

        private void RestartApplication()
        {
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
        public ICommand ConfirmCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        public UserSettings UserSettings
        {
            get 
            { 
                return _userSettings; 
            }
            set 
            { 
                _userSettings = value;
                OnPropertyChanged();
            }
        }

        
        
    }
}
