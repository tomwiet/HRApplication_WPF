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
        private bool _canCloseWindow;
        public UserSettingsViewModel(bool canCloseWindow)
        {
            ConfirmCommand = new RelayCommand(Confirm);
            CloseCommand = new RelayCommand(Close);

            _userSettings = new UserSettings();
            _canCloseWindow = canCloseWindow;

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

        private void Close(object obj)
        {
            if (_canCloseWindow)
                CloseWindow(obj as Window);
            else
                Application.Current.Shutdown();

        }
        private void CloseWindow(Window window)
        {
            window.Close();
        }
        private void Confirm(object obj)
        {
            if (!UserSettings.IsValid)
                return;

            UserSettings.Save();
            RestartApplication();
        }
        private void RestartApplication()
        {
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

    }
}
