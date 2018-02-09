using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models
{
    public class ItemCategory
    {
       [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength:1000,ErrorMessage ="Description can not be more then 1000 characters")]
        public string Description { get; set; }

        public byte[] Image { get; set; }

        public Nullable<int> ParentId { get; set; }
        public ItemCategory Parent { get; set; }
        public List<ItemCategory> ItemCategories { get; set; }


        public List<Item> Items { get; set; }

    }
}