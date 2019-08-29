using SuperShopManagementSystem.BLL;
using SuperShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShopManagementSystem.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class PartiesController : Controller
    {
        Common common = new Common();
        PartyBll partyBll = new PartyBll();
        bool status = false;
        // GET: Items
        public ActionResult List()
        {
            List<Party> Parties = partyBll.List();
            return View(Parties);
        }
        // GET: Items/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.autoCode = partyBll.GenerateAutoCode();
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        public ActionResult Create(Party party, HttpPostedFileBase ImageFile)
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
            party.Image = ConvertedImage;
            if (ModelState.IsValid)
            {
                status = partyBll.Create(party);
                if (status == true)
                {
                    return RedirectToAction("List", "Parties");
                }
                else
                {
                    ViewBag.Message = "Expense Catagory added failed";
                }
            }
            return View(party);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            Party party = partyBll.GetById(id);
            if (party == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(party);
        }

        // POST: Items/Edit/5
        [HttpPost]
        public ActionResult Edit(Party party, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                bool isValidFormate = common.ImageValidation(ImageFile);
                if (isValidFormate == false)
                {
                    ModelState.AddModelError("Image", "only png,jpeg,jpg formates are allowed");
                }
                byte[] convertedImage = common.ConvertImage(ImageFile);
                party.Image = convertedImage;
            }

            if (ModelState.IsValid)
            {
                status = partyBll.Edit(party);
                if (status == true)
                {
                    return RedirectToAction("List", "Parties");
                }
                else
                {
                    ViewBag.Message = "Item is not updated succesfully";
                }
            }
            return View(party);
        }

        // GET: Items/Delete/5
        public JsonResult Delete(int id)
        {
            status = partyBll.Delete(id);
            if (status == true)
            {
                return Json(1);
            }
            return Json(0);
        }
    }
}