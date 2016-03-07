namespace BlogSytemManager.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menu", "Url", c => c.String());
            AddColumn("dbo.MenuChilden", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MenuChilden", "Url");
            DropColumn("dbo.Menu", "Url");
        }
    }
}
