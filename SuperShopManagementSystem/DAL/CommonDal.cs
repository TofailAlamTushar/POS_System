using SuperShopManagementSystem.Context;
using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.DAL
{
    public class CommonDal
    {
        ShopDbContext db = new ShopDbContext();
        internal List<PurchaseDetail> GetPurchaseDetailsById(int id)
        {
            List<PurchaseDetail> purchaseDetails = db.PurchaseDetails.Where(m => m.ItemId == id && m.IsDeleted==false).ToList();
            return purchaseDetails;
        }
        internal List<SalesDetail> GetSalesDetailsById(int id)
        {
            List<SalesDetail> salesDetails = db.SalesDetails.Where(m => m.ItemId == id && m.IsDeleted == false).ToList();
            return salesDetails;
        }
    }
}