using Rotativa;
using SuperShopManagementSystem.BLL;
using SuperShopManagementSystem.BLL.Operation;
using SuperShopManagementSystem.Models;
using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SuperShopManagementSystem.Controllers.Operation
{
    [Authorize(Roles = "Admin,Employee")]
    public class SalesController : Controller
    {
        // GET: Sales
        SaleBll saleBll = new SaleBll();
        ItemBll itemBll = new ItemBll();
        Common common = new Common();
        bool status = false;
        int id;
        // GET: Items
        public ActionResult List()
        {
            List<Sale> Sales = saleBll.List();
            return View(Sales);
        }

        // GET: Items/Details/5
        public ActionResult Details(int id)
        {
            Sale sale = saleBll.GetById(id);
            return View(sale);
        }

        public ActionResult DetailsPdf(int id)
        {
            Sale sale = saleBll.GetById(id);
            return View(sale);
        }
        
        public ActionResult ExportPdf(int id)
        {
            var cookies = Request.Cookies.AllKeys.ToDictionary(k => k, k => Request.Cookies[k].Value);

            return new ActionAsPdf("DetailsPdf",new { id = id })
            {
                FormsAuthenticationCookieName = FormsAuthentication.FormsCookieName,
                Cookies = cookies
            };
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.OutletId = saleBll.GetOutlet();
            ViewBag.EmployeeId = saleBll.GetEmployee();
            ViewBag.ItemId = saleBll.GetItem();
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        public ActionResult Create(Sale sale)
        { 
            if (ModelState.IsValid && sale.SalesDetails!=null && sale.SalesDetails.Count>0)
            {
                sale.IsDeleted = false;
                id = saleBll.Create(sale);
                if (id !=null)
                {
                    return RedirectToAction("Details", "Sales", new { id=id});
                }
                else
                {
                    ViewBag.Message = "Sale added failed";
                }
            }
            ViewBag.ItemId = saleBll.GetItem();
            ViewBag.OutletId = saleBll.GetOutlet();
            ViewBag.EmployeeId = saleBll.GetEmployee();
            return View(sale);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            Sale sale = saleBll.GetById(id);
            if (sale == null)
            {
                return RedirectToAction("Error", "Home");
            }
            ViewBag.OutletId = saleBll.GetOutlet();
            ViewBag.EmployeeId = saleBll.GetEmployee();
            return View(sale);
        }

        // POST: Items/Edit/5
        [HttpPost]
        public ActionResult Edit(Sale sale)
        {
         

            if (ModelState.IsValid)
            {
                status = saleBll.Edit(sale);
                if (status == true)
                {
                    return RedirectToAction("List", "Sales");
                }
                else
                {
                    ViewBag.Message = "Sale is not updated succesfully";
                }
            }

            ViewBag.OutletId = saleBll.GetOutlet();
            ViewBag.EmployeeId = saleBll.GetEmployee();
            return View(sale);

        }
        // GET: Items/Delete/5
        public JsonResult Delete(int id)
        {
            status = saleBll.Delete(id);
            if (status == true)
            {
                return Json(1);
            }
            return Json(0);
        }
        public JsonResult GetItemSalesPrice(int id)
        {
            Item item = itemBll.GetById(id);
            var ItemPrice = item.SalePrice;
            return Json(ItemPrice);
        }
        public JsonResult GetItemStock(int id)
        {
            var ItemStock = common.GetItemStockById(id);
            return Json(ItemStock);
        }

    }
}
