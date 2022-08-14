﻿namespace EventsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingNullableFromEventIdInCustomerModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "EventId", "dbo.Events");
            DropIndex("dbo.Customers", new[] { "EventId" });
            AlterColumn("dbo.Customers", "EventId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "EventId");
            AddForeignKey("dbo.Customers", "EventId", "dbo.Events", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "EventId", "dbo.Events");
            DropIndex("dbo.Customers", new[] { "EventId" });
            AlterColumn("dbo.Customers", "EventId", c => c.Int());
            CreateIndex("dbo.Customers", "EventId");
            AddForeignKey("dbo.Customers", "EventId", "dbo.Events", "Id");
        }
    }
}
