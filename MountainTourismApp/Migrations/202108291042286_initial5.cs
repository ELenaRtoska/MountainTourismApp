namespace MountainTourismApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GPSFiles", "title", c => c.String());
            AddColumn("dbo.GPSFiles", "filePath", c => c.String());
            DropColumn("dbo.GPSFiles", "file");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GPSFiles", "file", c => c.String());
            DropColumn("dbo.GPSFiles", "filePath");
            DropColumn("dbo.GPSFiles", "title");
        }
    }
}
