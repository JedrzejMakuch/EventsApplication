namespace EventsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEventPropertiesToCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "EventId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Customers", "EventId");
            AddForeignKey("dbo.Customers", "EventId", "dbo.Events", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "EventId", "dbo.Events");
            DropIndex("dbo.Customers", new[] { "EventId" });
            AlterColumn("dbo.Events", "Name", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
            DropColumn("dbo.Customers", "EventId");
        }
    }
}
