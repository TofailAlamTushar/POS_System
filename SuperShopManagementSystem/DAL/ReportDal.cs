using SuperShopManagementSystem.Context;
using SuperShopManagementSystem.Models;
using SuperShopManagementSystem.Models.Operation;
using SuperShopManagementSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShopManagementSystem.DAL
{
    public class ReportDal
    {
        ShopDbContext db = new ShopDbContext();
        internal object GetOutlet()
        {
            var Outlet = new SelectList(db.Outlets,"Id","Name");
            return Outlet;
        }
        internal List<Expense> GetExpensesByReportVm(ReportVm reportVm)
        {
            
           var Expenses = db.Expenses.AsQueryable();
            if(reportVm.OutletId!=null)
            {
                Expenses = Expenses.Where(m => m.OutletId == reportVm.OutletId && m.IsDeleted==false).AsQueryable();
            }
            if(reportVm.Code!=null)
            {
                Expenses = Expenses.Where(m => m.Id == reportVm.Code && m.IsDeleted == false).AsQueryable();
            }
            if(reportVm.FromDate!=null)
            {
                Expenses = Expenses.Where(m => m.ExpenseDate >= reportVm.FromDate && m.IsDeleted == false).AsQueryable();
            }
            if(reportVm.ToDate!=null)
            {
                Expenses = Expenses.Where(m => m.ExpenseDate <= reportVm.ToDate && m.IsDeleted == false).AsQueryable();
            }

            return Expenses.ToList();
        }
        internal List<Sale> GetSalesByReportVm(ReportVm reportVm)
        {
            var Sales = db.Sales.AsQueryable();
            if (reportVm.OutletId != null)
            {
                Sales = Sales.Where(m => m.OutletId == reportVm.OutletId && m.IsDeleted == false).AsQueryable();

            }
            if (reportVm.Code != null)
            {
                Sales = Sales.Where(m => m.Id == reportVm.Code && m.IsDeleted == false).AsQueryable();
            }
            if (reportVm.FromDate != null)
            {
                Sales = Sales.Where(m => m.SaleDate >= reportVm.FromDate && m.IsDeleted == false).AsQueryable();
            }
            if (reportVm.ToDate != null)
            {
                Sales = Sales.Where(m => m.SaleDate <= reportVm.ToDate && m.IsDeleted == false).AsQueryable();
            }
            return Sales.ToList();

        }
        internal List<Purchase> GetPurchasesByReportVm(ReportVm reportVm)
        {
            var Purchases = db.Purchases.AsQueryable();
            if(reportVm.OutletId!=null)
            {
                Purchases = Purchases.Where(m => m.OutletId == reportVm.OutletId && m.IsDeleted == false).AsQueryable();
       
            }
            if (reportVm.Code != null)
            {
                Purchases = Purchases.Where(m => m.Id == reportVm.Code && m.IsDeleted == false).AsQueryable();
            }
            if(reportVm.FromDate!=null)
            {
                Purchases = Purchases.Where(m => m.PurchaseDate >= reportVm.FromDate && m.IsDeleted == false).AsQueryable();
            }
            if(reportVm.ToDate!=null)
            {
                Purchases = Purchases.Where(m => m.PurchaseDate <= reportVm.ToDate && m.IsDeleted == false).AsQueryable();
            }
            return Purchases.ToList();
        }    
    }
}