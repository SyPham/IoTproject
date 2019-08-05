namespace IoT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCurrentTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DisplayDatas", "CurrentTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DisplayDatas", "CurrentTime");
        }
    }
}
