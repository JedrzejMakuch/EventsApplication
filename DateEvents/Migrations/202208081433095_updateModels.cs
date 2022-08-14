namespace EventsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Events", "TicketId", "dbo.Tickets");
            DropIndex("dbo.Customers", new[] { "TicketId" });
            DropIndex("dbo.Events", new[] { "TicketId" });
            AddColumn("dbo.Tickets", "Customer_Id", c => c.Int());
            AddColumn("dbo.Tickets", "Event_Id", c => c.Int());
            CreateIndex("dbo.Tickets", "Customer_Id");
            CreateIndex("dbo.Tickets", "Event_Id");
            AddForeignKey("dbo.Tickets", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.Tickets", "Event_Id", "dbo.Events", "Id");
            DropColumn("dbo.Customers", "TicketId");
            DropColumn("dbo.Events", "TicketId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "TicketId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "TicketId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Tickets", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Tickets", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Tickets", new[] { "Event_Id" });
            DropIndex("dbo.Tickets", new[] { "Customer_Id" });
            DropColumn("dbo.Tickets", "Event_Id");
            DropColumn("dbo.Tickets", "Customer_Id");
            CreateIndex("dbo.Events", "TicketId");
            CreateIndex("dbo.Customers", "TicketId");
            AddForeignKey("dbo.Events", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
        }
    }
}
