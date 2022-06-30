using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Class;
namespace MVCOnlineTicariOtomasyon.Controllers
{
    
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var personeller = c.Employees.ToList();            
            return View(personeller);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DeparmentName,
                                               Value = x.DeparmentID.ToString()

                                           }).ToList();
            ViewBag.dgr2 = deger1;

            return View();
        }
       [HttpPost]
        public ActionResult PersonelEkle(Employee id)
        {
            c.Employees.Add(id);
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DeparmentName,
                                               Value = x.DeparmentID.ToString()

                                           }).ToList();
            ViewBag.personelDgr=deger1;

            var personel = c.Employees.Find(id);

            return View(personel);
        }

        public ActionResult PersonelGuncelle(Employee p)
        {
            var prs = c.Employees.Find(p.EmployeeID);
            prs.EmployeeName = p.EmployeeName;
            prs.EmployeeSurname = p.EmployeeSurname;
            prs.EmployeeImage = p.EmployeeImage;
            prs.DeparmentId = p.DeparmentId;
            c.SaveChanges();

            return RedirectToAction("Index");

        }

    }
}