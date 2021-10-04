namespace MountainTourismApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ert7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sherpas", "dateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sherpas", "dateTime");
        }
    }
}
