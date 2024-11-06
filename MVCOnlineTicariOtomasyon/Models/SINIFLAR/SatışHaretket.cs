using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.SINIFLAR
{
    public class SatışHaretket
    {
        [Key]
        public int SatışId { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        public int ÜrünId { get; set; }
        public int CariId { get; set; }
        public int PersonelId { get; set; }

        public virtual Ürün Ürün { get; set; }
        public virtual Cari Cari { get; set; }
        public virtual Personel Personel { get; set; }


    }
}