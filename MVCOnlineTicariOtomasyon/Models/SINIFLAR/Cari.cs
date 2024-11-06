using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.SINIFLAR
{
    public class Cari
    {
        [Key]
        public int CariID {  get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage = "En Fazla 30 Karakter Yazabilisizniz")]
        public string CariAd {  get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En Fazla 30 Karakter Yazabilisizniz")]
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz")]
        public string CariSoyAd {  get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20,ErrorMessage = "En Fazla 20 Karakter Yazabilisizniz")]
        public string CariŞehir {  get; set; }
       
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariMail {  get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CariŞifre { get; set; }
        public bool Durum {  get; set; }
        public ICollection<SatışHaretket> SatışHaretkets { get; set; }

    }
}