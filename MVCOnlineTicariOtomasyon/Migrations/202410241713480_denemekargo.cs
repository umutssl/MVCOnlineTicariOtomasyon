namespace MVCOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class denemekargo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KargoDetays",
                c => new
                    {
                        KargoDetayID = c.Int(nullable: false, identity: true),
                        Açıklama = c.String(),
                        TakipKodu = c.String(),
                        Personel = c.String(),
                        Alıcı = c.String(),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KargoDetayID);
            
            CreateTable(
                "dbo.KargoTakips",
                c => new
                    {
                        KargoTakipID = c.Int(nullable: false, identity: true),
                        TakipKodu = c.String(),
                        Açıklama = c.String(),
                        TarihZaman = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KargoTakipID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KargoTakips");
            DropTable("dbo.KargoDetays");
        }
    }
}
