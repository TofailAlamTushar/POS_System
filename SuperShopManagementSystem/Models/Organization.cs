using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }

        [Display(Name ="Contact Number")]
        public string ContactNo { get; set; }

        public byte[] Image { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 1000, ErrorMessage = "Address can not be more then 1000 characters")]
        public string Address { get; set; }

        public virtual List<Outlet> Outlets { get; set; }
    }
}