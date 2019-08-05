namespace IoT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMinRealTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DisplayDatas", "MinRealTime", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DisplayDatas", "MinRealTime");
        }
    }
}
