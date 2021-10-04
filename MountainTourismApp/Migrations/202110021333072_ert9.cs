namespace MountainTourismApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ert9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FinalReservations", "hikers", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FinalReservations", "hikers");
        }
    }
}
