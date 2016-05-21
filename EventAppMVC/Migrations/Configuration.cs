namespace EventAppMVC.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EventAppMVC.Models.DAL.EventAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EventAppMVC.Models.DAL.EventAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var venues = new List<Venue>
            {
                new Venue { Name = "Venue 1", Address = "Venue 1 street" },
                new Venue { Name = "Venue 2", Address = "Venue 2 address" }
            };
            venues.ForEach(v => context.Venues.AddOrUpdate(p => p.Name, v));
            context.SaveChanges();

            var events = new List<Event>
            {
                new Event { Name = "Event 1", Date = DateTime.Now, VenueID = 1 },
                new Event { Name = "Event 2", Date = new DateTime(2016, 6, 16), VenueID = 1 },
                new Event { Name = "Event 3", Date = new DateTime(2016, 6, 18), VenueID = 1 },
                new Event { Name = "Event 4", Date = new DateTime(2016, 6, 19), VenueID = 1 },
                new Event { Name = "Event 5", Date = new DateTime(2016, 6, 20), VenueID = 1 },
                new Event { Name = "Event 6", Date = new DateTime(2016, 6, 23), VenueID = 1 },
                new Event { Name = "Event 7", Date = DateTime.Now, VenueID = 1 }

            };

            events.ForEach(e => context.Events.AddOrUpdate(p => p.Name, e));
            context.SaveChanges();

            




        }
    }
}
