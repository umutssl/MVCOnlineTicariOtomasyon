using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.SINIFLAR
{
    public class İletişim
    {
        [Key]
        public int MesajID { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Gönderici { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Alıcı { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Konu { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(2220)]
        public string İçerik { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime Tarih { get; set; }
    }
}