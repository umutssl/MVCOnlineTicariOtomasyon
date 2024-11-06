using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.SINIFLAR;
namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var liste=c.Faturalars.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar ftr)
        {
           c.Faturalars.Add(ftr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir",fatura);    
        }
        public ActionResult FaturaGüncelle(Faturalar ftr)
        {
            var fatura=c.Faturalars.Find(ftr.FaturaID);
            fatura.FaturaSeriNo = ftr.FaturaSeriNo;
            fatura.FaturaSıraNo = ftr.FaturaSıraNo;
            fatura.Saat=ftr.Saat;
            fatura.Tarih=ftr.Tarih;
            fatura.TeslimAlan=ftr.TeslimAlan;
            fatura.TeslimEden=ftr.TeslimEden;
            fatura.VergiDairesi=ftr.VergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler=c.FaturaKalems.Where(x=>x.FaturaaID==id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem fk)
        {
            c.FaturaKalems.Add(fk);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}