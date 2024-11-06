using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.SINIFLAR
{
    public class Ürün
    {
        [Key]
        public int ÜrünID { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(50)]
        public string ÜrünAd {  get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Marka {  get; set; }
        public short Stok {  get; set; }
        public decimal AlışFiyat {  get; set; }
        public decimal SatışFiyat {  get; set; }
        public bool Durum {  get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(350)]
        public string ÜrünGörsel {  get; set; }
        public int KategorID {  get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<SatışHaretket> SatışHaretkets { get; set; }


    }
}