namespace EventsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelsWithTicketsId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "EventId", "dbo.Events");
            DropIndex("dbo.Customers", new[] { "EventId" });
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "Ticket_Id", c => c.Int());
            AddColumn("dbo.Customers", "TicketId_Id", c => c.Int());
            AddColumn("dbo.Events", "TicketById", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "Ticket_Id");
            CreateIndex("dbo.Customers", "TicketId_Id");
            CreateIndex("dbo.Events", "TicketById");
            AddForeignKey("dbo.Customers", "Ticket_Id", "dbo.Tickets", "Id");
            AddForeignKey("dbo.Customers", "TicketId_Id", "dbo.Tickets", "Id");
            AddForeignKey("dbo.Events", "TicketById", "dbo.Tickets", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "EventId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "EventId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Events", "TicketById", "dbo.Tickets");
            DropForeignKey("dbo.Customers", "TicketId_Id", "dbo.Tickets");
            DropForeignKey("dbo.Customers", "Ticket_Id", "dbo.Tickets");
            DropIndex("dbo.Events", new[] { "TicketById" });
            DropIndex("dbo.Customers", new[] { "TicketId_Id" });
            DropIndex("dbo.Customers", new[] { "Ticket_Id" });
            DropColumn("dbo.Events", "TicketById");
            DropColumn("dbo.Customers", "TicketId_Id");
            DropColumn("dbo.Customers", "Ticket_Id");
            DropTable("dbo.Tickets");
            CreateIndex("dbo.Customers", "EventId");
            AddForeignKey("dbo.Customers", "EventId", "dbo.Events", "Id", cascadeDelete: true);
        }
    }
}
