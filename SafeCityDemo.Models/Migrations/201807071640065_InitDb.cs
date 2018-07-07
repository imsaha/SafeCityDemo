namespace SafeCityDemo.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblIncidents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        CallerNumber = c.String(),
                        CallerName = c.String(),
                        Date = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCategories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.tblLocations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.tblLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblIncidents", "LocationId", "dbo.tblLocations");
            DropForeignKey("dbo.tblIncidents", "CategoryId", "dbo.tblCategories");
            DropIndex("dbo.tblIncidents", new[] { "LocationId" });
            DropIndex("dbo.tblIncidents", new[] { "CategoryId" });
            DropTable("dbo.tblLocations");
            DropTable("dbo.tblIncidents");
            DropTable("dbo.tblCategories");
        }
    }
}
