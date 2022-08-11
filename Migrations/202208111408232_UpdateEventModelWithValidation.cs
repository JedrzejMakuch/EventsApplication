namespace EventsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEventModelWithValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Name", c => c.String());
            AlterColumn("dbo.Events", "Description", c => c.String());
            AlterColumn("dbo.Events", "Location", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Name", c => c.String(nullable: false));
        }
    }
}
