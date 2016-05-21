namespace EventAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVenue : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Venue",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Event", "VenueID", c => c.Int(nullable: false));
            AddForeignKey("dbo.Event", "VenueID", "dbo.Venue", "ID", cascadeDelete: true);
            CreateIndex("dbo.Event", "VenueID");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "VenueID", "dbo.Venue");
            DropIndex("dbo.Event", new[] { "VenueID" });
            DropColumn("dbo.Event", "VenueID");
            DropTable("dbo.Venue");
        }
    }
}
