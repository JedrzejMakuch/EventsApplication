namespace EventsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTicketModelWithCustomerAndEventModels : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Tickets", "CustomerId");
            CreateIndex("dbo.Tickets", "EventId");
            AddForeignKey("dbo.Tickets", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", "EventId", "dbo.Events", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "EventId", "dbo.Events");
            DropForeignKey("dbo.Tickets", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Tickets", new[] { "EventId" });
            DropIndex("dbo.Tickets", new[] { "CustomerId" });
        }
    }
}
