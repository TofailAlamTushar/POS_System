using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.BLL
{
    public class CommonBll
    {
        CommonDal commonDal = new CommonDal();

        internal dynamic GetItemStockById(int id)
        {
            List<PurchaseDetail> purchaseDetails = commonDal.GetPurchaseDetailsById(id);
            List<SalesDetail> salesDetails = commonDal.GetSalesDetailsById(id);
            var TotalPurchase = 0;
            var TotalSales = 0;
            foreach (var item in purchaseDetails)
            {
                TotalPurchase = TotalPurchase + item.Quntity;
            }
            foreach (var item in salesDetails)
            {
                TotalSales = TotalSales + item.Quntity;
            }
            var ItemStock = TotalPurchase - TotalSales;

            if (ItemStock < 0)
            {
                ItemStock = 0;
            }
            return ItemStock;

        }

    }
}