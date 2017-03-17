namespace BtsIntegrated.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Timing", "LocationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Timing", "LocationId", c => c.Int(nullable: false));
        }
    }
}
