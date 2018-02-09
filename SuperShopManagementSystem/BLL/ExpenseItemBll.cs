using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.BLL
{
    public class ExpenseItemBll
    {
        ExpenseItemDal expenseItemDal = new ExpenseItemDal();
        bool status;

        internal List<ExpenseItem> List()
        {
            List<ExpenseItem> ExpenseItems = expenseItemDal.List();
            return ExpenseItems;
        }

        internal dynamic GenerateAutoCode()
        {
            var autoCode = expenseItemDal.GenerateAutoCode();
            return autoCode;
        }

        internal bool Create(ExpenseItem expenseItem)
        {
            status = expenseItemDal.Create(expenseItem);
            return status;
        }

        internal bool Delete(int id)
        {
            status = expenseItemDal.Delete(id);
            return status;
        }

        internal dynamic GetExpenseItemCategory()
        {
            var ExpenseItemCategory = expenseItemDal.GetExpenseItemCategory();
            return ExpenseItemCategory;
        }

        internal ExpenseItem GetById(int? id)
        {
            ExpenseItem expenseItem = expenseItemDal.GetById(id);
            return expenseItem;
        }

        internal bool Edit(ExpenseItem expenseItem)
        {
            status = expenseItemDal.Edit(expenseItem);
            return status;
        }
    }
}