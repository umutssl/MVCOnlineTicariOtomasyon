using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.SINIFLAR;
using PagedList;
using PagedList.Mvc;
namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class ÜrünController : Controller
    {
        // GET: Ürün
        Context c = new Context();
        public ActionResult Index(string p )
        {
            var ürünler = from x in  c.Ürüns select x;
            if (!string.IsNullOrEmpty(p))
            {
                ürünler = ürünler.Where(y => y.ÜrünAd.Contains(p));
            }
            return View(ürünler.ToList());
        }
        [HttpGet]
        public ActionResult YeniÜrün()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.KategoriAd,
                                               Value=x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult Yeniürün(Ürün ü)
        {
            c.Ürüns.Add(ü);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ÜrünSil(int id)
        {
            var deger = c.Ürüns.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ÜrünGetir(int id)
        {

            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var ürün=c.Ürüns.Find(id);
            return View("ÜrünGetir", ürün);
        }
        public ActionResult ÜrünGüncelle(Ürün r)
        {
            var urn=c.Ürüns.Find(r.ÜrünID);
            urn.AlışFiyat=r.AlışFiyat;
            urn.Durum=r.Durum;
            urn.Marka=r.Marka;
            urn.SatışFiyat=r.SatışFiyat;
            urn.Stok=r.Stok;
            urn.ÜrünAd=r.ÜrünAd;
            urn.ÜrünGörsel=r.ÜrünGörsel;
            c.SaveChanges();
            return RedirectToAction("Index");   

        }
        public ActionResult ÜrünListesi()
        {
            var degerler=c.Ürüns.ToList();
            return View(degerler);
        }
        [HttpGet]
        public  ActionResult SatışYap(int id)
        {
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyAd,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();

            ViewBag.dgr3 = deger3;
            var deger1 = c.Ürüns.Find(id);
            ViewBag.dgr1 = deger1.ÜrünID;
            ViewBag.dgr2 = deger1.SatışFiyat;
            return View();
        }
        [HttpPost]
        public ActionResult SatışYap(SatışHaretket p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatışHaretkets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","Satış");
            
        }
    }
}