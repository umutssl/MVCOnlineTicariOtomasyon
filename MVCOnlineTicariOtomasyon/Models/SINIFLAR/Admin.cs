﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.SINIFLAR
{
    public class Admin
    {
        [Key]
        public int AdminID {  get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string KullanıcıAd {  get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Şifre {  get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string Yetki {  get; set; } 
    }
}