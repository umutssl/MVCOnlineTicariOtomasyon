using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.SINIFLAR
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemID {  get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(150)]
        public string Açıklama {  get; set; }
        public string Miktar {  get; set; }
        public decimal BirimFiyat {  get; set; }
        public decimal Tutar {  get; set; }
        public int FaturaaID{  get; set; }
        public virtual Faturalar Faturalar { get; set; }    

    }
}