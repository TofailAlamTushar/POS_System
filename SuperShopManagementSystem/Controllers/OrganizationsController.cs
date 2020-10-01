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
    public class OrganizationsController : Controller
    {
        Common common = new Common();
        OrganizationBll organizationBll = new OrganizationBll();
        bool status = false;
        // GET: Items
        public ActionResult List()
        {
            List<Organization> Organizations = organizationBll.List();
            return View(Organizations);
        }

        // GET: Items/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.autoCode = organizationBll.GenerateAutoCode();
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        public ActionResult Create(Organization organization, HttpPostedFileBase ImageFile)
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
            organization.Image = ConvertedImage;
            if (ModelState.IsValid)
            {
                status = organizationBll.Create(organization);
                if (status == true)
                {
                    return RedirectToAction("List", "Organizations");
                }
                else
                {
                    ViewBag.Message = "Expense Catagory added failed";
                }
            }
            return View(organization);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            Organization organization = organizationBll.GetById(id);
            if (organization == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(organization);
        }

        // POST: Items/Edit/5
        [HttpPost]
        public ActionResult Edit(Organization organization, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                bool isValidFormate = common.ImageValidation(ImageFile);
                if (isValidFormate == false)
                {
                    ModelState.AddModelError("Image", "only png,jpeg,jpg formates are allowed");
                }
                byte[] convertedImage = common.ConvertImage(ImageFile);
                organization.Image = convertedImage;
            }

            if (ModelState.IsValid)
            {
                status = organizationBll.Edit(organization);
                if (status == true)
                {
                    return RedirectToAction("List", "Organizations");
                }
                else
                {
                    ViewBag.Message = "Item is not updated succesfully";
                }
            }
            return View(organization);
        }

        // GET: Items/Delete/5
        public JsonResult Delete(int id)
        {
            status = organizationBll.Delete(id);
            if (status == true)
            {
                return Json(1);
            }
            return Json(0);
        }
    }
}
