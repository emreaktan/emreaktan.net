using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Class;
namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        Context c = new Context();
        // GET: Istatistik
        public ActionResult Index()
        {
            //Cari Hesap sayısı
            var deger1 = c.Currents.Count().ToString();
            ViewBag.d1 = deger1;
            //ürün sayısı
            var deger2 = c.Products.Count().ToString();
            ViewBag.d2 = deger2;
            //Personel Sayısı
            var deger3 = c.Employees.Count().ToString();
            ViewBag.d3 = deger3;
            //Kategori Sayısı
            var deger4 = c.Categories.Count().ToString();
            ViewBag.d4 = deger4;
            //stok Sayısı
            var deger5 = c.Products.Sum(x=>x.Stock).ToString();
            ViewBag.d5 = deger5;

            //Marka Sayısı
            var deger6 = (from x in c.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.d6 = deger6;

            //stok Sayısı
            var deger7 = c.Products.Count(x => x.Stock<=20).ToString();
            ViewBag.d7 = deger7;

            //Max Fiyatlı ürün
            var deger8 = (from x in c.Products where x.Status == true orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            //var deger8 = c.Products.Max(x => x.SalePrice).ToString();
            ViewBag.d8 = deger8;

            //Min Fiyatlı ürün
            var deger9 = (from x in c.Products where x.Status == true orderby x.SalePrice  ascending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = deger9;

            //Buzdolabı sayısı
            var deger10 = c.Products.Count(x => x.ProductName == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;

            //Labtop Sayısı
            var deger11 = c.Products.Count(x => x.ProductName == "Labtop").ToString();
            ViewBag.d11 = deger11;

            //Max Marka
            var deger12 = c.Products.GroupBy(x => x.Brand).OrderByDescending(z => z.Count()).Select(y=> y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;

            //En çok satan ürün adı
            var deger13 = c.Products.Where(u => u.ProductID == (c.SaleTransactions.GroupBy(x => x.ProductID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(h=>h.ProductName).FirstOrDefault();
            ViewBag.d13 = deger13;


            //Satış Toplamı
            var deger14 = c.SaleTransactions.Sum(x => x.TotalAmount).ToString();
            ViewBag.d14 = deger14;

            //Bugünki Satışlar
            var deger15 = c.SaleTransactions.Count(x => x.SaleDate==DateTime.Today).ToString();
            ViewBag.d15 = deger15;

            //Bugünki Satışlar
            var deger16 = c.SaleTransactions.Where(x => x.SaleDate == DateTime.Today).Sum(y => y.TotalAmount).ToString();
            ViewBag.d16 = deger16;

            return View();
        }

        public ActionResult OzetTablolar()
        {
            return View();
        }
    }
}