namespace BtsIntegrated.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Location", "History_HistoryId", "dbo.Histories");
            DropIndex("dbo.Location", new[] { "History_HistoryId" });
            CreateTable(
                "dbo.HistoryLocations",
                c => new
                    {
                        History_HistoryId = c.Int(nullable: false),
                        Location_LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.History_HistoryId, t.Location_LocationId })
                .ForeignKey("dbo.Histories", t => t.History_HistoryId, cascadeDelete: true)
                .ForeignKey("dbo.Location", t => t.Location_LocationId, cascadeDelete: true)
                .Index(t => t.History_HistoryId)
                .Index(t => t.Location_LocationId);
            
            DropColumn("dbo.Location", "History_HistoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Location", "History_HistoryId", c => c.Int());
            DropForeignKey("dbo.HistoryLocations", "Location_LocationId", "dbo.Location");
            DropForeignKey("dbo.HistoryLocations", "History_HistoryId", "dbo.Histories");
            DropIndex("dbo.HistoryLocations", new[] { "Location_LocationId" });
            DropIndex("dbo.HistoryLocations", new[] { "History_HistoryId" });
            DropTable("dbo.HistoryLocations");
            CreateIndex("dbo.Location", "History_HistoryId");
            AddForeignKey("dbo.Location", "History_HistoryId", "dbo.Histories", "HistoryId");
        }
    }
}
