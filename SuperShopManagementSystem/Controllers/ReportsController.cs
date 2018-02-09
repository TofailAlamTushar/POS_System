using SuperShopManagementSystem.BLL;
using SuperShopManagementSystem.Models.Operation;
using SuperShopManagementSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;

namespace SuperShopManagementSystem.Controllers
{
    public class ReportsController : Controller
    {
        ReportBll reportBll = new ReportBll();

        //>>>>Expense reports starts from here<<<<<

        public ActionResult Expense()
        {
            ViewBag.OutletId = reportBll.GetOutlet();
            return View();
        }
        static List<Expense> ExpensesPdf = new List<Expense>();
        [HttpPost]
        public ActionResult Expense(ReportVm reportVm )
        {
            List<Expense> Expenses = reportBll.GetExpensesByReportVm(reportVm);
            ExpensesPdf = Expenses;
            ViewBag.OutletId = reportBll.GetOutlet();
            return View(Expenses);
        }
        public ActionResult ExpenseReportPdf()
        {
            if(ExpensesPdf==null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(ExpensesPdf);
        }
        public ActionResult ExportPdf()
        {
            return new ActionAsPdf("ExpenseReportPdf");
        }

        //>>>>Purchaase Reports starts from here<<<<<

        public ActionResult PurchaseReport()
        {
            ViewBag.OutletId = reportBll.GetOutlet();
            return View();
        }
        static List<Purchase> PurchasesPdf = new List<Purchase>();
        [HttpPost]
        public ActionResult PurchaseReport(ReportVm reportVm)
        {
            List<Purchase> Purchases = reportBll.GetPurchasesByReportVm(reportVm);
            PurchasesPdf = Purchases;
            ViewBag.OutletId = reportBll.GetOutlet();
            return View(Purchases);
        }
        public ActionResult PurchaseReportPdf()
        {
            if (PurchasesPdf == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(PurchasesPdf);
        }
        public ActionResult ExportPurchasePdf()
        {
            return new ActionAsPdf("PurchaseReportPdf");
        }

        //>>>Sales reports starts from here<<<

        public ActionResult SalesReport()
        {
            ViewBag.OutletId = reportBll.GetOutlet();
            return View();
        }
        static List<Sale> SalesPdf = new List<Sale>();
        [HttpPost]
        public ActionResult SalesReport(ReportVm reportVm)
        {
            List<Sale> Sales = reportBll.GetSalesByReportVm(reportVm);
            SalesPdf = Sales;
            ViewBag.OutletId = reportBll.GetOutlet();
            return View(Sales);
        }
        public ActionResult SalesReportPdf()
        {
            if (SalesPdf == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(SalesPdf);
        }
        public ActionResult ExportSalesPdf()
        {
            return new ActionAsPdf("SalesReportPdf");
        }

        //>>>Income reports starts from here<<<

        public ActionResult IncomeReport()
        {
            ViewBag.OutletId = reportBll.GetOutlet();
            return View();
        }
        static IncomeVm incomeVmForPdf = new IncomeVm(); 
        [HttpPost]
        public ActionResult IncomeReport(ReportVm reportVm)
        {
            IncomeVm incomeVm = reportBll.GetIncomeVmByReportVm(reportVm);
            incomeVmForPdf = incomeVm;
            ViewBag.OutletId = reportBll.GetOutlet();
            return View(incomeVm);
        }
        public ActionResult IncomeReportPdf()
        {
            if (incomeVmForPdf == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(incomeVmForPdf);
        }
        public ActionResult ExportIncomePdf(IncomeVm incomeVm)
        {
            return new ActionAsPdf("IncomeReportPdf");
        }

        //>>>Stpck report starts from here<<<

        public ActionResult StockReport()
        {
            ViewBag.OutletId = reportBll.GetOutlet();
            return View();
        }
        static List<StockVm> StockReportListPdf = new List<StockVm>();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StockReport(ReportVm reportVm)
        {
            List<StockVm> StockReportList = reportBll.GetStockReportList(reportVm);
            StockReportListPdf = StockReportList;
            ViewBag.OutletId = reportBll.GetOutlet();
            return View(StockReportList);
        }
        public ActionResult StockReportPdf()
        {
            if(StockReportListPdf==null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(StockReportListPdf);
        }

        public ActionResult ExportStockReportPdf()
        {
            return new ActionAsPdf("StockReportPdf");
        }
    }
}