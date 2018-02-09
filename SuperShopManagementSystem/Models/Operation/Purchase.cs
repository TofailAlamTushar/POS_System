using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models.Operation
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        [Display(Name = "Outlet")]
        public int OutletId { get; set; }
        public virtual Outlet Outlet { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [Required]
        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [Display(Name ="Supplier")]
        public int PartyId { get; set; }
        public virtual Party Party { get; set; }

        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        public decimal Total { get; set; }

        [Display(Name = "Due Amount")]
        public decimal DueAmount { get; set; }

        public virtual List<PurchaseDetail> PurchaseDetail { get; set; }
    }
}