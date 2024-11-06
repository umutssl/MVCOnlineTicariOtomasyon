using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.SINIFLAR;
namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class SatışController : Controller
    {
        // GET: Satış
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SatışHaretkets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatış()
        {
            List<SelectListItem> deger1 = (from x in c.Ürüns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ÜrünAd,
                                               Value = x.ÜrünID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in c.Caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyAd,
                                               Value = x.CariID.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyAd,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatış(SatışHaretket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatışHaretkets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatışGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Ürüns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ÜrünAd,
                                               Value = x.ÜrünID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in c.Caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyAd,
                                               Value = x.CariID.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyAd,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var deger = c.SatışHaretkets.Find(id);
            return View("SatışGetir", deger);
        }
        public ActionResult SatışGüncelle(SatışHaretket st)
        {
            var deger = c.SatışHaretkets.Find(st.SatışId);
            deger.CariId=st.CariId;
            deger.Adet=st.Adet;
            deger.Fiyat=st.Fiyat;
            deger.PersonelId=st.PersonelId; 
            deger.Tarih=st.Tarih;
            deger.ToplamTutar=st.ToplamTutar;
            deger.ÜrünId=st.ÜrünId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatışDetay(int id)
        {
            var degerler = c.SatışHaretkets.Where(x=>x.SatışId==id).ToList();
            return View(degerler);
        }
    }
}