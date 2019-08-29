using SuperShopManagementSystem.BLL.Operation;
using SuperShopManagementSystem.Models.Operation;
using System;
using Rotativa;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShopManagementSystem.Controllers.Operation
{
    [Authorize(Roles = "Admin,Employee")]
    public class PurchasesController : Controller
    {
     
        PurchaseBll purchaseBll = new PurchaseBll();
        bool status = false;
        int id;
        // GET: Purchases
        public ActionResult List()
        {
            List<Purchase> Purchases = purchaseBll.List();
            return View(Purchases);
        }
        //GET: Details/5
        public ActionResult Details(int id)
        {
            Purchase purchase = purchaseBll.Details(id);
            return View(purchase);
        }
        public ActionResult DetailsPdf(int id)
        {
            Purchase purchase = purchaseBll.Details(id);
            return View(purchase);
        }

        //GET: Create

        public ActionResult Create()
        {
            ViewBag.OutletId = purchaseBll.GetOutlet();
            ViewBag.EmployeeId = purchaseBll.GetEmployee();
            ViewBag.ItemId = purchaseBll.GetItem();
            ViewBag.Supplier = purchaseBll.Supplier();
            return View();
        }

        // POST: Create
        [HttpPost]
        public ActionResult Create(Purchase purchase)
        {
            purchase.IsDeleted = false;
            if (ModelState.IsValid && purchase.PurchaseDetail != null && purchase.PurchaseDetail.Count > 0)
            {
                id = purchaseBll.Create(purchase);
                if (id!=null)
                {
                    return RedirectToAction("Details", "Purchases", new {id=id });
                }
                else
                {
                    ViewBag.Message = "Purchase added failed";
                }
            }
            ViewBag.ItemId = purchaseBll.GetItem();
            ViewBag.OutletId = purchaseBll.GetOutlet();
            ViewBag.EmployeeId = purchaseBll.GetEmployee();
            ViewBag.Supplier = purchaseBll.Supplier();
            return View(purchase);
        }

        public ActionResult ExportPdf(int id)
        {
            return new ActionAsPdf("DetailsPdf", new { id = id });
        }

        // GET: Items/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return RedirectToAction("Error", "Home");
        //    }
        //    Purchase purchase = purchaseBll.GetById(id);
        //    if (purchase == null)
        //    {
        //        return RedirectToAction("Error", "Home");
        //    }
        //    ViewBag.OutletId = purchaseBll.GetOutlet();
        //    ViewBag.EmployeeId = purchaseBll.GetEmployee();
        //    return View(purchase);
        //}

        //// POST: Items/Edit/5
        //[HttpPost]
        //public ActionResult Edit(Purchase purchase)
        //{


        //    if (ModelState.IsValid)
        //    {
        //        status = purchaseBll.Edit(purchase);
        //        if (status == true)
        //        {
        //            return RedirectToAction("List", "Purchases");
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Purchase is not updated succesfully";
        //        }
        //    }

        //    ViewBag.OutletId = purchaseBll.GetOutlet();
        //    ViewBag.EmployeeId = purchaseBll.GetEmployee();
        //    return View(purchase);

        //}

        // GET: Items/Delete/5

        public JsonResult Delete(int id)
        {
            status = purchaseBll.Delete(id);
            if (status == true)
            {
                return Json(1);
            }
            return Json(0);
        }
    }
}