namespace BlogSytemManager.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserInfo", "Permission_ID", "dbo.Permission");
            DropForeignKey("dbo.Role", "Permission_ID", "dbo.Permission");
            DropIndex("dbo.UserInfo", new[] { "Permission_ID" });
            DropIndex("dbo.Role", new[] { "Permission_ID" });
            DropColumn("dbo.UserInfo", "Permission_ID");
            DropColumn("dbo.Role", "Permission_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Role", "Permission_ID", c => c.Int());
            AddColumn("dbo.UserInfo", "Permission_ID", c => c.Int());
            CreateIndex("dbo.Role", "Permission_ID");
            CreateIndex("dbo.UserInfo", "Permission_ID");
            AddForeignKey("dbo.Role", "Permission_ID", "dbo.Permission", "ID");
            AddForeignKey("dbo.UserInfo", "Permission_ID", "dbo.Permission", "ID");
        }
    }
}
