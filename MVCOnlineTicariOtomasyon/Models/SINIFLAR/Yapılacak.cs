using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.SINIFLAR
{
    public class Yapılacak
    {
        [Key]
        public int YapılacakID { get; set; }
        
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Başlık { get; set; }
       
        [Column(TypeName = "Bit")]
        
        public bool Durum { get; set; }
       
    }
}