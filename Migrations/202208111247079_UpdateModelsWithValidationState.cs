namespace EventsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelsWithValidationState : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Location", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Location", c => c.String());
            AlterColumn("dbo.Events", "Description", c => c.String());
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "LastName", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
        }
    }
}
