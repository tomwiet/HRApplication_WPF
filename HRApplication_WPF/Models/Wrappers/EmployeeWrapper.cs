using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApplication_WPF.Models.Wrappers
{
    public class EmployeeWrapper : IDataErrorInfo
    {

        public int Id { get; set; }
        
        public int EmploymentPeriodId { get; set; }
        public string FirstName {  get; set; }
        public string LastName {  get; set; }
        public decimal Earnings {  get; set; }
        public DateTime EmploymentDate {  get; set; }
        public DateTime? DismissDate {  get; set; }
        public string Error {  get; set; }

        private bool _isFirstNameValid;
        private bool _isLastNameValid;
        private bool _isEarningsValid;
        private bool _isEmploymentDateValid;
        public string this[string columnName]
        {
            get 
            {
                switch (columnName)
                {
                    case nameof(FirstName):
                        if (string.IsNullOrWhiteSpace(FirstName))
                        {
                            Error = "Imię pracownika nie może być puste";
                            _isFirstNameValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isFirstNameValid = true;
                        }
                    break;
                    case nameof(LastName):
                        if (string.IsNullOrWhiteSpace(LastName))
                        {
                            Error = "Imię pracownika nie może być puste";
                            _isLastNameValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isLastNameValid = true;
                        }
                    break;
                    case nameof(Earnings):
                        if (Earnings == 0)
                        {
                            Error = "Musisz podac kwotę inną niz 0 zł";
                            _isEarningsValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isEarningsValid = true;
                        }
                        break;
                    case nameof(EmploymentDate):
                        if (string.IsNullOrEmpty(EmploymentDate.Date.ToString()))
                        {
                            Error = "Data zatrudnienia nie może być pusta";
                            _isEmploymentDateValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isEmploymentDateValid = true;
                        }
                        break;

                }
                return Error;
            }
        }

        public bool IsValid()
        {
            return _isFirstNameValid && 
                   _isLastNameValid &&
                   _isEarningsValid &&
                   _isEmploymentDateValid;
        }
    }
}
