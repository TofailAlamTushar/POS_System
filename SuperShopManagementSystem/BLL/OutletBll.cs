using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.BLL
{
    public class OutletBll
    {
        OutletDal outletDal = new OutletDal();
        bool status;

        internal List<Outlet> List()
        {
            List<Outlet> Outlets = outletDal.List();
            return Outlets;
        }

        internal dynamic GenerateAutoCode()
        {
            var autoCode = outletDal.GenerateAutoCode();
            return autoCode;
        }

        internal bool Create(Outlet outlet)
        {
            status = outletDal.Create(outlet);
            return status;
        }

        internal bool Delete(int id)
        {
            status = outletDal.Delete(id);
            return status;
        }

        internal dynamic GetOrganization()
        {
            var Organization = outletDal.GetOrganization();
            return Organization;
        }

        internal Outlet GetById(int? id)
        {
            Outlet outlet = outletDal.GetById(id);
            return outlet;
        }

        internal bool Edit(Outlet outlet)
        {
            status = outletDal.Edit(outlet);
            return status;
        }
    }
}