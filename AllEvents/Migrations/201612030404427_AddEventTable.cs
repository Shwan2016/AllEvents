namespace AllEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Location = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        Creator_Id = c.String(maxLength: 128),
                        EventType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Creator_Id)
                .ForeignKey("dbo.EventTypes", t => t.EventType_Id)
                .Index(t => t.Creator_Id)
                .Index(t => t.EventType_Id);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "EventType_Id", "dbo.EventTypes");
            DropForeignKey("dbo.Events", "Creator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "EventType_Id" });
            DropIndex("dbo.Events", new[] { "Creator_Id" });
            DropTable("dbo.EventTypes");
            DropTable("dbo.Events");
        }
    }
}
