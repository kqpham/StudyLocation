namespace BtsIntegrated.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Location", "TimingId");
            DropColumn("dbo.Timing", "LocationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Timing", "LocationId", c => c.Int(nullable: false));
            AddColumn("dbo.Location", "TimingId", c => c.Int(nullable: false));
        }
    }
}
