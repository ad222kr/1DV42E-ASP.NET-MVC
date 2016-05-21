namespace EventAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRatingToEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "Rating", c => c.Int(nullable: false, defaultValue: 3));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Event", "Rating");
        }
    }
}
