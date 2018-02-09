using SuperShopManagementSystem.Context;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SuperShopManagementSystem.DAL
{
    public class ExpenseCatagoryDal
    {
        ShopDbContext db = new ShopDbContext();
        bool status = false;
        
        public bool Create(ExpenseCatagory expenseCatagory)
        {

            db.ExpenseCatagories.Add(expenseCatagory);
            int count = db.SaveChanges();

            if(count>0)
            {
                status = true;
            }
                return status;          
        }

        internal List<ExpenseCatagory> List()
        {
            
           List<ExpenseCatagory> listOfExpenseCatagory = db.ExpenseCatagories.ToList();

            return listOfExpenseCatagory;
        }

        internal ExpenseCatagory GetById(int? id)
        {           
            ExpenseCatagory expenseCatagory = db.ExpenseCatagories.SingleOrDefault(m => m.Id == id);
                return expenseCatagory;
        }

        internal bool Edit(ExpenseCatagory expenseCatagories)
        {

            db.ExpenseCatagories.Attach(expenseCatagories);
            db.Entry(expenseCatagories).State= EntityState.Modified;

            int AffectedRow = db.SaveChanges();
            if(AffectedRow>0)
            {
                status = true;
            }

            return status;
        }

        internal object GenerateAutoCode()
        {
           string autoCode = "";
           string lastCode = db.ExpenseCatagories.Max(item => item.Code);

            string resultString = Regex.Match(lastCode, @"\d+").Value;
            int start = Int32.Parse(resultString);

            autoCode = "EC" + (start+1).ToString("000");         
            return autoCode;
        }

        internal bool Delete(int id)
        {
            var expenseCatagorybyid = db.ExpenseCatagories.Where(x => x.Id == id).FirstOrDefault();
            if (expenseCatagorybyid != null)
            {
                db.Entry(expenseCatagorybyid).State = EntityState.Deleted;
                int affectedRow = db.SaveChanges();

                if (affectedRow > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        internal List<ExpenseCatagory> GetParentCategories()
        {
            List<ExpenseCatagory> ExpenseCategories = db.ExpenseCatagories.ToList();

            return ExpenseCategories;
        }
    }
}