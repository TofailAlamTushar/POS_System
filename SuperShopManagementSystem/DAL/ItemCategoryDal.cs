using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using SuperShopManagementSystem.BLL;
using SuperShopManagementSystem.Context;
using SuperShopManagementSystem.Models;

namespace SuperShopManagementSystem.DAL
{
    public class ItemCategoryDal
    {
        ShopDbContext db = new ShopDbContext();
        bool status=false;
        int start=0;

        internal List<ItemCategory> List()
        {
            List<ItemCategory> ItemCategories = db.ItemCategories.ToList();

            return ItemCategories;
        }

        internal object GenerateAutoCode()
        {
            string autoCode = "";
            string lastCode = db.ItemCategories.Max(item => item.Code);
          
            if(lastCode!=null)
            {
                string resultString = Regex.Match(lastCode, @"\d+").Value;
                 start = Int32.Parse(resultString);

                autoCode = "IC" + (start + 1).ToString("000");
            }
            autoCode = "IC" + (start + 1).ToString("000");

            return autoCode;
        }

        internal ItemCategory GetById(int? id)
        {
            ItemCategory itemCategory = db.ItemCategories.Where(m => m.Id == id).FirstOrDefault();
            return itemCategory;
        }

        internal bool Edit(ItemCategory itemCategory)
        {
            db.ItemCategories.Attach(itemCategory);
            db.Entry(itemCategory).State = EntityState.Modified;
            int AffectedRow= db.SaveChanges();
            if(AffectedRow>0)
            {
                status = true;
            }
            return status;
        }

        internal bool Delete(int id)
        {
           var ItemCategoryById= db.ItemCategories.Where(m => m.Id == id).FirstOrDefault();

            if(ItemCategoryById!=null)
            {
                db.Entry(ItemCategoryById).State = EntityState.Deleted;
                int affectedRow = db.SaveChanges();

                if (affectedRow > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        internal bool Create(ItemCategory itemCategory)
        {
            db.ItemCategories.Add(itemCategory);
           int RowAffected= db.SaveChanges();

            if(RowAffected>0)
            {
                status = true;
            }
            return status;
        }
    }
}