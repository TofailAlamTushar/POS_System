using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models
{
    public class Outlet
    {
        [Key]
        public int Id { get; set; }

        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }

        [Required]
        [Display(Name ="Outlet Name")]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        [Display(Name ="Contact Number")]
        public string ContactNo { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 1000, ErrorMessage = "Address can not be more then 1000 characters")]
        public string Address { get; set; }

        public virtual List<Employee> Employees { get; set; }
        public virtual List<Sale> Sales { get; set; }
        public virtual List<Purchase> Purchases { get; set; }
        public virtual List<Expense> Expenses { get; set; }
    }
}