using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Class;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departments.Where(x => x.Status == true).ToList();
            return View(degerler);
        }


        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Department d)
        {
            c.Departments.Add(d);
            d.Status = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {

            var departmanid = c.Departments.Find(id);
            departmanid.Status = false;
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {

            var dpt = c.Departments.Find(id);
            return View("DepartmanGetir", dpt);
        }
        public ActionResult DepartmanGuncelle(Department d)

        {
            var dp = c.Departments.Find(d.DeparmentID);
            dp.DeparmentName = d.DeparmentName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Employees.Where(x => x.DeparmentId == id).ToList();
            var dpt = c.Departments.Where(x => x.DeparmentID == id).Select(y => y.DeparmentName).FirstOrDefault();

            ViewBag.DepartmanAdi = dpt;
            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SaleTransactions.Where(x => x.EmployeeID == id).ToList();
            var dpersonel = c.Employees.Where(y => y.EmployeeID == id).Select(z => z.EmployeeName + " " + z.EmployeeSurname).FirstOrDefault();

            ViewBag.dp = dpersonel;
            return View(degerler);
        }

    }

}
