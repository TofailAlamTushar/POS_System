using SuperShopManagementSystem.BLL;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShopManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OutletsController : Controller
    {
        Common common = new Common();
        OutletBll outletBll = new OutletBll();
        bool status = false;
        // GET: Items
        public ActionResult List()
        {
            List<Outlet> Outlets = outletBll.List();
            return View(Outlets);
        }

        // GET: Items/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.autoCode = outletBll.GenerateAutoCode();
            ViewBag.OrganizationId = outletBll.GetOrganization();
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Outlet outlet)
        {
            if (ModelState.IsValid)
            {
                status = outletBll.Create(outlet);
                if (status == true)
                {
                    return RedirectToAction("List", "Outlets");
                }
                else
                {
                    ViewBag.Message = "Expense Catagory added failed";
                }
            }
            ViewBag.OrganizationId = outletBll.GetOrganization();
            return View(outlet);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            Outlet outlet = outletBll.GetById(id);
            if (outlet == null)
            {
                return RedirectToAction("Error", "Home");
            }
            ViewBag.OrganizationId = outletBll.GetOrganization();
            return View(outlet);
        }

        // POST: Items/Edit/5
        [HttpPost]
        public ActionResult Edit(Outlet outlet)
        {
            if (ModelState.IsValid)
            {
                status = outletBll.Edit(outlet);
                if (status == true)
                {
                    return RedirectToAction("List", "Outlets");
                }
                else
                {
                    ViewBag.Message = "Item is not updated succesfully";
                }
            }

            ViewBag.OrganizationId = outletBll.GetOrganization();
            return View(outlet);

        }
        // GET: Items/Delete/5
        public JsonResult Delete(int id)
        {
            status = outletBll.Delete(id);
            if (status == true)
            {
                return Json(1);
            }
            return Json(0);
        }
    }
}