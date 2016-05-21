using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EventAppMVC.Models.DAL
{
    public class EventAppContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Venue> Venues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Database.SetInitializer<EventAppContext>(new DropCreateDatabaseAlways<EventAppContext>());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}