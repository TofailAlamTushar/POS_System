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
    public class ItemDal
    {
        ShopDbContext db = new ShopDbContext();
        bool status = false;
        int start = 0;

        internal List<Item> List()
        {
            List<Item> Items = db.Items.ToList();

            return Items;
        }

        internal object GenerateAutoCode()
        {
            string autoCode = "";
            string lastCode = db.Items.Max(item => item.Code);

            if (lastCode != null)
            {
                string resultString = Regex.Match(lastCode, @"\d+").Value;
                start = Int32.Parse(resultString);

                autoCode = "I" + (start + 1).ToString("000");
            }
            autoCode = "I" + (start + 1).ToString("000");

            return autoCode;
        }

        internal object GetItemCategory()
        {
            var ItemCategory = new SelectList(db.ItemCategories, "Id", "Name");
            return ItemCategory;
        }

        internal Item GetById(int? id)
        {
            Item item = db.Items.Where(m => m.Id == id).FirstOrDefault();
            return item;
        }

        internal bool Edit(Item item)
        {
            db.Items.Attach(item);
            db.Entry(item).State = EntityState.Modified;
            int AffectedRow = db.SaveChanges();
            if (AffectedRow > 0)
            {
                status = true;
            }
            return status;
        }

        internal bool Delete(int id)
        {
            var ItemById = db.Items.Where(m => m.Id == id).FirstOrDefault();

            if (ItemById != null)
            {
                db.Entry(ItemById).State = EntityState.Deleted;
                int affectedRow = db.SaveChanges();

                if (affectedRow > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        internal bool Create(Item item)
        {
            db.Items.Add(item);
            int RowAffected = db.SaveChanges();

            if (RowAffected > 0)
            {
                status = true;
            }
            return status;
        }
    }
}