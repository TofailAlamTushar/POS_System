using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.BLL
{
    public class ItemCategoryBll
    {
        ItemCategoryDal itemCategoryDal = new ItemCategoryDal();
        bool status;

        internal List<ItemCategory> List()
        {
            List<ItemCategory> ItemCategories = itemCategoryDal.List();

            return ItemCategories;
        }

        internal dynamic GenerateAutoCode()
        {
            var autoCode = itemCategoryDal.GenerateAutoCode();
            return autoCode;
        }

        internal bool Create(ItemCategory itemCategory)
        {
            status = itemCategoryDal.Create(itemCategory);

            return status;
        }

        internal bool Delete(int id)
        {
            status = itemCategoryDal.Delete(id);

            return status;
        }

        internal ItemCategory GetById(int? id)
        {
            ItemCategory itemCategory = itemCategoryDal.GetById(id);
            return itemCategory;
        }

        internal bool Edit(ItemCategory itemCategory)
        {
            status = itemCategoryDal.Edit(itemCategory);
            return status;
        }
    }
}