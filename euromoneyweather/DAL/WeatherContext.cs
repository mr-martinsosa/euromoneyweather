using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using euromoneyweather.Models;

namespace euromoneyweather.DAL
{
    public class WeatherContext : DbContext
    {

        public WeatherContext() : base("WeatherContext") /*use entity framework*/
        {

        }

        public DbSet<Country> Countries { get; set; } //set up entity, context to db, dbset is entity frameworks way to make an object that reflects a table
        public DbSet<Weather> Temperatures { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //prevent naming tables in plural
        }

    }
}
