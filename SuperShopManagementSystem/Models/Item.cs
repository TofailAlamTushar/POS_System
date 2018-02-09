using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Cost Price")]
        public decimal CostPrice { get; set; }

        [Required]
        [Display(Name ="Sale Price")]
        public decimal SalePrice { get; set; }

        [Required]
        public string Code { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength:1000, ErrorMessage ="Description can not be more then 1000 characters")]
        public string Description { get; set; }

        public int ItemCategoryId { get; set; }
        public virtual ItemCategory ItemCategory { get; set; }

        public byte [] Image { get; set; }

        public virtual List<SalesDetail> SalesDetails { get; set; }
        public virtual List<PurchaseDetail> PurchaseDetails { get; set; }
    }
}