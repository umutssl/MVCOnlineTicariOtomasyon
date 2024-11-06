using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.SINIFLAR;
namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var departman = c.Departmen.Where(x => x.Durum == true).ToList();
            return View(departman);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmen.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmen.Find(id);
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dept = c.Departmen.Find(id);
            return View("DepartmanGetir", dept);
        }
        public ActionResult DepartmanGüncelle(Departman d)
        {
            var dept = c.Departmen.Find(d.DepartmanID);
            dept.DepartmanAD = d.DepartmanAD;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.DepartmanId == id).ToList();
            var dpt = c.Departmen.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAD).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);
        }
        public ActionResult DepartmanPersonelSatış(int id)
        {
            var degerler = c.SatışHaretkets.Where(x => x.PersonelId == id).ToList();
            var per = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " " + y.PersonelSoyAd).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
        }
    }
}