using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.SINIFLAR;
namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Caris.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Cari p)
        {
            p.Durum = true;
            c.Caris.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var car = c.Caris.Find(id);
            car.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGeir(int id)
        {
            var cari = c.Caris.Find(id);
            return View(cari);
        }
        public ActionResult CariGüncelle(Cari a)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGeti");
            }
            var cari = c.Caris.Find(a.CariID);
            cari.CariAd = a.CariAd;
            cari.CariSoyAd = a.CariSoyAd;
            cari.CariŞehir = a.CariŞehir;
            cari.CariMail = a.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MüşteriSatış(int id)
        {
            var degerler = c.SatışHaretkets.Where(x => x.CariId == id).ToList();
            var cr = c.Caris.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyAd).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);
        }
    }

}