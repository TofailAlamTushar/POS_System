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
    public class ExpenseItemsController : Controller
    {
        Common common = new Common();
        ExpenseItemBll expenseItemBll = new ExpenseItemBll();
        bool status = false;
        // GET: Items
        public ActionResult List()
        {
            List<ExpenseItem> ExpenseItems = expenseItemBll.List();
            return View(ExpenseItems);
        }

        // GET: Items/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Items/Create

        public ActionResult Create()
        {
            ViewBag.autoCode = expenseItemBll.GenerateAutoCode();
            ViewBag.ExpenseCategoryId = expenseItemBll.GetExpenseItemCategory();
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        public ActionResult Create(ExpenseItem expenseItem, HttpPostedFileBase ImageFile)
        {
            if (ImageFile == null)
            {
                ModelState.AddModelError("Image", "Please upload an Image");
            }
            bool isValidFormate = common.ImageValidation(ImageFile);
            if (isValidFormate == false)
            {
                ModelState.AddModelError("Image", "only png,jpg,jpeg format is allowed");
            }

            byte[] ConvertedImage = common.ConvertImage(ImageFile);
            expenseItem.Image = ConvertedImage;
            if (ModelState.IsValid)
            {
                status = expenseItemBll.Create(expenseItem);
                if (status == true)
                {
                    return RedirectToAction("List", "ExpenseItems");
                }
                else
                {
                    ViewBag.Message = "Expense Catagory added failed";
                }
            }
            ViewBag.ExpenseCategoryId = expenseItemBll.GetExpenseItemCategory();
            return View(expenseItem);

        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            ExpenseItem expenseItem = expenseItemBll.GetById(id);
            if (expenseItem == null)
            {
                return RedirectToAction("Error", "Home");
            }
            ViewBag.ExpenseCategoryId = expenseItemBll.GetExpenseItemCategory();
            return View(expenseItem);
        }

        // POST: Items/Edit/5
        [HttpPost]
        public ActionResult Edit(ExpenseItem expenseItem, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                bool isValidFormate = common.ImageValidation(ImageFile);
                if (isValidFormate == false)
                {
                    ModelState.AddModelError("Image", "only png,jpeg,jpg formates are allowed");
                }
                byte[] convertedImage = common.ConvertImage(ImageFile);
                expenseItem.Image = convertedImage;
            }

            if (ModelState.IsValid)
            {
                status = expenseItemBll.Edit(expenseItem);
                if (status == true)
                {
                    return RedirectToAction("List", "ExpenseItems");
                }
                else
                {
                    ViewBag.Message = "Item is not updated succesfully";
                }
            }

            ViewBag.ExpenseCategoryId = expenseItemBll.GetExpenseItemCategory();
            return View(expenseItem);

        }

        // GET: Items/Delete/5
        public JsonResult Delete(int id)
        {
            status = expenseItemBll.Delete(id);
            if (status == true)
            {
                return Json(1);
            }
            return Json(0);
        }

        // POST: Items/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
