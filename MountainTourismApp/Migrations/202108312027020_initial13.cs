namespace MountainTourismApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sherpas", "name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sherpas", "name", c => c.Boolean(nullable: false));
        }
    }
}
