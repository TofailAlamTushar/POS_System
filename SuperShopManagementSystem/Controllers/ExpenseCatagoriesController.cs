using SuperShopManagementSystem.BLL;
using SuperShopManagementSystem.Context;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShopManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExpenseCatagoriesController : Controller
    {
        ShopDbContext db = new ShopDbContext();
        ExpenseCatagoryBll expenseCatagoryBll = new ExpenseCatagoryBll();
        bool status;

        // GET: ExpenseCatagories
        public ActionResult List()
        {
           
           List<ExpenseCatagory> listOfExpenseCatagory = expenseCatagoryBll.List();
           return View(listOfExpenseCatagory);

        }

        // GET: ExpenseCatagories/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: ExpenseCatagories/Create

        public ActionResult Create()
        {
            ViewBag.autoCode=expenseCatagoryBll.GenerateAutoCode();
            ViewBag.ParentId = new SelectList(db.ExpenseCatagories, "Id", "Name");
            return View();
        }

        // POST: ExpenseCatagories/Create
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Create(ExpenseCatagory ExpenseCatagories, HttpPostedFileBase ImageFile)
        {

            // TODO: Add insert logic here
            if (ImageFile == null)
            {
                ModelState.AddModelError("Image", "Please upload a picture");
            }

            bool IsValidFormat = expenseCatagoryBll.ImageValidation(ImageFile);


            if (IsValidFormat == false)
            {
                ModelState.AddModelError("Image", "Only jpg, png, jpeg formet is allowed");
            }
            byte[] convertedImage = expenseCatagoryBll.ConvertImage(ImageFile);
            ExpenseCatagories.Image = convertedImage;

            if (ModelState.IsValid)
            {
                status = expenseCatagoryBll.Create(ExpenseCatagories);
                if (status == true)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    ViewBag.Message = "Expense Catagory added failed";
                }   
            }
            ViewBag.ParentId = new SelectList(db.ExpenseCatagories, "Id", "Name");
            return View(ExpenseCatagories);           
        }

        //GET: ExpenseCatagories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            ExpenseCatagory expenseCatagory = expenseCatagoryBll.GetById(id);
            if (expenseCatagory == null)
            {
                return RedirectToAction("Error", "Home");
            }
            ViewBag.parentId = new SelectList(db.ExpenseCatagories, "Id", "Name");
            return View(expenseCatagory);
        }

        //POST: ExpenseCatagories/Edit/5

        [HttpPost]
        public ActionResult Edit(ExpenseCatagory ExpenseCatagories, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                bool IsValidFormat = expenseCatagoryBll.ImageValidation(ImageFile);
                if (IsValidFormat == false)
                {
                    ModelState.AddModelError("Image", "Only jpg, png, jpeg formet is allowed");
                }
                byte[] convertedImage = expenseCatagoryBll.ConvertImage(ImageFile);
                ExpenseCatagories.Image = convertedImage;             
            }

            if (ModelState.IsValid)
            {
                status = expenseCatagoryBll.Edit(ExpenseCatagories);
                if(status==true)
                {
                    return RedirectToAction("List","ExpenseCatagories");
                }
                else
                {
                    ViewBag.Message = "Expense Catagory update failed";
                }
            }
            ViewBag.parentId = new SelectList(db.ExpenseCatagories, "Id", "Name");
            return View(ExpenseCatagories);            
        }

        //GET: ExpenseCatagories/Delete/5
        public JsonResult Delete(int id)
        {
            status = expenseCatagoryBll.Delete(id);

            if (status==true)
            {
                return Json(1);
            }

            return Json(0);
        }

        //public JsonResult GetParentCategories()
        //{
        //    var ExpenseCategories = expenseCatagoryBll.GetParentCategories();
        //    var jsonData = ExpenseCategories.Select(m => new {m.Id, m.Name });

        //    return Json(jsonData, JsonRequestBehavior.AllowGet);
        //}
    }
}
