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
    [Authorize(Roles = "Admin,Employee")]
    public class ItemCategoriesController : Controller
    {
        ShopDbContext db = new ShopDbContext();
        ItemCategoryBll itemCategoryBll = new ItemCategoryBll();
        Common common = new Common();

        bool status;
        // GET: ItemCategories
        public ActionResult List()
        {
            List<ItemCategory> ItemCategories = itemCategoryBll.List();          
            return View(ItemCategories);
        }

        // GET: ItemCategories/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: ItemCategories/Create
        public ActionResult Create()
        {
            ViewBag.autoCode = itemCategoryBll.GenerateAutoCode();
            ViewBag.ParentId = new SelectList(db.ItemCategories, "Id", "Name");
            return View();
        }

        // POST: ItemCategories/Create
        [HttpPost]
        public ActionResult Create(ItemCategory itemCategory, HttpPostedFileBase ImageFile)
        {
            if (ImageFile == null)
            {
                ModelState.AddModelError("Image", "Please upload a picture");
            }

            bool IsValidFormat =common.ImageValidation(ImageFile);


            if (IsValidFormat == false)
            {
                ModelState.AddModelError("Image", "Only jpg, png, jpeg formet is allowed");
            }
            byte[] convertedImage = common.ConvertImage(ImageFile);
            itemCategory.Image = convertedImage;

            if (ModelState.IsValid)
            {
                status = itemCategoryBll.Create(itemCategory);
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
            return View(itemCategory);
        }

        // GET: ItemCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id==null)
            {
                return RedirectToAction("Error", "Home");
            }
            ItemCategory itemCategory = itemCategoryBll.GetById(id);
            if(itemCategory==null)
            {
                return RedirectToAction("Error", "Home");
            }
            ViewBag.parentId = new SelectList(db.ItemCategories, "Id", "Name");
            return View(itemCategory);
        }

        // POST: ItemCategories/Edit/5
        [HttpPost]
        public ActionResult Edit(ItemCategory itemCategory, HttpPostedFileBase ImageFile)
        {
            if(ImageFile!=null)
            {
                bool IsValidFormate = common.ImageValidation(ImageFile);
                if(IsValidFormate==false)
                {
                    ModelState.AddModelError("Image", "Only jpg , png , jpeg formates are allowed");
                }
                byte[] CurrentImage = common.ConvertImage(ImageFile);
                itemCategory.Image = CurrentImage;
            }
            if(ModelState.IsValid)
            {
                status = itemCategoryBll.Edit(itemCategory);
                if (status == true)
                {
                    return RedirectToAction("List", "ItemCategories");
                }
                else
                {
                    ViewBag.Message = "Item category is not updated successfully";
                }
            }
            ViewBag.ParentId = new SelectList(db.ItemCategories, "Id", "Name");
            return View(itemCategory);
            
        }

        // GET: ItemCategories/Delete/5
        public JsonResult Delete(int id)
        {
            status = itemCategoryBll.Delete(id);

            if (status == true)
            {
                return Json(1);
            }

            return Json(0);
        }

        // POST: ItemCategories/Delete/5
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
