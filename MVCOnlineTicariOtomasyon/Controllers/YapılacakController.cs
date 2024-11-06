using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.SINIFLAR;
namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class YapılacakController : Controller
    {
        // GET: Yapılacak
        Context c = new Context();
        public ActionResult Index()
        {
           var deger1=c.Caris.Count().ToString();
            ViewBag.d1=deger1;

            var deger2 = c.Ürüns.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = c.Kategoris.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4=(from x in c.Caris select x.CariŞehir).Distinct().Count().ToString();
            ViewBag.d4 = deger4;

            var yapılacaklar = c.Yapılacaks.ToList();
            return View(yapılacaklar);

        }
    }
}