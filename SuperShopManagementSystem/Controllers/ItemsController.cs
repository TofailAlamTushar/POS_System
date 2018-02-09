using SuperShopManagementSystem.BLL;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShopManagementSystem.Controllers
{
    public class ItemsController : Controller
    {
        Common common = new Common();
        ItemBll itemBll = new ItemBll();
        bool status = false;
        // GET: Items
        public ActionResult List()
        {
            List<Item> items =itemBll.List();
            return View(items);
        }

        // GET: Items/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.autoCode = itemBll.GenerateAutoCode();
            ViewBag.ItemCategoryId = itemBll.GetItemCategory();
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        public ActionResult Create(Item item, HttpPostedFileBase ImageFile)
        {
            if(ImageFile==null)
            {
                ModelState.AddModelError("Image", "Please upload an Image");
            }
            bool isValidFormate = common.ImageValidation(ImageFile);
            if(isValidFormate==false)
            {
                ModelState.AddModelError("Image", "only png,jpg,jpeg format is allowed");
            }

            byte[] ConvertedImage = common.ConvertImage(ImageFile);
            item.Image = ConvertedImage;
            if(ModelState.IsValid)
            {
                status=itemBll.Create(item);
                if(status==true)
                {
                    return RedirectToAction("List", "Items");
                }
                else
                {
                    ViewBag.Message = "Expense Catagory added failed";
                }
            }
            ViewBag.ParentId = itemBll.GetItemCategory();
            return View(item);
            
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id==null)
            {
                return RedirectToAction("Error", "Home");
            }
            Item item = itemBll.GetById(id);
            if(item==null)
            {
                return RedirectToAction("Error", "Home");
            }
            ViewBag.ItemCategoryId = itemBll.GetItemCategory();
            return View(item);
        }

        // POST: Items/Edit/5
        [HttpPost]
        public ActionResult Edit( Item item, HttpPostedFileBase ImageFile)
        {
          if(ImageFile!=null)
            {
                bool isValidFormate = common.ImageValidation(ImageFile);
                if (isValidFormate == false)
                {
                    ModelState.AddModelError("Image", "only png,jpeg,jpg formates are allowed");
                }
                byte[] convertedImage = common.ConvertImage(ImageFile);
                item.Image = convertedImage;
            }

            if (ModelState.IsValid)
            {
                status = itemBll.Edit(item);
                if(status==true)
                {
                    return RedirectToAction("List", "Items");
                }
                else
                {
                    ViewBag.Message = "Item is not updated succesfully";
                }
            }

            ViewBag.ItemCategoryId = itemBll.GetItemCategory();
             return View(item);
            
        }

        // GET: Items/Delete/5
        public JsonResult Delete(int id)
        {
            status = itemBll.Delete(id);
            if(status==true)
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
