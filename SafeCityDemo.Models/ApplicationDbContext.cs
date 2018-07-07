using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeCityDemo.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext():base("DefaultConnection")
        {
            Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }


        #region Dbsets


        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }

        #endregion


    }
}
