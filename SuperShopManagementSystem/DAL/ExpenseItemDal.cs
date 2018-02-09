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
    public class ExpenseItemDal
    {
        ShopDbContext db = new ShopDbContext();
        bool status = false;
        int start = 0;
        internal List<ExpenseItem> List()
        {
            List<ExpenseItem> ExpenseItems = db.ExpenseItems.ToList();
            return ExpenseItems;
        }

        internal object GenerateAutoCode()
        {
            string autoCode = "";
            string lastCode = db.ExpenseItems.Max(item => item.Code);

            if (lastCode != null)
            {
                string resultString = Regex.Match(lastCode, @"\d+").Value;
                start = Int32.Parse(resultString);

                autoCode = "EI" + (start + 1).ToString("000");
            }
            autoCode = "EI" + (start + 1).ToString("000");

            return autoCode;
        }

        internal object GetExpenseItemCategory()
        {
            var ExpenseCategory = new SelectList(db.ExpenseCatagories, "Id", "Name");
            return ExpenseCategory;
        }

        internal ExpenseItem GetById(int? id)
        {
            ExpenseItem expenseItem = db.ExpenseItems.Where(m => m.Id == id).FirstOrDefault();
            return expenseItem;
        }

        internal bool Edit(ExpenseItem expenseItem)
        {
            db.ExpenseItems.Attach(expenseItem);
            db.Entry(expenseItem).State = EntityState.Modified;
            int AffectedRow = db.SaveChanges();
            if (AffectedRow > 0)
            {
                status = true;
            }
            return status;
        }

        internal bool Delete(int id)
        {
            var ExpenseItemById = db.ExpenseItems.Where(m => m.Id == id).FirstOrDefault();

            if (ExpenseItemById != null)
            {
                db.Entry(ExpenseItemById).State = EntityState.Deleted;
                int affectedRow = db.SaveChanges();

                if (affectedRow > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        internal bool Create(ExpenseItem ExpenseItem)
        {
            db.ExpenseItems.Add(ExpenseItem);
            int RowAffected = db.SaveChanges();

            if (RowAffected > 0)
            {
                status = true;
            }
            return status;
        }
    }
}