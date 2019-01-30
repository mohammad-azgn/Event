namespace Event.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addd : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "Category_Id", newName: "CategoryId");
            RenameIndex(table: "dbo.Events", name: "IX_Category_Id", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Events", name: "IX_CategoryId", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.Events", name: "CategoryId", newName: "Category_Id");
        }
    }
}
