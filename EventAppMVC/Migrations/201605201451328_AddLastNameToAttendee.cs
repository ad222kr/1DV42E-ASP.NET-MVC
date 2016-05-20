namespace EventAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLastNameToAttendee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendee", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendee", "LastName");
        }
    }
}
