using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Class;
namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SaleTransactions.ToList();
            return View(degerler);
        }

        [HttpGet]

        public ActionResult SatisYap()
        {
            List<SelectListItem> deger1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in c.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentSurname,
                                               Value = x.CurrentID.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();

            ViewBag.satisDeger1 = deger1;
            ViewBag.satisDeger2 = deger2;
            ViewBag.satisDeger3 = deger3;


            return View();
        }

        [HttpPost]
        public ActionResult SatisYap(SaleTransaction id)
        {
            id.SaleDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SaleTransactions.Add(id);

            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in c.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentSurname,
                                               Value = x.CurrentID.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();

            ViewBag.satisDeger1 = deger1;
            ViewBag.satisDeger2 = deger2;
            ViewBag.satisDeger3 = deger3;

            var deger = c.SaleTransactions.Find(id);
            return View("SatisGetir", deger);
        }

        public ActionResult SatisGuncelle(SaleTransaction St)
        {
            var deger = c.SaleTransactions.Find(St.TransactionID);
            deger.CurrentID = St.CurrentID;
            deger.Quantity = St.Quantity;
            deger.Price = St.Price;
            deger.EmployeeID = St.EmployeeID;
            deger.SaleDate = St.SaleDate;
            deger.TotalAmount = St.TotalAmount;
            deger.ProductID = St.ProductID;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult SatisDetay(int id)
        {

            var degerler = c.SaleTransactions.Where(x => x.TransactionID == id).ToList();

            return View(degerler);

        }
    }
}