using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models;
using SuperShopManagementSystem.Models.Operation;
using SuperShopManagementSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.BLL
{
    public class ReportBll
    {
        ReportDal reportDal = new ReportDal();
        ItemDal itemDal = new ItemDal();
        Common common = new Common();
        ItemCategoryDal itemCategoryDal = new ItemCategoryDal();
        ItemCategory itemCategory = new ItemCategory();
        internal dynamic GetOutlet()
        {
            var Outlet = reportDal.GetOutlet();
            return Outlet;
        }

        internal List<Expense> GetExpensesByReportVm(ReportVm reportVm)
        {
            List<Expense> Expenses = reportDal.GetExpensesByReportVm(reportVm);
            return Expenses;
        }

        internal List<Purchase> GetPurchasesByReportVm(ReportVm reportVm)
        {
            List<Purchase> Purchases = reportDal.GetPurchasesByReportVm(reportVm);
            return Purchases;
        }

        internal List<Sale> GetSalesByReportVm(ReportVm reportVm)
        {
            List<Sale> Sales = reportDal.GetSalesByReportVm(reportVm); 
            return Sales;
        }

        internal IncomeVm GetIncomeVmByReportVm(ReportVm reportVm)
        {
            decimal TotalIncome = 0;
            decimal TotalSales = 0;
            decimal TotalPurchase = 0;
            List<Sale> Sales = reportDal.GetSalesByReportVm(reportVm);
            List<Purchase> Purchase = reportDal.GetPurchasesByReportVm(reportVm);
            if(Sales!=null)
            {
                foreach (var item in Sales)
                {
                    TotalSales = TotalSales + item.Total;
                }
            }
            if(Purchase!=null)
            {
                foreach (var item in Purchase)
                {
                    TotalPurchase = TotalPurchase + item.Total;
                }
            }
      
            TotalIncome = TotalSales - TotalPurchase;
            IncomeVm incomeVm = new IncomeVm();

            incomeVm.Sales = Sales;
            incomeVm.Purchases = Purchase;
            incomeVm.SalesTotal = TotalSales;
            incomeVm.PurchasesTotal = TotalPurchase;
            incomeVm.TotalIncome = TotalIncome;
            return incomeVm;
        }


        //>>>Stock Report starts from here<<<

       List<StockVm> StockReportList = new List<StockVm>();
        internal List<StockVm> GetStockReportList(ReportVm reportVm)
        {
            
            List<Sale> Sales = reportDal.GetSalesByReportVm(reportVm);
            List<Purchase> Purchases = reportDal.GetPurchasesByReportVm(reportVm);
            
            if (Purchases != null)
            {
                foreach (var item in Purchases)
                {
                    foreach (var itemDes in item.PurchaseDetail)
                    {
                        StockVm stockVm = new StockVm();
                        if(StockReportList.Any(m=>m.ItemName== itemDes.Item.Name)==false)
                        {
                                stockVm.ItemName = itemDes.Item.Name;
                                stockVm.StockQuantity = common.GetItemStockById(itemDes.Item.Id);
                                stockVm.CategoryFullPath = GetCategoryFullPathById(itemDes.Item.Id);
                                stockVm.Price = itemDes.Item.CostPrice;
                                StockReportList.Add(stockVm);   
                        }
                    }
                }
            } 
            return StockReportList.ToList();
        }

        //>>>for Category full path<<<

        internal string GetCategoryFullPathById(int id)
        {
            string CategoryFullPath="";
            Item item = itemDal.GetById(id);
            ItemCategory itemCategory = itemCategoryDal.GetById(item.ItemCategoryId);
            CategoryFullPath = itemCategory.Name;
            if (itemCategory.ParentId!=null)
            {
                CategoryFullPath = CategoryFullPath + ","+GetCategoryParent(itemCategory.ParentId);
            }
            return CategoryFullPath;
        }

        internal string GetCategoryParent(int? id)
        {
            itemCategory = itemCategoryDal.GetById(id);
            string ParentName = itemCategory.Name;
            if (itemCategory.ParentId != null)
            {
                ParentName = ParentName + "," + (GetCategoryParent(itemCategory.ParentId));
            }
            return ParentName;
        }
    }
}