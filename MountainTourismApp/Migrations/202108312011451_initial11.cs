namespace MountainTourismApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sherpas", "ImageURL", c => c.String());
            AddColumn("dbo.Sherpas", "name", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sherpas", "name");
            DropColumn("dbo.Sherpas", "ImageURL");
        }
    }
}
