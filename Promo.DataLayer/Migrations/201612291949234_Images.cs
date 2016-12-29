namespace Promo.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Images : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brands", "Image", c => c.Binary());
            AddColumn("dbo.Products", "Image", c => c.Binary());
            AddColumn("dbo.Promotions", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Promotions", "Image");
            DropColumn("dbo.Products", "Image");
            DropColumn("dbo.Brands", "Image");
        }
    }
}
