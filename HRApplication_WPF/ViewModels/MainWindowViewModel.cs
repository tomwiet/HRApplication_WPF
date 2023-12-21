using HRApplication_WPF.Commands;
using HRApplication_WPF.Models;
using HRApplication_WPF.Models.Wrappers;
using HRApplication_WPF.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Input;

namespace HRApplication_WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Repository _repository = new Repository();
        public MainWindowViewModel()
        {
            AddEmployeeCommand = new RelayCommand(AddEditEmployee, canAddEmployee);
            EditEmployeeCommand = new RelayCommand(AddEditEmployee, canEditEmployee);
            DismissEmployeeCommand = new AsyncRelayCommand(DismissEmployee, canDismissEmploye);
            ComboBoxSelectionChangeCommand = new RelayCommand(ComboBoxSelectionChange);
            UserSettingsCommand = new RelayCommand(Settings);

            SetEmployementStatusComboBox();
            RefreshEmployesData();
   
        }

        private void Settings(object obj)
        {
            var settingWindow = new UserSettingsView();
            settingWindow.ShowDialog();
        }

        public ICommand AddEmployeeCommand { set; get; }
        public ICommand EditEmployeeCommand {set; get; }
        public ICommand DismissEmployeeCommand { set; get; }
        public ICommand ComboBoxSelectionChangeCommand { set; get; }
        public ICommand UserSettingsCommand { set; get; }

        private ObservableCollection<EmployeeWrapper> _employees;
        public ObservableCollection<EmployeeWrapper> Employees
        {
            get 
            { 
                return _employees; 
            }
            set 
            {
                _employees = value;
                OnPropertyChanged();
            }
        }

        private EmployeeWrapper _selectedEmployee;
        public EmployeeWrapper SelectedEmployee
        {
            get 
            { 
                return _selectedEmployee; 
            }
            set 
            { 
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        private List<EmployementStatusWrapper> _employementStatusWrapper;
        public List<EmployementStatusWrapper> EmployementStatusWrapperList
        {
            get 
            {
                return _employementStatusWrapper;
            }
            set 
            {
                _employementStatusWrapper = value;
                OnPropertyChanged();
            }
        }

        private int _employementStatusWrapperId;
        public int EmployementStatusWrapperId
        {
            get 
            { 
                return _employementStatusWrapperId; 
            }
            set 
            { 
                _employementStatusWrapperId = value;
                OnPropertyChanged();
            }
        }
        private void AddEditEmployee(object obj)
        {
           var addEditEmployeWindow = 
           new AddEditEmployeeView(obj as EmployeeWrapper);
           addEditEmployeWindow.Closed += AddEditEmployeWindow_Closed;
           addEditEmployeWindow.ShowDialog();
        }
        private void AddEditEmployeWindow_Closed(object sender, EventArgs e)
        {
            RefreshEmployesData();
        }
        private bool canAddEmployee(object obj)
        {
            return true;
        }
        private bool canEditEmployee(object obj)
        {
            if (SelectedEmployee == null)
                return false;

            return true;
        }
        public void SetEmployementStatusComboBox()
        {
            
            EmployementStatusWrapperList = 
                Enum.GetValues(typeof(EmployementStatus))
                                            .Cast<EmployementStatus>()
                                            .Select(x => 
                                                new EmployementStatusWrapper 
                                                { 
                                                    Id = (int)x,
                                                    Name = x.ToString() 
                                                })
                                            .ToList();
            EmployementStatusWrapperId = 0;
        }
        private void RefreshEmployesData(int employementStatusId = 0)
        {
            if(employementStatusId == 0)
                Employees = new ObservableCollection<EmployeeWrapper>(
                    _repository.GetEmployees());
            if (employementStatusId == 1)
                Employees = new ObservableCollection<EmployeeWrapper>(
                    _repository.GetActualEmployees());
            if (employementStatusId == 2)
                Employees = new ObservableCollection<EmployeeWrapper>(
                    _repository.GetDismissedEmployees());


        }
        private bool canDismissEmploye(object obj)
        {
            if(SelectedEmployee != null && SelectedEmployee.DismissDate == null)
                return true;

            return false;
                
        }
        private async Task DismissEmployee(object obj)
        {
            var dismissWindow = Application.Current.MainWindow as MetroWindow;
            var dialog = await dismissWindow.ShowMessageAsync("Zwolnij pracownika",
                $"Czy chcesz zwolnic pracownika " +
                $"{SelectedEmployee.FirstName} " +
                $"{SelectedEmployee.LastName}?",
                MessageDialogStyle.AffirmativeAndNegative);

            if (dialog != MessageDialogResult.Affirmative)
                return;
            
            _repository.DismissEmployee(SelectedEmployee.EmploymentPeriodId);
            
            RefreshEmployesData();

        }
        private void ComboBoxSelectionChange(object arg)
        {
            RefreshEmployesData(EmployementStatusWrapperId);
        }
    }
}
