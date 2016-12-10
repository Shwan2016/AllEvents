namespace AllEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDataAnnotationToDescription : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Description", c => c.String(nullable: false, maxLength: 60));
        }
    }
}
