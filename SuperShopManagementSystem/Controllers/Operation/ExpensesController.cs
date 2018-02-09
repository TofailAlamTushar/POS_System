using Rotativa;
using SuperShopManagementSystem.BLL.Operation;
using SuperShopManagementSystem.Models.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShopManagementSystem.Controllers.Operation
{
    public class ExpensesController : Controller
    {
        ExpenseBll expenseBll = new ExpenseBll();
        bool status = false;
        int id;

        public ActionResult List()
        {
            List<Expense> Expenses = expenseBll.List();
            return View(Expenses);
        }

        public ActionResult Create ()
        {
            ViewBag.EmployeeId = expenseBll.GetEmployee();
            ViewBag.OutletId = expenseBll.GetOutlet();
            ViewBag.ExpenseItemId = expenseBll.GetExpenseItem();
            return View();
        }

        [HttpPost]
        public ActionResult Create (Expense expense)
        {
            if(ModelState.IsValid && expense.ExpenseDetails!=null && expense.ExpenseDetails.Count>0)
            {
                id = expenseBll.Create(expense);
                if(id!=null)
                {
                    return RedirectToAction("Details", "Expenses", new {id=id });
                }
                else
                {
                    ViewBag.Massege = "Expense is not saved successfully";
                }
            }
            ViewBag.EmployeeId = expenseBll.GetEmployee();
            ViewBag.OutletId = expenseBll.GetOutlet();
            ViewBag.ExpenseItemId = expenseBll.GetExpenseItem();
            return View(expense);
        }

        public ActionResult Details(int id)
        {
            Expense expense = expenseBll.GetById(id);
            return View(expense);
        }
        public ActionResult DetailsPdf(int id)
        {
            Expense expense = expenseBll.GetById(id);
            return View(expense);
        }
        public ActionResult ExportPdf(int id)
        {
            return new ActionAsPdf("DetailsPdf", new { id = id });
        }
    }
}