namespace AllEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotationToDescription : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Description", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Description", c => c.String(nullable: false));
        }
    }
}
