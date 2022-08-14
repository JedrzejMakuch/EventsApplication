namespace EventsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTicketModelWithCustomerAndEventModelsVol2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Tickets", "EventId", "dbo.Events");
            DropIndex("dbo.Tickets", new[] { "CustomerId" });
            DropIndex("dbo.Tickets", new[] { "EventId" });
            RenameColumn(table: "dbo.Tickets", name: "CustomerId", newName: "Customer_Id");
            RenameColumn(table: "dbo.Tickets", name: "EventId", newName: "Event_Id");
            AlterColumn("dbo.Tickets", "Customer_Id", c => c.Int());
            AlterColumn("dbo.Tickets", "Event_Id", c => c.Int());
            CreateIndex("dbo.Tickets", "Customer_Id");
            CreateIndex("dbo.Tickets", "Event_Id");
            AddForeignKey("dbo.Tickets", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.Tickets", "Event_Id", "dbo.Events", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Tickets", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Tickets", new[] { "Event_Id" });
            DropIndex("dbo.Tickets", new[] { "Customer_Id" });
            AlterColumn("dbo.Tickets", "Event_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Tickets", "Customer_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Tickets", name: "Event_Id", newName: "EventId");
            RenameColumn(table: "dbo.Tickets", name: "Customer_Id", newName: "CustomerId");
            CreateIndex("dbo.Tickets", "EventId");
            CreateIndex("dbo.Tickets", "CustomerId");
            AddForeignKey("dbo.Tickets", "EventId", "dbo.Events", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
