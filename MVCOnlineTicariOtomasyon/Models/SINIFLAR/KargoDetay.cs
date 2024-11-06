using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.SINIFLAR
{
    public class KargoDetay
    {
        public int KargoDetayID {  get; set; }
        
        public string Açıklama {  get; set; }
        
        public string TakipKodu {  get; set; }
        
        public string Personel {  get; set; }
        
        public string Alıcı {  get; set; }
        public DateTime Tarih {  get; set; }

    }
}