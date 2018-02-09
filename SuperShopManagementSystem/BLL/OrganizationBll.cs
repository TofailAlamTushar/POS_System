using SuperShopManagementSystem.DAL;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.BLL
{
    public class OrganizationBll
    {
        OrganizationDal organizationDal = new OrganizationDal();
        bool status;

        internal List<Organization> List()
        {
            List<Organization> Organizations = organizationDal.List();
            return Organizations;
        }

        internal dynamic GenerateAutoCode()
        {
            var autoCode = organizationDal.GenerateAutoCode();
            return autoCode;
        }

        internal bool Create(Organization organization)
        {
            status = organizationDal.Create(organization);
            return status;
        }

        internal bool Delete(int id)
        {
            status = organizationDal.Delete(id);
            return status;
        }

        internal Organization GetById(int? id)
        {
            Organization organization = organizationDal.GetById(id);
            return organization;
        }

        internal bool Edit(Organization organization)
        {
            status = organizationDal.Edit(organization);
            return status;
        }
    }
}