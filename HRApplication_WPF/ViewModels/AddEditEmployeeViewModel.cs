﻿using HRApplication_WPF.Commands;
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

        public AddEditEmployeeViewModel(EmployeeWrapper employee = null)
        {
			CloseCommand = new RelayCommand(Close);
			ConfirmCommand = new RelayCommand(Confirm);
			
			
			
			if(employee == null)
			{
				IsUpdate = false;
				Employee = new EmployeeWrapper();
				Employee.EmploymentDate = DateTime.Now;
				
			}
			else
			{
				IsUpdate = true;
                IsEmployed = true;
                Employee = employee;

				if(Employee.DismissDate == null )
					IsEmployed = false;
			
			}
        }
        public ICommand CloseCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }

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
		private bool _isUpdateOrEmployed;
		public bool IsEmployed
        {
			get { return _isUpdateOrEmployed; }
			set { _isUpdateOrEmployed = value; }
		}
        private void Confirm(object obj)
        {
			if (Employee.IsValid)
			{
				if (!IsUpdate)
					AddEmployee();	
				else
					UpdateEmployee();

				CloseWindow(obj as Window);
			}
			else
				return;
            
        }
        private void UpdateEmployee()
        {
            _repository.UpdateEmployee(Employee);
        }
        private void AddEmployee()
        {
            _repository.AddEmployee(Employee);
        }
        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }
        private void CloseWindow(Window window)
        {
            window.Close();
        }

    }
}
