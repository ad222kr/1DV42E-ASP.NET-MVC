namespace EventAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Event", "Date");
        }
    }
}
