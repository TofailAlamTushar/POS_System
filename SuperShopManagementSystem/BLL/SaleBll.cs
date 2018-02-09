using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.BLL
{
    public class SaleBll
    {
        SaleDal saleDal = new SaleDal();
        bool status;
        int id;

        internal List<Sale> List()
        {
            List<Sale> Sales = saleDal.List();
            return Sales;
        }

        internal int Create(Sale sale)
        {
            id = saleDal.Create(sale);
            return id;
        }

        internal bool Delete(int id)
        {
            status = saleDal.Delete(id);
            return status;
        }

        internal dynamic GetOutlet()
        {
            var Outlet = saleDal.GetOutlet();
            return Outlet;
        }
        internal dynamic GetEmployee()
        {
            var Employee = saleDal.GetEmployee();
            return Employee;
        }

        internal dynamic GetItem()
        {
            var Item = saleDal.GetItem();
            return Item;
        }

        internal Sale GetById(int? id)
        {
            Sale sale = saleDal.GetById(id);
            return sale;
        }

        internal bool Edit(Sale sale)
        {
            status = saleDal.Edit(sale);
            return status;
        }
    }
}