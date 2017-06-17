namespace Promo.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Coupon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Promotions", "Coupon", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Promotions", "Coupon");
        }
    }
}
