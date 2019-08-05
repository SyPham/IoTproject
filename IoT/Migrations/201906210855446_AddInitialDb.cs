namespace IoT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInitialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        Office = c.String(maxLength: 50),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountID)
                .ForeignKey("dbo.Category", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CaregoryID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CaregoryID);
            
            CreateTable(
                "dbo.Arduino",
                c => new
                    {
                        ArduinoID = c.Int(nullable: false, identity: true),
                        ADIndex = c.Int(),
                        DataTime = c.DateTime(),
                        Seq = c.Int(),
                    })
                .PrimaryKey(t => t.ArduinoID);
            
            CreateTable(
                "dbo.CycleTime",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ArduinoID = c.String(),
                        RealTimeCycleTime = c.Double(),
                        TimeRevCycleTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DisplayDatas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ArduinoID = c.String(),
                        TotalTime = c.Double(nullable: false),
                        Count = c.Double(nullable: false),
                        RealTime = c.Double(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MaxCycleTime",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Station = c.String(maxLength: 10, unicode: false),
                        Value = c.Double(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleTitle = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(maxLength: 50),
                        Office = c.String(maxLength: 10),
                        UserCode = c.String(),
                        PasswordHash = c.Binary(),
                        PasswordSalt = c.Binary(),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Account", "CategoryID", "dbo.Category");
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.Account", new[] { "CategoryID" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.MaxCycleTime");
            DropTable("dbo.DisplayDatas");
            DropTable("dbo.CycleTime");
            DropTable("dbo.Arduino");
            DropTable("dbo.Category");
            DropTable("dbo.Account");
        }
    }
}
