using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models
{
    public class ExpenseItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength:1000, ErrorMessage ="Description can to be more then 1000 characters")]
        public string Description { get; set; }
        
        public byte[] Image { get; set; }

        [Display(Name="Catagory")]
        public int ExpenseCatagoryId { get; set; }
        public virtual ExpenseCatagory ExpenseCatagory { get; set; }

        public virtual List<ExpenseDetail> ExpenseDetails { get; set; }
    }
}