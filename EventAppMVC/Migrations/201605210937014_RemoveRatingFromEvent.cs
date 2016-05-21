namespace EventAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRatingFromEvent : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Event", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Event", "Rating", c => c.Int(nullable: false));
        }
    }
}
