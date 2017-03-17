namespace BtsIntegrated.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Location", "TimingId", c => c.Int(nullable: false));
            AddColumn("dbo.Timing", "LocationId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Timing", "LocationId");
            DropColumn("dbo.Location", "TimingId");
        }
    }
}
