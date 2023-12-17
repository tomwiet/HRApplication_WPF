using HRApplication_WPF.Commands;
using HRApplication_WPF.Model.Domains;
using HRApplication_WPF.Models.Wrappers;
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
    public class AddEditEmployeeViewModel : ViewModelBase
    {
		private Repository _repository = new Repository();

        public AddEditEmployeeViewModel(EmployeeWrapper employee =null)
        {
			CloseCommand = new RelayCommand(Close);
			
			if(employee == null)
			{
				Employee = new EmployeeWrapper();
			}
			else
			{
				IsUpdate = true;
				Employee = employee;
			}
				

					

        }

        private void Close(object obj)
        {
			CloseWindow(obj as Window);
        }
		private void CloseWindow(Window window)
		{
			window.Close();
		}

        public ICommand CloseCommand { get; set; }

        private EmployeeWrapper _employee;
		public EmployeeWrapper Employee
		{
			get 
			{ 
				return _employee; 
			}
			set 
			{ 
				_employee = value;
				OnPropertyChanged();
			}
		}

		private bool _isUpdate;
        

        public bool IsUpdate
		{
			get 
			{ 
				return _isUpdate; 
			}
			set 
			{ 
				_isUpdate = value;
				OnPropertyChanged();
			}
		}

        
    }
}
