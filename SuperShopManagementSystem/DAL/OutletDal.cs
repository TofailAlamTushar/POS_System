using SuperShopManagementSystem.Context;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace SuperShopManagementSystem.DAL
{
    public class OutletDal
    {

        ShopDbContext db = new ShopDbContext();
        bool status = false;
        int start = 0;

        internal List<Outlet> List()
        {
            List<Outlet> Outlets = db.Outlets.ToList();
            return Outlets;
        }

        internal object GenerateAutoCode()
        {
            string autoCode = "";
            string lastCode = db.Outlets.Max(item => item.Code);

            if (lastCode != null)
            {
                string resultString = Regex.Match(lastCode, @"\d+").Value;
                start = Int32.Parse(resultString);

                autoCode = "I" + (start + 1).ToString("000");
            }
            autoCode = "I" + (start + 1).ToString("000");

            return autoCode;
        }

        internal object GetOrganization()
        {
            var Organization = new SelectList(db.Organizations, "Id", "Name");
            return Organization;
        }

        internal Outlet GetById(int? id)
        {
            Outlet outlet = db.Outlets.Where(m => m.Id == id).FirstOrDefault();
            return outlet;
        }

        internal bool Edit(Outlet outlet)
        {
            db.Outlets.Attach(outlet);
            db.Entry(outlet).State = EntityState.Modified;
            int AffectedRow = db.SaveChanges();
            if (AffectedRow > 0)
            {
                status = true;
            }
            return status;
        }

        internal bool Delete(int id)
        {
            var OutletById = db.Outlets.Where(m => m.Id == id).FirstOrDefault();

            if (OutletById != null)
            {
                db.Entry(OutletById).State = EntityState.Deleted;
                int affectedRow = db.SaveChanges();

                if (affectedRow > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        internal bool Create(Outlet outlet)
        {
            db.Outlets.Add(outlet);
            int RowAffected = db.SaveChanges();

            if (RowAffected > 0)
            {
                status = true;
            }
            return status;
        }
    }
}