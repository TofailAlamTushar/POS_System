using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models.Operation
{
    public class SalesDetail
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public int Quntity { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }


        public int SaleId { get; set; }
        public virtual Sale Sale { get; set; }

    }
}