namespace BtsProjectSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Location1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Timing",
                c => new
                    {
                        TimingId = c.Int(nullable: false),
                        MondayOpeningTime = c.DateTime(),
                        MondayClosingTime = c.DateTime(),
                        TuesdayOpeningTime = c.DateTime(),
                        TuesdayClosingTime = c.DateTime(),
                        WednesdayOpeningTime = c.DateTime(),
                        WednesdayClosingTime = c.DateTime(),
                        ThursdayOpeningTime = c.DateTime(),
                        ThursdayClosingTime = c.DateTime(),
                        FridayOpeningTime = c.DateTime(),
                        FridayClosingTime = c.DateTime(),
                        SaturdayOpeningTime = c.DateTime(),
                        SaturdayClosingTime = c.DateTime(),
                        SundayOpeningTime = c.DateTime(),
                        SundayClosingTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.TimingId)
                .ForeignKey("dbo.Location", t => t.TimingId)
                .Index(t => t.TimingId);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        PostalCode = c.String(),
                        PhoneNumber = c.String(),
                        City = c.String(),
                        WifiAvailability = c.Boolean(nullable: false),
                        Outlet = c.Boolean(nullable: false),
                        StudyRoom = c.Boolean(nullable: false),
                        Printers = c.Boolean(nullable: false),
                        Purchase = c.Boolean(nullable: false),
                        Description = c.String(),
                        Food = c.Boolean(nullable: false),
                        Washrooms = c.Boolean(nullable: false),
                        HandicapAccess = c.Boolean(nullable: false),
                        AcceptDebit = c.Boolean(nullable: false),
                        AcceptCredit = c.Boolean(nullable: false),
                        CashOnly = c.Boolean(nullable: false),
                        Website = c.String(),
                        TimingId = c.Int(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        History_HistoryId = c.Int(),
                    })
                .PrimaryKey(t => t.LocationId)
                .ForeignKey("dbo.Histories", t => t.History_HistoryId)
                .Index(t => t.History_HistoryId);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        LocationId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        Comments = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.AccountDetails", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Location", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.AccountDetails",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        ClaimsFirstName = c.String(),
                        ClaimsLastName = c.String(),
                        ClaimsEmail = c.String(),
                        ClaimsRoles = c.String(),
                    })
                .PrimaryKey(t => t.AccountId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        LocationId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RatingId)
                .ForeignKey("dbo.AccountDetails", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Location", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.RecommendLocations",
                c => new
                    {
                        RecommendLocationId = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        PostalCode = c.String(),
                        PhoneNumber = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.RecommendLocationId)
                .ForeignKey("dbo.AccountDetails", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        HistoryId = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HistoryId)
                .ForeignKey("dbo.AccountDetails", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            AddColumn("dbo.LocationBases", "Timings_TimingId", c => c.Int());
            CreateIndex("dbo.LocationBases", "Timings_TimingId");
            AddForeignKey("dbo.LocationBases", "Timings_TimingId", "dbo.Timing", "TimingId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LocationBases", "Timings_TimingId", "dbo.Timing");
            DropForeignKey("dbo.Timing", "TimingId", "dbo.Location");
            DropForeignKey("dbo.Comment", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Location", "History_HistoryId", "dbo.Histories");
            DropForeignKey("dbo.Histories", "AccountId", "dbo.AccountDetails");
            DropForeignKey("dbo.RecommendLocations", "AccountId", "dbo.AccountDetails");
            DropForeignKey("dbo.Ratings", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Ratings", "AccountId", "dbo.AccountDetails");
            DropForeignKey("dbo.Comment", "AccountId", "dbo.AccountDetails");
            DropIndex("dbo.Histories", new[] { "AccountId" });
            DropIndex("dbo.RecommendLocations", new[] { "AccountId" });
            DropIndex("dbo.Ratings", new[] { "AccountId" });
            DropIndex("dbo.Ratings", new[] { "LocationId" });
            DropIndex("dbo.Comment", new[] { "AccountId" });
            DropIndex("dbo.Comment", new[] { "LocationId" });
            DropIndex("dbo.Location", new[] { "History_HistoryId" });
            DropIndex("dbo.Timing", new[] { "TimingId" });
            DropIndex("dbo.LocationBases", new[] { "Timings_TimingId" });
            DropColumn("dbo.LocationBases", "Timings_TimingId");
            DropTable("dbo.Histories");
            DropTable("dbo.RecommendLocations");
            DropTable("dbo.Ratings");
            DropTable("dbo.AccountDetails");
            DropTable("dbo.Comment");
            DropTable("dbo.Location");
            DropTable("dbo.Timing");
        }
    }
}
