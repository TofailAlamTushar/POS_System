using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.BLL
{
    public class PartyBll
    {
        PartyDal partyDal = new PartyDal();
        bool status;

        internal List<Party> List()
        {
            List<Party> Parties = partyDal.List();
            return Parties;
        }
        internal dynamic GenerateAutoCode()
        {
            var autoCode = partyDal.GenerateAutoCode();
            return autoCode;
        }

        internal bool Create(Party party)
        {
            status = partyDal.Create(party);
            return status;
        }

        internal bool Delete(int id)
        {
            status = partyDal.Delete(id);
            return status;
        }

        internal Party GetById(int? id)
        {
            Party party = partyDal.GetById(id);
            return party;
        }

        internal bool Edit(Party party)
        {
            status = partyDal.Edit(party);
            return status;
        }
    }
}