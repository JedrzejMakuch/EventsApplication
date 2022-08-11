namespace EventsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEventModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Name", c => c.String());
        }
    }
}
