using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models.Operation
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        [Display(Name ="Outlet Name")]
        public int OutletId { get; set; }
        public virtual Outlet Outlet { get; set; }

        [Display(Name ="Employee Name")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [Required]
        [Display(Name ="Expense Date")]
        public DateTime ExpenseDate { get; set; } 

        [Required]
        public decimal Total { get; set; }

        public decimal Due { get; set; }

        public virtual List<ExpenseDetail> ExpenseDetails { get; set; }
    }
}