using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace MVCOnlineTicariOtomasyon.Models.SINIFLAR
{
    public class Context:DbContext
    {
        internal object kargodetay;

        public DbSet<Admin> Admins {  get; set; }
        public DbSet<Cari> Caris {  get; set; }
        public DbSet<Departman> Departmen {  get; set; }
        public DbSet<FaturaKalem> FaturaKalems {  get; set; }
        public DbSet<Faturalar> Faturalars {  get; set; }
        public DbSet<Giderler> Giderlers {  get; set; }
        public DbSet<Kategori> Kategoris {  get; set; }
        public DbSet<Personel> Personels {  get; set; }
        public DbSet<SatışHaretket>SatışHaretkets { get; set; }
        public DbSet<Ürün>Ürüns { get; set; }
        public DbSet<Yapılacak> Yapılacaks { get; set; }
        public DbSet<KargoDetay> KargoDetays { get;set; }
        public DbSet<KargoTakip>KargoTakips { get;set; }
        public DbSet<İletişim>İletişims { get;set; }
        
      
    }
}