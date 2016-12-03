namespace AllEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionForEventandEventType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "Creator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "EventType_Id", "dbo.EventTypes");
            DropIndex("dbo.Events", new[] { "Creator_Id" });
            DropIndex("dbo.Events", new[] { "EventType_Id" });
            AlterColumn("dbo.Events", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Location", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Events", "Address", c => c.String(maxLength: 255));
            AlterColumn("dbo.Events", "City", c => c.String(maxLength: 30));
            AlterColumn("dbo.Events", "State", c => c.String(maxLength: 3));
            AlterColumn("dbo.Events", "ZipCode", c => c.String(maxLength: 10));
            AlterColumn("dbo.Events", "Creator_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Events", "EventType_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.EventTypes", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Events", "Creator_Id");
            CreateIndex("dbo.Events", "EventType_Id");
            AddForeignKey("dbo.Events", "Creator_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Events", "EventType_Id", "dbo.EventTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "EventType_Id", "dbo.EventTypes");
            DropForeignKey("dbo.Events", "Creator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "EventType_Id" });
            DropIndex("dbo.Events", new[] { "Creator_Id" });
            AlterColumn("dbo.EventTypes", "Name", c => c.String());
            AlterColumn("dbo.Events", "EventType_Id", c => c.Int());
            AlterColumn("dbo.Events", "Creator_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Events", "ZipCode", c => c.String());
            AlterColumn("dbo.Events", "State", c => c.String());
            AlterColumn("dbo.Events", "City", c => c.String());
            AlterColumn("dbo.Events", "Address", c => c.String());
            AlterColumn("dbo.Events", "Location", c => c.String());
            AlterColumn("dbo.Events", "Description", c => c.String());
            CreateIndex("dbo.Events", "EventType_Id");
            CreateIndex("dbo.Events", "Creator_Id");
            AddForeignKey("dbo.Events", "EventType_Id", "dbo.EventTypes", "Id");
            AddForeignKey("dbo.Events", "Creator_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
