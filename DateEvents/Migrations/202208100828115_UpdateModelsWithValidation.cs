namespace EventsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelsWithValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Description", c => c.String(nullable: false, maxLength: 600));
            AlterColumn("dbo.Events", "DateOfStart", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "DateOfEnd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "Location", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Location", c => c.String());
            AlterColumn("dbo.Events", "DateOfEnd", c => c.DateTime());
            AlterColumn("dbo.Events", "DateOfStart", c => c.DateTime());
            AlterColumn("dbo.Events", "Description", c => c.String());
            AlterColumn("dbo.Events", "Name", c => c.String());
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "LastName", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
        }
    }
}
