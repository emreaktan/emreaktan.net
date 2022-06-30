using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Class;
namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari

        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Currents.Where(x => x.Status == true).ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            List<SelectListItem> deger1 = new List<SelectListItem>();
            deger1.Add(new SelectListItem { Text = "Aktif", Value = "True" });
            deger1.Add(new SelectListItem { Text = "Pasif", Value = "False" });
            deger1.ToList();
            ViewBag.dgr1 = deger1;


            return View();
        }

        [HttpPost]

        public ActionResult YeniCari(Current cari)
        {
            c.Currents.Add(cari);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var deger = c.Currents.Find(id);
            deger.Status = false;
            c.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult CariGetir(int id)
        {
           
            List<SelectListItem> deger2 = new List<SelectListItem>();
            deger2.Add(new SelectListItem { Text = "Aktif", Value = "True" });
            deger2.Add(new SelectListItem { Text = "Pasif", Value = "False" });
            deger2.ToList();
            ViewBag.dgr2 = deger2;

            var cari = c.Currents.Find(id);

            return View(cari);
        }

        public ActionResult CariGuncelle(Current cr)
        {

            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }

            var cari = c.Currents.Find(cr.CurrentID);
                cari.CurrentName = cr.CurrentName;
                cari.CurrentSurname = cr.CurrentSurname;
                cari.CurrentTittle = cr.CurrentTittle;
                cari.CurrentCity = cr.CurrentCity;
                cari.CurrrentMail = cr.CurrrentMail;
                cari.Status = true;
                c.SaveChanges();

                return RedirectToAction("Index");
                  

        }

        public ActionResult MusteriSatis(int id)

        {
            var degerler = c.SaleTransactions.Where(x => x.CurrentID == id).ToList();
            var cr = c.Currents.Where(x => x.CurrentID == id).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.carideger = cr;
            return View(degerler);
        }
    }
}