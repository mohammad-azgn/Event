namespace Event.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "StartDate");
            DropColumn("dbo.Events", "FinishDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "FinishDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
