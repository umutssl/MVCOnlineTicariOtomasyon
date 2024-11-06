using MVCOnlineTicariOtomasyon.Models.SINIFLAR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class CaripanelController : Controller
    {
        // GET: Caripanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = c.Caris.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.m = mail;
            return View(degerler);
        }
        public ActionResult Siparişlerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Caris.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var degerler=c.SatışHaretkets.Where(x=>x.CariId==id).ToList(); 
            return View(degerler);
        }
    }
}