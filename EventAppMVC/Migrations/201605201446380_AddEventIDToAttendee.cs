namespace EventAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventIDToAttendee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendee", "Event_ID", "dbo.Event");
            DropIndex("dbo.Attendee", new[] { "Event_ID" });
            RenameColumn(table: "dbo.Attendee", name: "Event_ID", newName: "EventID");
            AlterColumn("dbo.Attendee", "EventID", c => c.Int(nullable: false));
            CreateIndex("dbo.Attendee", "EventID");
            AddForeignKey("dbo.Attendee", "EventID", "dbo.Event", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendee", "EventID", "dbo.Event");
            DropIndex("dbo.Attendee", new[] { "EventID" });
            AlterColumn("dbo.Attendee", "EventID", c => c.Int());
            RenameColumn(table: "dbo.Attendee", name: "EventID", newName: "Event_ID");
            CreateIndex("dbo.Attendee", "Event_ID");
            AddForeignKey("dbo.Attendee", "Event_ID", "dbo.Event", "ID");
        }
    }
}
