namespace Promo.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BrandChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brands", "Published", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Brands", "Published");
        }
    }
}
