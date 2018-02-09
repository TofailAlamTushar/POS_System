using SuperShopManagementSystem.Context;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SuperShopManagementSystem.DAL
{
    public class OrganizationDal
    {
        ShopDbContext db = new ShopDbContext();
        bool status = false;
        int start = 0;

        internal List<Organization> List()
        {
            List<Organization> Organizations = db.Organizations.ToList();
            return Organizations;
        }

        internal object GenerateAutoCode()
        {
            string autoCode = "";
            string lastCode = db.Organizations.Max(item => item.Code);

            if (lastCode != null)
            {
                string resultString = Regex.Match(lastCode, @"\d+").Value;
                start = Int32.Parse(resultString);

                autoCode = "OR" + (start + 1).ToString("000");
            }
            autoCode = "OR" + (start + 1).ToString("000");

            return autoCode;
        }


        internal Organization GetById(int? id)
        {
            Organization organization = db.Organizations.Where(m => m.Id == id).FirstOrDefault();
            return organization;
        }

        internal bool Edit(Organization organization)
        {
            db.Organizations.Attach(organization);
            db.Entry(organization).State = EntityState.Modified;
            int AffectedRow = db.SaveChanges();
            if (AffectedRow > 0)
            {
                status = true;
            }
            return status;
        }

        internal bool Delete(int id)
        {
            var OrganizationById = db.Organizations.Where(m => m.Id == id).FirstOrDefault();

            if (OrganizationById != null)
            {
                db.Entry(OrganizationById).State = EntityState.Deleted;
                int affectedRow = db.SaveChanges();

                if (affectedRow > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        internal bool Create(Organization organization)
        {
            db.Organizations.Add(organization);
            int RowAffected = db.SaveChanges();

            if (RowAffected > 0)
            {
                status = true;
            }
            return status;
        }
    }
}