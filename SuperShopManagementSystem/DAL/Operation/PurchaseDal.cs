using SuperShopManagementSystem.Context;
using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShopManagementSystem.DAL.Operation
{
    public class PurchaseDal
    {
            ShopDbContext db = new ShopDbContext();
            bool status = false;
            int start = 0;
            int id;

            internal List<Purchase> List()
            {
                List<Purchase> Sales = db.Purchases.ToList();
                return Sales;
            }

            internal object GetOutlet()
            {
                var Outlet = new SelectList(db.Outlets, "Id", "Name");
                return Outlet;
            }

            internal object GetEmployee()
            {
                var Employee = new SelectList(db.Employees, "Id", "Name");
                return Employee;
            }

            internal Purchase Details(int id)
        {
            Purchase purchase = db.Purchases.Where(m => m.Id == id && m.IsDeleted==false).SingleOrDefault();
            return purchase;
        }

            internal Purchase GetById(int? id)
            {
                Purchase purchase = db.Purchases.Where(m => m.Id == id && m.IsDeleted==false).FirstOrDefault();
                return purchase;
            }

            internal bool Edit(Purchase purchase)
            {
                db.Purchases.Attach(purchase);
                db.Entry(purchase).State = EntityState.Modified;
                int AffectedRow = db.SaveChanges();
                if (AffectedRow > 0)
                {
                    status = true;
                }
                return status;
            }

            internal object Supplier()
        {
            var Supplier = new SelectList(db.Parties.Where(m=>m.PartyType=="Supplier"), "Id", "Name");
            return Supplier;
        }
         
            internal object GetItem()
            {
                var Item = new SelectList(db.Items, "Id", "Name");
                return Item;
            }

            internal bool Delete(int id)
            {
                var PurchaseById = db.Purchases.Where(m => m.Id == id).FirstOrDefault();

                if (PurchaseById != null)
                {
                    db.Entry(PurchaseById).State = EntityState.Deleted;
                    int affectedRow = db.SaveChanges();

                    if (affectedRow > 0)
                    {
                        status = true;
                    }
                }
                return status;
            }

            internal int Create(Purchase purchase)
            {
                db.Purchases.Add(purchase);
                int RowAffected = db.SaveChanges();
                if (RowAffected > 0)
                {
                 id = db.Purchases.Max(m => m.Id);
                }
                return id;
            }
    }
}