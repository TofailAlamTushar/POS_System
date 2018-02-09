using SuperShopManagementSystem.DAL.Operation;
using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.BLL.Operation
{
    public class ExpenseBll
    {
        ExpenseDal expenseDal = new ExpenseDal();
        bool status;
        int id;
        internal List<Expense> List()
        {
            List<Expense> Expenses = expenseDal.List();
            return Expenses;
        }
        internal int Create(Expense expense)
        {
            id = expenseDal.Create(expense);
            return id;
        }
        internal bool Delete(int id)
        {
            status = expenseDal.Delete(id);
            return status;
        }

        internal dynamic GetOutlet()
        {
            var Outlet = expenseDal.GetOutlet();
            return Outlet;
        }
        internal dynamic GetEmployee()
        {
            var Employee = expenseDal.GetEmployee();
            return Employee;
        }

        internal dynamic GetExpenseItem()
        {
            var Item = expenseDal.GetExpenseItem();
            return Item;
        }
        internal Expense GetById(int? id)
        {
            Expense expense = expenseDal.GetById(id);
            return expense;
        }
    }
}