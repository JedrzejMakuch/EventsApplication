namespace EventsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTicketModelVol2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "EventId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "EventId");
        }
    }
}
