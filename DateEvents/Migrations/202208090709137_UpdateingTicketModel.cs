namespace EventsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateingTicketModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Tickets", "Event_Id", "dbo.Events");
            DropIndex("dbo.Tickets", new[] { "Customer_Id" });
            DropIndex("dbo.Tickets", new[] { "Event_Id" });
            DropColumn("dbo.Tickets", "Customer_Id");
            DropColumn("dbo.Tickets", "Event_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "Event_Id", c => c.Int());
            AddColumn("dbo.Tickets", "Customer_Id", c => c.Int());
            CreateIndex("dbo.Tickets", "Event_Id");
            CreateIndex("dbo.Tickets", "Customer_Id");
            AddForeignKey("dbo.Tickets", "Event_Id", "dbo.Events", "Id");
            AddForeignKey("dbo.Tickets", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
