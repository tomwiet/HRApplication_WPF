using HRApplication_WPF.Commands;
using HRApplication_WPF.Models;
using HRApplication_WPF.Models.Wrappers;
using HRApplication_WPF.Views;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Input;

namespace HRApplication_WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Repository _repository = new Repository();
        public MainWindowViewModel()
        {
            AddEmployeeCommand = new RelayCommand(AddEmployee, canAddEmploye);
            SetEmployementStatusComboBox();
            RefreshEmployesData();
            //using(var context = new ApplicationDbContext())
            //{
            //    var employees = context.Employees.ToList();
            //}
        }

        private void RefreshEmployesData()
        {
            Employees = new ObservableCollection<EmployeeWrapper>(
                _repository.GetEmployees());
                   
        }

        public ICommand AddEmployeeCommand { set; get; }


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
                OnPropertychanged();
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
                OnPropertychanged();
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
                OnPropertychanged();
            }
        }

        private bool canAddEmploye(object obj)
        {
            return true;
        }
        private void AddEmployee(object obj)
        {
            var addEditEmployeWindow = 
                new AddEditEmployeeView(obj as EmployeeWrapper);
            addEditEmployeWindow.Closed += AddEditEmployeWindow_Closed;
            addEditEmployeWindow.ShowDialog();
        }

        private void AddEditEmployeWindow_Closed(object sender, EventArgs e)
        {
            //
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
        
    }
}
