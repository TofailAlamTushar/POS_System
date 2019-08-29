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
    public class EmployeesController : Controller
    {
        Common common = new Common();
        EmployeeBll employeeBll = new EmployeeBll();
        bool status = false;
        // GET: Items
        public ActionResult List()
        {
            List<Employee> Employees = employeeBll.List();
            return View(Employees);
        }

        // GET: Items/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.autoCode = employeeBll.GenerateAutoCode();
            ViewBag.OutletId = employeeBll.GetOutlet();
            ViewBag.ReferenceId = employeeBll.GetReference();
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        public ActionResult Create(Employee employee, HttpPostedFileBase ImageFile)
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
            employee.Image = ConvertedImage;
            if (ModelState.IsValid)
            {
                status = employeeBll.Create(employee);
                if (status == true)
                {
                    return RedirectToAction("List","Employees");
                }
                else
                {
                    ViewBag.Message = "Expense Catagory added failed";
                }
            }
            ViewBag.OutletId = employeeBll.GetOutlet();
            ViewBag.ReferenceId = employeeBll.GetReference();
            return View(employee);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            Employee employee = employeeBll.GetById(id);
            if (employee == null)
            {
                return RedirectToAction("Error", "Home");
            }
            ViewBag.OutletId = employeeBll.GetOutlet();
            ViewBag.ReferenceId = employeeBll.GetReference();
            return View(employee);
        }

        // POST: Items/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee employee, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                bool isValidFormate = common.ImageValidation(ImageFile);
                if (isValidFormate == false)
                {
                    ModelState.AddModelError("Image", "only png,jpeg,jpg formates are allowed");
                }
                byte[] convertedImage = common.ConvertImage(ImageFile);
                employee.Image = convertedImage;
            }

            if (ModelState.IsValid)
            {
                status = employeeBll.Edit(employee);
                if (status == true)
                {
                    return RedirectToAction("List", "Employees");
                }
                else
                {
                    ViewBag.Message = "Item is not updated succesfully";
                }
            }
            ViewBag.OutletId = employeeBll.GetOutlet();
            ViewBag.ReferenceId = employeeBll.GetReference();
            return View(employee);
        }

        // GET: Items/Delete/5
        public JsonResult Delete(int id)
        {
            status = employeeBll.Delete(id);
            if (status == true)
            {
                return Json(1);
            }
            return Json(0);
        }
    }
}