using HRApplication_WPF.Models;
using HRApplication_WPF.Models.Wrappers;
using HRApplication_WPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace HRApplication_WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
      private Repository _repository = new Repository();
        public MainWindowViewModel()
        {
            setEmployementStatusComboBox();
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

        private void setEmployementStatusComboBox()
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
