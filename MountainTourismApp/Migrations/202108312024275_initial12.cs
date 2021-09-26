namespace MountainTourismApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GPSFiles", "mountainId_Id", "dbo.Mountains");
            DropForeignKey("dbo.Sherpas", "GPSFileId_Id", "dbo.GPSFiles");
            DropIndex("dbo.GPSFiles", new[] { "mountainId_Id" });
            DropIndex("dbo.Sherpas", new[] { "GPSFileId_Id" });
            AddColumn("dbo.GPSFiles", "mountainId", c => c.Int(nullable: false));
            AddColumn("dbo.Sherpas", "GPSFileId", c => c.Int(nullable: false));
            DropColumn("dbo.GPSFiles", "mountainId_Id");
            DropColumn("dbo.Sherpas", "GPSFileId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sherpas", "GPSFileId_Id", c => c.Int());
            AddColumn("dbo.GPSFiles", "mountainId_Id", c => c.Int());
            DropColumn("dbo.Sherpas", "GPSFileId");
            DropColumn("dbo.GPSFiles", "mountainId");
            CreateIndex("dbo.Sherpas", "GPSFileId_Id");
            CreateIndex("dbo.GPSFiles", "mountainId_Id");
            AddForeignKey("dbo.Sherpas", "GPSFileId_Id", "dbo.GPSFiles", "Id");
            AddForeignKey("dbo.GPSFiles", "mountainId_Id", "dbo.Mountains", "Id");
        }
    }
}
