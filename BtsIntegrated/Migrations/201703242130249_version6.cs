namespace BtsIntegrated.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Histories", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.RecommendLocations", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Comment", new[] { "AccountId" });
            DropIndex("dbo.Histories", new[] { "AccountId" });
            DropIndex("dbo.RecommendLocations", new[] { "AccountId" });
            RenameColumn(table: "dbo.Comment", name: "AccountId", newName: "Account_AccountId");
            RenameColumn(table: "dbo.Histories", name: "AccountId", newName: "Account_AccountId");
            RenameColumn(table: "dbo.RecommendLocations", name: "AccountId", newName: "Account_AccountId");
            AddColumn("dbo.Comment", "UserName", c => c.String());
            AddColumn("dbo.Histories", "UserName", c => c.String());
            AddColumn("dbo.Ratings", "UserName", c => c.String());
            AddColumn("dbo.RecommendLocations", "UserName", c => c.String());
            AlterColumn("dbo.Comment", "Account_AccountId", c => c.Int());
            AlterColumn("dbo.Histories", "Account_AccountId", c => c.Int());
            AlterColumn("dbo.RecommendLocations", "Account_AccountId", c => c.Int());
            CreateIndex("dbo.Comment", "Account_AccountId");
            CreateIndex("dbo.Histories", "Account_AccountId");
            CreateIndex("dbo.RecommendLocations", "Account_AccountId");
            AddForeignKey("dbo.Comment", "Account_AccountId", "dbo.Accounts", "AccountId");
            AddForeignKey("dbo.Histories", "Account_AccountId", "dbo.Accounts", "AccountId");
            AddForeignKey("dbo.RecommendLocations", "Account_AccountId", "dbo.Accounts", "AccountId");
            DropColumn("dbo.Ratings", "AccountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "AccountId", c => c.String());
            DropForeignKey("dbo.RecommendLocations", "Account_AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Histories", "Account_AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Comment", "Account_AccountId", "dbo.Accounts");
            DropIndex("dbo.RecommendLocations", new[] { "Account_AccountId" });
            DropIndex("dbo.Histories", new[] { "Account_AccountId" });
            DropIndex("dbo.Comment", new[] { "Account_AccountId" });
            AlterColumn("dbo.RecommendLocations", "Account_AccountId", c => c.Int(nullable: false));
            AlterColumn("dbo.Histories", "Account_AccountId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comment", "Account_AccountId", c => c.Int(nullable: false));
            DropColumn("dbo.RecommendLocations", "UserName");
            DropColumn("dbo.Ratings", "UserName");
            DropColumn("dbo.Histories", "UserName");
            DropColumn("dbo.Comment", "UserName");
            RenameColumn(table: "dbo.RecommendLocations", name: "Account_AccountId", newName: "AccountId");
            RenameColumn(table: "dbo.Histories", name: "Account_AccountId", newName: "AccountId");
            RenameColumn(table: "dbo.Comment", name: "Account_AccountId", newName: "AccountId");
            CreateIndex("dbo.RecommendLocations", "AccountId");
            CreateIndex("dbo.Histories", "AccountId");
            CreateIndex("dbo.Comment", "AccountId");
            AddForeignKey("dbo.RecommendLocations", "AccountId", "dbo.Accounts", "AccountId", cascadeDelete: true);
            AddForeignKey("dbo.Histories", "AccountId", "dbo.Accounts", "AccountId", cascadeDelete: true);
            AddForeignKey("dbo.Comment", "AccountId", "dbo.Accounts", "AccountId", cascadeDelete: true);
        }
    }
}
