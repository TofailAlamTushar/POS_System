using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models
{
    public class Party
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Code { get; set; }

        [Required]
        [Display(Name="Contact Number")]
        public string ContactNo { get; set; }

        [Required]
        public string Email { get; set; }
        public byte[] Image { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength:1000,ErrorMessage ="Sorry Address can not more then 1000 charecters")]
        public string Address{ get; set; }

        [Required]
        [Display(Name ="Party Type")]
        public string PartyType { get; set; }

        public virtual List<Purchase> Purchases { get; set; }

    }
}