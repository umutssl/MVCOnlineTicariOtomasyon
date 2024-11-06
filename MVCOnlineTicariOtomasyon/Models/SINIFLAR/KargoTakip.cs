using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.SINIFLAR
{
    public class KargoTakip
    {
        
        public int KargoTakipID {  get; set; }
        
        public string TakipKodu {  get; set; }
        
        public string Açıklama{  get; set; }
        public DateTime TarihZaman{  get; set; }

    }
}