namespace MountainTourismApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ert8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FinalReservations", "dateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FinalReservations", "dateTime");
        }
    }
}
