using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.SINIFLAR;
namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Caris.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Ürüns.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = c.Ürüns.Sum(x => x.Stok).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from x in c.Ürüns select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            var deger7 = c.Ürüns.Count(x => x.Stok <= 20).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from x in c.Ürüns orderby x.SatışFiyat descending select x.ÜrünAd).FirstOrDefault();
            ViewBag.d8 = deger8;
            var deger9 = (from x in c.Ürüns orderby x.SatışFiyat ascending select x.ÜrünAd).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = c.Ürüns.Count(x => x.ÜrünAd == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;
            var deger11 = c.Ürüns.Count(x => x.ÜrünAd == "Laptop").ToString();
            ViewBag.d11 = deger11;
            var deger12 = c.Ürüns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y=>y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;
            var deger13 = c.Ürüns.Where(u => u.ÜrünID == (c.SatışHaretkets.GroupBy(x => x.ÜrünId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.ÜrünAd).FirstOrDefault();
            ViewBag.d13 = deger13;
            var deger14 = c.SatışHaretkets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = deger14;
            DateTime bugün = DateTime.Today;
            var deger15 = c.SatışHaretkets.Count(x => x.Tarih == bugün).ToString();
            ViewBag.d15 = deger15;
            var deger16 = c.SatışHaretkets.Where(x => x.Tarih == bugün).Sum(y => (decimal?)y.ToplamTutar).ToString();
            ViewBag.d16 = deger16;
            return View();
        }
        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Caris
                        group x by x.CariŞehir into g
                        select new SınıfGrupcs
                        {
                            Şehir = g.Key,
                            Sayı = g.Count()
                        };
            return View(sorgu.ToList());
        }
        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departman.DepartmanAD into g
                         select new SınıfGrup2
                         {
                             Departman = g.Key,
                             Sayı = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var sorgu=c.Caris.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial3()
        {
            var sorgu3=c.Ürüns.ToList();
            return PartialView(sorgu3);
        }
        public PartialViewResult Partial4()
        {
            var sorgu5 = from x in c.Ürüns
                         group x by x.Marka into g
                         select new SınıfGrup5
                         {
                             marka = g.Key,
                             sayı = g.Count()
                         };
            return PartialView(sorgu5.ToList());
        }
    }
}