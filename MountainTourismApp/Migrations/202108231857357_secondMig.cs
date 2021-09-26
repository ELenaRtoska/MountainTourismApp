namespace MountainTourismApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GPSFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        description = c.String(),
                        distance = c.Single(nullable: false),
                        positiveD = c.Int(nullable: false),
                        negativeD = c.Int(nullable: false),
                        file = c.String(),
                        mountainId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mountains", t => t.mountainId_Id)
                .Index(t => t.mountainId_Id);
            
            CreateTable(
                "dbo.RecommendedEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        hotDesc = c.String(),
                        coldDesc = c.String(),
                        sherpaId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sherpas", t => t.sherpaId_Id)
                .Index(t => t.sherpaId_Id);
            
            CreateTable(
                "dbo.Sherpas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        licence = c.Boolean(nullable: false),
                        description = c.String(),
                        yearsOfExperience = c.Int(nullable: false),
                        GPSFileId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GPSFiles", t => t.GPSFileId_Id)
                .Index(t => t.GPSFileId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecommendedEquipments", "sherpaId_Id", "dbo.Sherpas");
            DropForeignKey("dbo.Sherpas", "GPSFileId_Id", "dbo.GPSFiles");
            DropForeignKey("dbo.GPSFiles", "mountainId_Id", "dbo.Mountains");
            DropIndex("dbo.Sherpas", new[] { "GPSFileId_Id" });
            DropIndex("dbo.RecommendedEquipments", new[] { "sherpaId_Id" });
            DropIndex("dbo.GPSFiles", new[] { "mountainId_Id" });
            DropTable("dbo.Sherpas");
            DropTable("dbo.RecommendedEquipments");
            DropTable("dbo.GPSFiles");
        }
    }
}
