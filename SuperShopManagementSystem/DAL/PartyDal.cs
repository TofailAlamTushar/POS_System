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
    public class PartyDal
    {
        ShopDbContext db = new ShopDbContext();
        bool status = false;
        int start = 0;

        internal List<Party> List()
        {
            List<Party> Parties = db.Parties.ToList();
            return Parties;
        }

        internal object GenerateAutoCode()
        {
            string autoCode = "";
            string lastCode = db.Parties.Max(item => item.Code);

            if (lastCode != null)
            {
                string resultString = Regex.Match(lastCode, @"\d+").Value;
                start = Int32.Parse(resultString);

                autoCode = "P" + (start + 1).ToString("000");
            }
            autoCode = "P" + (start + 1).ToString("000");

            return autoCode;
        }


        internal Party GetById(int? id)
        {
            Party party = db.Parties.Where(m => m.Id == id).FirstOrDefault();
            return party;
        }

        internal bool Edit(Party party)
        {
            db.Parties.Attach(party);
            db.Entry(party).State = EntityState.Modified;
            int AffectedRow = db.SaveChanges();
            if (AffectedRow > 0)
            {
                status = true;
            }
            return status;
        }

        internal bool Delete(int id)
        {
            var PartyById = db.Parties.Where(m => m.Id == id).FirstOrDefault();

            if (PartyById != null)
            {
                db.Entry(PartyById).State = EntityState.Deleted;
                int affectedRow = db.SaveChanges();

                if (affectedRow > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        internal bool Create(Party party)
        {
            db.Parties.Add(party);
            int RowAffected = db.SaveChanges();
            if (RowAffected > 0)
            {
                status = true;
            }
            return status;
        }
    }
}