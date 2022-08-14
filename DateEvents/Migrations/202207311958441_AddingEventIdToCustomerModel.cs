namespace EventsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEventIdToCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "EventId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "EventId");
            AddForeignKey("dbo.Customers", "EventId", "dbo.Events", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "EventId", "dbo.Events");
            DropIndex("dbo.Customers", new[] { "EventId" });
            DropColumn("dbo.Customers", "EventId");
        }
    }
}
