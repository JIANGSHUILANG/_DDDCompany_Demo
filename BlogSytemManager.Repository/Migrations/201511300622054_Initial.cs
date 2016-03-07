namespace BlogSytemManager.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserInfo", "UserPass", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserInfo", "UserPass", c => c.String());
        }
    }
}
