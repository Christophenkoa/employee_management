using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Collections.ObjectModel;
using MvvmDemo.Models;
using MvvmDemo.Commands;

namespace MvvmDemo.ViewModels
{
    public class EmployeeViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        
        EmployeeService ObjEmployeeService;
        public EmployeeViewModel()
        {
            ObjEmployeeService = new EmployeeService();
            LoadData();
            CurrentEmployee = new Employee();
            saveCommand = new RelayCommand(Save);
        }

        private ObservableCollection<Employee> employeesList;

        public ObservableCollection<Employee> EmployeesList
        {
            get { return employeesList; }
            set { employeesList = value; OnPropertyChanged("EmployeesList"); }
        }

        private void LoadData()
        {
            EmployeesList = new ObservableCollection<Employee> (ObjEmployeeService.GetAll());
        }

        private Employee currentEmployee;

        public Employee CurrentEmployee
        {
            get { return currentEmployee;  }
            set { currentEmployee = value; OnPropertyChanged("CurrentEmployee"); }
        }

        private string message;

        public string Message
        {
            get { return message;  }
            set { message = value; OnPropertyChanged("Message"); }
        }

        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }

        public void Save()
        {
            try
            {
                var IsSaved = ObjEmployeeService.Add(CurrentEmployee);
                LoadData();
                if (IsSaved)
                    Message = "Employee saved";
                else
                    Message = "Saved operation failed";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
    }
}
