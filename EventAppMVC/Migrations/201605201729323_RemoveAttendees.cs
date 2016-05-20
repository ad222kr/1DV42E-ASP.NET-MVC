namespace EventAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAttendees : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendee", "EventID", "dbo.Event");
            DropIndex("dbo.Attendee", new[] { "EventID" });
            DropTable("dbo.Attendee");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Attendee",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EventID = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Attendee", "EventID");
            AddForeignKey("dbo.Attendee", "EventID", "dbo.Event", "ID", cascadeDelete: true);
        }
    }
}
