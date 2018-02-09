using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Code { get; set; }

        public int OutletId { get; set; }
        public virtual Outlet Outlet { get; set; }

        [Display(Name ="Joining Date")]
        public DateTime JoiningDate { get; set; }
        public byte[] Image { get; set; }

        [Required]
        [Display(Name ="Contact Number")]
        public string ContactNo { get; set; }

        [Required]
        public string Email { get; set; }

        public Nullable<int> ReferenceId { get; set; }
        public virtual Employee Reference { get; set; }
        public virtual List<Employee> Employees { get; set; }

        [Required]
        [Display(Name = "Emergency Contact Number")]
        public string EmerContactNo { get; set; }

        [Display(Name = "National ID")]
        public string NationalId { get; set; }

        [Display(Name = "Father's Name")]
        public string FathersName { get; set; }

        [Display(Name = "Mother's Name")]
        public string MothersName { get; set; }

        [Display(Name = "Present Address")]
        public string PresentAddress { get; set; }

        [Required]
        [Display(Name = "Permanent Address")]
        public string PermanentAddress { get; set; }

        public virtual List<Sale> Sales { get; set; }
        public virtual List<Purchase> Purchases { get; set; }
        public virtual List<Expense> Expenses { get; set; }
    }
}