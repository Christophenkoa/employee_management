using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmDemo.Models
{
    public class EmployeeService
    {
        private static List<Employee> ObjEmployeesList;

        public EmployeeService()
        {
            ObjEmployeesList = new List<Employee>() 
            {
                new Employee{Id = 1, Name = "Christophe", Age = 23 }
            };
        }

        public List<Employee> GetAll()
        {
            return ObjEmployeesList;
        }

        public bool Add(Employee objNewEmployee)
        {
            if (objNewEmployee.Age < 21 || objNewEmployee.Age > 58)
                throw new ArgumentException("Invalid age limit");

            ObjEmployeesList.Add(objNewEmployee);
            return true;

        }

        public bool Update(Employee objEmployeeToUpdate) 
        {
            bool IsUpdated = false;

            for (int index = 0; index < ObjEmployeesList.Count; index++)
            {
                if (ObjEmployeesList[index].Id == objEmployeeToUpdate.Id)
                {
                    ObjEmployeesList[index].Age = objEmployeeToUpdate.Age;
                    ObjEmployeesList[index].Name = objEmployeeToUpdate.Name;
                    IsUpdated = true;
                    break;
                }
            }

            return IsUpdated;
        }

        public bool delete(int id)
        {
            bool IsDeleted = false;

            for (int index = 0; index < ObjEmployeesList.Count; index++)
            {
                if (ObjEmployeesList[index].Id == id)
                {
                    ObjEmployeesList.RemoveAt(index);
                    IsDeleted = true;
                    break;
                }
            }

            return IsDeleted;
        }

        public Employee Search(int id)
        {
            return ObjEmployeesList.FirstOrDefault(e => e.Id == id);
        }
    }
}
