namespace AllEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageForEventTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Image");
        }
    }
}
