namespace EventsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "TicketById", "dbo.Tickets");
            DropForeignKey("dbo.Events", "TicketById", "dbo.Tickets");
            DropIndex("dbo.Customers", new[] { "TicketById" });
            DropIndex("dbo.Events", new[] { "TicketById" });
            AddColumn("dbo.Tickets", "Customer_Id", c => c.Int());
            AddColumn("dbo.Tickets", "Event_Id", c => c.Int());
            CreateIndex("dbo.Tickets", "Customer_Id");
            CreateIndex("dbo.Tickets", "Event_Id");
            AddForeignKey("dbo.Tickets", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.Tickets", "Event_Id", "dbo.Events", "Id");
            DropColumn("dbo.Customers", "TicketById");
            DropColumn("dbo.Events", "TicketById");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "TicketById", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "TicketById", c => c.Int(nullable: false));
            DropForeignKey("dbo.Tickets", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Tickets", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Tickets", new[] { "Event_Id" });
            DropIndex("dbo.Tickets", new[] { "Customer_Id" });
            DropColumn("dbo.Tickets", "Event_Id");
            DropColumn("dbo.Tickets", "Customer_Id");
            CreateIndex("dbo.Events", "TicketById");
            CreateIndex("dbo.Customers", "TicketById");
            AddForeignKey("dbo.Events", "TicketById", "dbo.Tickets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "TicketById", "dbo.Tickets", "Id", cascadeDelete: true);
        }
    }
}
