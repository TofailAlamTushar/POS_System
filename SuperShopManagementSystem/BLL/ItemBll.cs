using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.BLL
{
    public class ItemBll
    {
        ItemDal itemDal = new ItemDal();
        bool status;

        internal List<Item> List()
        {
            List<Item> Items = itemDal.List();
            return Items;
        }

        internal dynamic GenerateAutoCode()
        {
            var autoCode = itemDal.GenerateAutoCode();
            return autoCode;
        }

        internal bool Create(Item item)
        {
            status = itemDal.Create(item);
            return status;
        }

        internal bool Delete(int id)
        {
            status = itemDal.Delete(id);
            return status;
        }

        internal dynamic GetItemCategory()
        {
            var ItemCategory = itemDal.GetItemCategory();
            return ItemCategory;
        }

        internal Item GetById(int? id)
        {
            Item item = itemDal.GetById(id);
            return item;
        }

        internal bool Edit(Item item)
        {
            status = itemDal.Edit(item);
            return status;
        }
    }
}