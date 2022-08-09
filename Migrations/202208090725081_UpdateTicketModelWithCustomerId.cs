namespace EventsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTicketModelWithCustomerId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "CustomerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "CustomerId");
        }
    }
}
