namespace MountainTourismApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ert1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TouristPlaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SherpaId = c.Int(nullable: false),
                        ImageURL = c.String(),
                        name = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TouristPlaces");
        }
    }
}
