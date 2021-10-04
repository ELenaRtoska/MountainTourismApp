namespace MountainTourismApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sherpas", "club", c => c.String());
            AddColumn("dbo.Sherpas", "hikers", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sherpas", "hikers");
            DropColumn("dbo.Sherpas", "club");
        }
    }
}
