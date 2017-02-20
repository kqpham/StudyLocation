namespace BtsProjectSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Location : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LocationBases", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LocationBases", "Name");
        }
    }
}
