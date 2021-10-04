namespace MountainTourismApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ert44 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FinalReservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        userEmail = c.String(),
                        finalSherpa = c.String(),
                        gpsFile = c.String(),
                        mountain = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FinalReservations");
        }
    }
}
