namespace Promo.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Url = c.String(),
                        BrandId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Brands", t => t.BrandId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.BrandId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        PromotionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PromotionId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CompanyId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.PromotionBrands",
                c => new
                    {
                        PromotionBrandId = c.Int(nullable: false, identity: true),
                        PromotionId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PromotionBrandId)
                .ForeignKey("dbo.Brands", t => t.BrandId)
                .ForeignKey("dbo.Promotions", t => t.PromotionId)
                .Index(t => t.PromotionId)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.PromotionProducts",
                c => new
                    {
                        PromotionProductId = c.Int(nullable: false, identity: true),
                        PromotionId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PromotionProductId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Promotions", t => t.PromotionId)
                .Index(t => t.PromotionId)
                .Index(t => t.ProductId);
            
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PromotionProducts", "PromotionId", "dbo.Promotions");
            DropForeignKey("dbo.PromotionProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PromotionBrands", "PromotionId", "dbo.Promotions");
            DropForeignKey("dbo.PromotionBrands", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Promotions", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Promotions", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Products", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropIndex("dbo.PromotionProducts", new[] { "ProductId" });
            DropIndex("dbo.PromotionProducts", new[] { "PromotionId" });
            DropIndex("dbo.PromotionBrands", new[] { "BrandId" });
            DropIndex("dbo.PromotionBrands", new[] { "PromotionId" });
            DropIndex("dbo.Promotions", new[] { "CountryId" });
            DropIndex("dbo.Promotions", new[] { "CompanyId" });
            DropIndex("dbo.Products", new[] { "CountryId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropTable("dbo.PromotionProducts");
            DropTable("dbo.PromotionBrands");
            DropTable("dbo.Promotions");
            DropTable("dbo.Products");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
    }
}
