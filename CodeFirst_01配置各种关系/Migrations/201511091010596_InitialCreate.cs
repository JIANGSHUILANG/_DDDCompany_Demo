namespace CodeFirst_01配置各种关系.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Address", t => t.ID);
            
            CreateTable(
                "dbo.OtherInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Cell = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserInfo", t => t.ID);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserInfo_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserInfo", t => t.UserInfo_ID, cascadeDelete: true);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Product_Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Order_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Order", t => t.Order_ID, cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "Order_ID", "dbo.Order");
            DropForeignKey("dbo.Order", "UserInfo_ID", "dbo.UserInfo");
            DropForeignKey("dbo.OtherInfo", "ID", "dbo.UserInfo");
            DropForeignKey("dbo.UserInfo", "ID", "dbo.Address");
            DropTable("dbo.Product");
            DropTable("dbo.Order");
            DropTable("dbo.Address");
            DropTable("dbo.OtherInfo");
            DropTable("dbo.UserInfo");
        }
    }
}
