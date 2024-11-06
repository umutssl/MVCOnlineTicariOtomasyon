using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.SINIFLAR
{
    public class Personel
    {
        [Key]
        public int PersonelID {  get; set; }

        [Display(Name ="Personel Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string PersonelAd {  get; set; }


        [Display(Name = "Personel Soyadı")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string PersonelSoyAd{  get; set; }


        [Display(Name = "Personel Görsel")]
        [Column(TypeName = "Varchar")]
        [StringLength(350)]
        public string PersonelGörsel{  get; set; }
        public ICollection<SatışHaretket> SatışHaretkets { get; set; }
        public int DepartmanId {  get; set; }
        public virtual Departman Departman { get; set; }    

    }
}