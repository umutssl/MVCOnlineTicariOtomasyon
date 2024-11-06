using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MVCOnlineTicariOtomasyon.Models;
using MVCOnlineTicariOtomasyon.Models.SINIFLAR;
using Newtonsoft.Json;
using Context = MVCOnlineTicariOtomasyon.Models.SINIFLAR.Context;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        Models.SINIFLAR.Context c = new Models.SINIFLAR.Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(750, 750);
            grafikciz.AddTitle("Kategori-Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new[] { "Beyaz Eşya", "Küçük Ev Aletler", "Bilgisayar" }, yValues: new[] { 85, 66, 98 }).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index3()
        {
            ArrayList xvlaue = new ArrayList();
            ArrayList yvlaue = new ArrayList();
            var sonuçlar =c.Ürüns.ToList();
            sonuçlar.ToList().ForEach(x =>xvlaue.Add(x.ÜrünAd));   
            sonuçlar.ToList().ForEach(y =>yvlaue.Add(y.Stok));
            var grafik = new Chart(width: 750, height: 750).AddTitle("Stoklar").AddSeries(chartType: "Pie", name: "Stok", xValue: xvlaue, yValues: yvlaue);
            return File(grafik.ToWebImage().GetBytes(), "image/Jpeg");
                
        }
        
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisulizeÜrünResult()
        {
            return Json(ürünlistesi(), JsonRequestBehavior.AllowGet);
        }
        public List<Sınıf1> ürünlistesi()
        {
            List<Sınıf1> snf = new List<Sınıf1>();
            snf.Add(new Sınıf1()
            {
                ürünad = "Bilgisayar",
                stok = 120
            });
            snf.Add(new Sınıf1()
            {
                ürünad = "Beyaz Eşya",
                stok = 150
            });
            snf.Add(new Sınıf1()
            {
                ürünad = "Küçük Ev Aletleri",
                stok = 160
            });
            snf.Add(new Sınıf1()
            {
                ürünad = "Mobilya",
                stok = 60
            });
            snf.Add(new Sınıf1()
            {
                ürünad = "Mutfak",
                stok = 250
            });
            return snf;
        }
        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisulizeÜrünResult2()
        {
            return Json(ürünlistesi2(), JsonRequestBehavior.AllowGet);

        }
        public List<Sınıf2> ürünlistesi2()
        {
            List<Sınıf2> snf = new List<Sınıf2>();
            using (var c=new Context())
            {
                snf=c.Ürüns.Select(x=>new Sınıf2
                {
                    ürn=x.ÜrünAd,
                    stk=x.Stok
                }).ToList();
            }
            return snf;
        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();  
        }
    }
}