namespace EventsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTicketNumberToCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "TicketNumber", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "TicketNumber");
        }
    }
}
