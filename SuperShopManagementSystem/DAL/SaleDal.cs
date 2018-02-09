using SuperShopManagementSystem.Context;
using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShopManagementSystem.DAL
{
    public class SaleDal
    {
        ShopDbContext db = new ShopDbContext();
        bool status = false;
        int start = 0;
        int id;
        internal List<Sale> List()
        {
            List<Sale> Sales = db.Sales.ToList();
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

        internal Sale GetById(int? id)
        {
            Sale sale = db.Sales.Where(m => m.Id == id && m.IsDeleted==false).FirstOrDefault();
            return sale;
        }

        internal bool Edit(Sale sale)
        {
            db.Sales.Attach(sale);
            db.Entry(sale).State = EntityState.Modified;
            int AffectedRow = db.SaveChanges();
            if (AffectedRow > 0)
            {
                status = true;
            }
            return status;
        }

        internal object GetItem()
        {
            var Item = new SelectList(db.Items, "Id", "Name");
            return Item;
        }

        internal bool Delete(int id)
        {
            var SaleById = db.Sales.Where(m => m.Id == id).FirstOrDefault();

            if (SaleById != null)
            {
                db.Entry(SaleById).State = EntityState.Deleted;
                int affectedRow = db.SaveChanges();

                if (affectedRow > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        internal int Create(Sale sale)
        {
            db.Sales.Add(sale);
            int RowAffected = db.SaveChanges();

            if (RowAffected > 0)
            {
                id = db.Sales.Max(m => m.Id);
            }
            return id;
        }
    }
}