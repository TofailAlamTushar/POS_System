using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models
{
    public class ExpenseCatagory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string  Code  { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength:1000,ErrorMessage = "Description can not be more then 1000 Chararcters")]
        public string  Description { get; set; }

        public byte[] Image { get; set; }

        
        [Display(Name="Parant Catagory")]
        public Nullable<int> ParentId { get; set; }
        public virtual ExpenseCatagory Parent { get; set; }
        public virtual List<ExpenseCatagory> ExpenseCatagories { get; set; }

        public virtual List<ExpenseItem> ExpenseItems { get; set; }
    }
}