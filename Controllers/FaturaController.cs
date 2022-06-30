using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Class;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context c = new Context();
        // GET: Fatura
        public ActionResult Index()
        {
            var liste = c.Invoices.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Invoice fatura)
        {
            c.Invoices.Add(fatura);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var deger = c.Invoices.Find(id);

            return View("FaturaGetir",deger);
        }

        public ActionResult FaturaGuncelle(Invoice inv)

        {

            var fatura = c.Invoices.Find(inv.InvoiceID);
            fatura.InvoiceSerialNumber = inv.InvoiceSerialNumber;
            fatura.InvoiceNumber = inv.InvoiceNumber;
            fatura.InvoiceDate = inv.InvoiceDate;
            fatura.InvoiceTime = inv.InvoiceTime;
            fatura.Receiver = inv.Receiver;
            fatura.Submitter = inv.Submitter;
            fatura.TaxAdministration = inv.TaxAdministration;
            fatura.TotalAmount = inv.TotalAmount;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.InvoiceItems.Where(y => y.InvoiceItemID == id).ToList();

            return View(degerler);
        }

        public ActionResult KalemSil(int id)
        {
            var silinecekdeger = c.InvoiceItems.Find(id);
            silinecekdeger.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(InvoiceItem ivt )
        {
            c.InvoiceItems.Add(ivt);
            c.SaveChanges();

            //var deger = c.Invoices.Find(ivt.InvoiceId);
            //ViewBag.dgr1=deger;

            return RedirectToAction("Index");
        }


    }
}