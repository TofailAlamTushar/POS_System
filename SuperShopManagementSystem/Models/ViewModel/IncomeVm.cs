using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models.ViewModel
{
    public class IncomeVm
    {
        public int id { get; set; }

        [NotMapped]
        public List<Sale> Sales { get; set; }

        [NotMapped]
        public List<Purchase> Purchases { get; set; }

        public decimal SalesTotal { get; set; }
        public decimal PurchasesTotal { get; set; }
        public decimal TotalIncome { get; set; }
        
    }
}