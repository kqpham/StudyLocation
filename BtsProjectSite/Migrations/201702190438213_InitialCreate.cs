namespace BtsProjectSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LocationBases",
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
                        TimingMondayOpeningTime = c.DateTime(),
                        TimingMondayClosingTime = c.DateTime(),
                        TimingTuesdayOpeningTime = c.DateTime(),
                        TimingTuesdayClosingTime = c.DateTime(),
                        TimingWednesdayOpeningTime = c.DateTime(),
                        TimingWednesdayClosingTime = c.DateTime(),
                        TimingThursdayOpeningTime = c.DateTime(),
                        TimingThursdayClosingTime = c.DateTime(),
                        TimingFridayOpeningTime = c.DateTime(),
                        TimingFridayClosingTime = c.DateTime(),
                        TimingSaturdayOpeningTime = c.DateTime(),
                        TimingSaturdayClosingTime = c.DateTime(),
                        TimingSundayOpeningTime = c.DateTime(),
                        TimingSundayClosingTime = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LocationBases");
        }
    }
}
