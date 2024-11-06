﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.SINIFLAR;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c=new Context();
        public ActionResult Index()
        {
            var degerler=c.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {

            List<SelectListItem> deger1 = (from x in c.Departmen.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAD,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string doysaadi=Path.GetFileName(Request.Files[0].FileName);
                string uzanti=Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + doysaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGörsel="/Image/" + doysaadi + uzanti; 
            }
            c.Personels.Add(p);
            c.SaveChanges();
            return View("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmen.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAD,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var prs = c.Personels.Find(id);
            return View("PersonelGetir",prs);
        }
        public ActionResult PersonelGüncelle(Personel p)
        {
            var prsn = c.Personels.Find(p.PersonelID);
            prsn.PersonelAd=p.PersonelAd;
            prsn.PersonelSoyAd=p.PersonelSoyAd;
            prsn.PersonelGörsel = p.PersonelGörsel;
            prsn.DepartmanId=prsn.PersonelID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelListe()
        {
            var deger = c.Personels.ToList();
            return View(deger);
        }
    }
}