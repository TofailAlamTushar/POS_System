using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models.Operation
{
    public class ExpenseDetail
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public int ExpenseId { get; set; }
        public virtual Expense Expense { get; set; }

        [Display(Name ="Item Name")]
        public int ExpenseItemId { get; set; }
        public virtual ExpenseItem ExpenseItem { get; set; }


        public int Quantity { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength:1000,ErrorMessage ="Description can not be more then 1000 characters.")]
        public string Description { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}