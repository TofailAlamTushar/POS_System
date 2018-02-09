using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.DAL.Operation;
using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.BLL.Operation
{
    public class PurchaseBll
    {
        PurchaseDal purchaseDal = new PurchaseDal();
        bool status;
        int id;

        internal List<Purchase> List()
        {
            List<Purchase> Purchases = purchaseDal.List();
            return Purchases;
        }
        internal int Create(Purchase purchase)
        {
            id = purchaseDal.Create(purchase);
            return id;
        }
        internal bool Delete(int id)
        {
            status = purchaseDal.Delete(id);
            return status;
        }

        internal Purchase Details(int id)
        {
            Purchase purchase = purchaseDal.Details(id);
            return purchase;
        }

        internal dynamic GetOutlet()
        {
            var Outlet = purchaseDal.GetOutlet();
            return Outlet;
        }
        internal dynamic GetEmployee()
        {
            var Employee = purchaseDal.GetEmployee();
            return Employee;
        }

        internal dynamic Supplier()
        {
            var Supplier = purchaseDal.Supplier();
            return Supplier;
        }

        internal dynamic GetItem()
        {
            var Item = purchaseDal.GetItem();
            return Item;
        }
        internal Purchase GetById(int? id)
        {
            Purchase purchase = purchaseDal.GetById(id);
            return purchase;
        }
        internal bool Edit(Purchase purchase)
        {
            status = purchaseDal.Edit(purchase);
            return status;
        }
    }
}