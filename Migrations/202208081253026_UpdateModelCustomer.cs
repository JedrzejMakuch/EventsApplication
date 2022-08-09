namespace EventsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelCustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "TicketId_Id", "dbo.Tickets");
            DropForeignKey("dbo.Customers", "Ticket_Id", "dbo.Tickets");
            DropIndex("dbo.Customers", new[] { "Ticket_Id" });
            DropIndex("dbo.Customers", new[] { "TicketId_Id" });
            RenameColumn(table: "dbo.Customers", name: "Ticket_Id", newName: "TicketId");
            AlterColumn("dbo.Customers", "TicketId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "TicketId");
            AddForeignKey("dbo.Customers", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "TicketId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "TicketId_Id", c => c.Int());
            DropForeignKey("dbo.Customers", "TicketId", "dbo.Tickets");
            DropIndex("dbo.Customers", new[] { "TicketId" });
            AlterColumn("dbo.Customers", "TicketId", c => c.Int());
            RenameColumn(table: "dbo.Customers", name: "TicketId", newName: "Ticket_Id");
            CreateIndex("dbo.Customers", "TicketId_Id");
            CreateIndex("dbo.Customers", "Ticket_Id");
            AddForeignKey("dbo.Customers", "Ticket_Id", "dbo.Tickets", "Id");
            AddForeignKey("dbo.Customers", "TicketId_Id", "dbo.Tickets", "Id");
        }
    }
}
