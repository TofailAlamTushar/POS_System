using SuperShopManagementSystem.Context;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace SuperShopManagementSystem.DAL
{
    public class EmployeeDal
    {
        ShopDbContext db = new ShopDbContext();
        bool status = false;
        int start = 0;

        internal List<Employee> List()
        {
            List<Employee> Employees = db.Employees.ToList();
            return Employees;
        }

        internal object GenerateAutoCode()
        {
            string autoCode = "";
            string lastCode = db.Employees.Max(item => item.Code);

            if (lastCode != null)
            {
                string resultString = Regex.Match(lastCode, @"\d+").Value;
                start = Int32.Parse(resultString);

                autoCode = "E" + (start + 1).ToString("000");
            }
            autoCode = "E" + (start + 1).ToString("000");
            return autoCode;
        }

        internal object GetOutlet()
        {
            var Outlet = new SelectList(db.Outlets, "Id", "Name");
            return Outlet;
        }

        internal object GetReference()
        {
            var Reference = new SelectList(db.Employees, "Id", "Name");
            return Reference;
        }

        internal Employee GetById(int? id)
        {
            Employee employee = db.Employees.Where(m => m.Id == id).FirstOrDefault();
            return employee;
        }

        internal bool Edit(Employee employee)
        {
            db.Employees.Attach(employee);
            db.Entry(employee).State = EntityState.Modified;
            int AffectedRow = db.SaveChanges();
            if (AffectedRow > 0)
            {
                status = true;
            }
            return status;
        }

        internal bool Delete(int id)
        {
            var EmployeeById = db.Employees.Where(m => m.Id == id).FirstOrDefault();

            if (EmployeeById != null)
            {
                db.Entry(EmployeeById).State = EntityState.Deleted;
                int affectedRow = db.SaveChanges();

                if (affectedRow > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        internal bool Create(Employee employee)
        {
            db.Employees.Add(employee);
            int RowAffected = db.SaveChanges();

            if (RowAffected > 0)
            {
                status = true;
            }
            return status;
        }
    }
}