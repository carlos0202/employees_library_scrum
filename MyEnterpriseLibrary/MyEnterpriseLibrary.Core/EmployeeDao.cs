using System;
using System.Collections.Generic;

namespace MyEnterpriseLibrary.Core
{
    class EmployeeDao
    {
        List<Employee> _allEmployees;

        public EmployeeDao()
        {
            _allEmployees = new List<Employee>();

            _allEmployees.Add(new Employee {
                Id= 1,
                Name="Omar",
                DepartmentId=2
            });
            _allEmployees.Add(new Employee
            {
                Id = 2,
                Name = "Jnovas",
                DepartmentId = 3
            });

        }

        public List<Employee> GetAllEmployee() {
            return _allEmployees;
        }

        
        public Employee FindById(int employeeId)
        {
            return this._allEmployees.Find(e => e.Id == employeeId);
        }
    }
}