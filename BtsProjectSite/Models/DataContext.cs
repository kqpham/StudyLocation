using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BtsProjectSite.Controllers;

namespace BtsProjectSite.Models
{
    public class DataContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public DataContext() : base("name=DataContext")
        {
        }
        //public virtual DbSet<Location> Locations { get; set; }
        public DbSet<LocationBase> LocationsBase { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public System.Data.Entity.DbSet<BtsProjectSite.Controllers.LocationWithTimings> LocationWithTimings { get; set; }

        //public System.Data.Entity.DbSet<BtsProjectSite.Controllers.LocationBase> Locations { get; set; }
    }
}
