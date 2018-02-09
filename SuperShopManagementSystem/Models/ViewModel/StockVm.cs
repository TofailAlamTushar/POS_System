using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models.ViewModel
{
    public class StockVm
    {
        public string ItemName { get; set; }
        public string CategoryFullPath { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }
    }
}