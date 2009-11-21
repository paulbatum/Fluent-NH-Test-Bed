using System;
using System.Collections.Generic;

namespace Domain
{
    public class Employee
    {
        public virtual int Id { get; private set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual bool IsManager { get; set; }

    }

    public class Store
    {
        public virtual int Id { get; private set; }
        public virtual IList<Employee> Staff { get; private set; }
        public virtual IList<Employee> Managers { get; private set; }

        public Store()
        {
            Staff = new List<Employee>();
            Managers = new List<Employee>();
        }

        public void AddManager(Employee employee)
        {
            employee.IsManager = true;
            this.Managers.Add(employee);
        }

        public void AddStaff(Employee employee)
        {
            this.Staff.Add(employee);
        }

    }

}