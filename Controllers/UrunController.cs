using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Class;
namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index()
        {
            var urunler = c.Products.Where(x => x.Status == true).ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = new List<SelectListItem>();
            deger2.Add(new SelectListItem { Text = "Aktif", Value = "True" });
            deger2.Add(new SelectListItem { Text = "Pasif", Value = "False" });
            deger2.ToList();
            ViewBag.dgr2 = deger2;



            return View();
        }

        [HttpPost]

        public ActionResult YeniUrun(Product p)
        {
            c.Products.Add(p);
            p.Status = true;
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)

        {
            var deger = c.Products.Find(id);
            deger.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()

                                           }).ToList();

            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = new List<SelectListItem>();
            deger2.Add(new SelectListItem { Text = "Aktif", Value = "True" });
            deger2.Add(new SelectListItem { Text = "Pasif", Value = "False" });
            deger2.ToList();
            ViewBag.dgr3 = deger2;

            var urundeger =c.Products.Find(id);
            return View("UrunGetir",urundeger);
        }

        
        public ActionResult UrunGuncelle(Product p)
        {
            var deger = c.Products.Find(p.ProductID);
            deger.PurchasePrice = p.PurchasePrice;
            deger.Status = p.Status;
            deger.CategoryId = p.CategoryId;
            deger.Brand = p.Brand;
            deger.SalePrice = p.SalePrice;
            deger.Stock = p.Stock;
            deger.ProductName = p.ProductName;
            deger.ProductImage = p.ProductImage;
            c.SaveChanges();

            return RedirectToAction("Index");

        }


        //pdf e dönüştürme

        public ActionResult Urunlistesi()

        {
            var degerler = c.Products.ToList();
            return View(degerler);
        }
    }
}