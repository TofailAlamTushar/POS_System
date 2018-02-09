using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.BLL
{
    public class EmployeeBll
    {

        EmployeeDal employeeDal = new EmployeeDal();
        bool status;

        internal List<Employee> List()
        {
            List<Employee> Employees = employeeDal.List();
            return Employees;
        }

        internal dynamic GenerateAutoCode()
        {
            var autoCode = employeeDal.GenerateAutoCode();
            return autoCode;
        }

        internal bool Create(Employee employee)
        {
            status = employeeDal.Create(employee);
            return status;
        }

        internal bool Delete(int id)
        {
            status = employeeDal.Delete(id);
            return status;
        }

        internal dynamic GetOutlet()
        {
            var Outlet = employeeDal.GetOutlet();
            return Outlet;
        }

        internal dynamic GetReference()
        {
            var Reference = employeeDal.GetReference();
            return Reference;
        }

        internal Employee GetById(int? id)
        {
            Employee employee = employeeDal.GetById(id);
            return employee;
        }

        internal bool Edit(Employee employee)
        {
            status = employeeDal.Edit(employee);
            return status;
        }
    }
}