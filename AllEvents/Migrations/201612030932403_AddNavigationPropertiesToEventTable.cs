namespace AllEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNavigationPropertiesToEventTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "Creator_Id", newName: "CreatorId");
            RenameColumn(table: "dbo.Events", name: "EventType_Id", newName: "EventTypeId");
            RenameIndex(table: "dbo.Events", name: "IX_Creator_Id", newName: "IX_CreatorId");
            RenameIndex(table: "dbo.Events", name: "IX_EventType_Id", newName: "IX_EventTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Events", name: "IX_EventTypeId", newName: "IX_EventType_Id");
            RenameIndex(table: "dbo.Events", name: "IX_CreatorId", newName: "IX_Creator_Id");
            RenameColumn(table: "dbo.Events", name: "EventTypeId", newName: "EventType_Id");
            RenameColumn(table: "dbo.Events", name: "CreatorId", newName: "Creator_Id");
        }
    }
}
