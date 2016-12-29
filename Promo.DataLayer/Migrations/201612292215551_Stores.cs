namespace Promo.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PromotionStores",
                c => new
                    {
                        PromotionStoreId = c.Int(nullable: false, identity: true),
                        PromotionId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PromotionStoreId)
                .ForeignKey("dbo.Promotions", t => t.PromotionId)
                .ForeignKey("dbo.Stores", t => t.StoreId)
                .Index(t => t.PromotionId)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StoreId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            AddColumn("dbo.Promotions", "Text", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PromotionStores", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Stores", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.PromotionStores", "PromotionId", "dbo.Promotions");
            DropIndex("dbo.Stores", new[] { "CompanyId" });
            DropIndex("dbo.PromotionStores", new[] { "StoreId" });
            DropIndex("dbo.PromotionStores", new[] { "PromotionId" });
            DropColumn("dbo.Promotions", "Text");
            DropTable("dbo.Stores");
            DropTable("dbo.PromotionStores");
        }
    }
}
