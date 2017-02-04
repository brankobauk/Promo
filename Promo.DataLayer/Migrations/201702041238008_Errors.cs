namespace Promo.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Errors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        ErrorId = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Type = c.String(),
                        StackTrace = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        UserId = c.Int(),
                        SiteId = c.Int(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.ErrorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Errors");
        }
    }
}
