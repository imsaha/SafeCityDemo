using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SafeCityDemo.Models;

namespace SafeCityDemo
{
    public class SafeCityDemoServiceController : ISafeCityDemoServiceContract
    {

        public SafeCityDemoServiceController()
        {
            
        }

        ApplicationDbContext con;
        public ICollection<Incident> GetAllIncidents()
        {
            using (con = new ApplicationDbContext())
            {
                return con.Incidents?.ToList();
            }
        }

        public ICollection<Category> GetCategories()
        {
            using (con = new ApplicationDbContext())
            {
                return con.Categories?.ToList();
            }
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public ICollection<Incident> GetIncidentByCallerNumber(string CallerNumber)
        {
            using (con = new ApplicationDbContext())
            {
                return con.Incidents.Where(x=>x.CallerNumber==CallerNumber).ToList();
            }
        }

        public Incident GetIncidentByNumber(string Number)
        {
            using (con = new ApplicationDbContext())
            {
                return con.Incidents.FirstOrDefault(x => x.Number== Number);
            }
        }

        public ICollection<Location> GetLocations()
        {
            using (con = new ApplicationDbContext())
            {
                return con.Locations?.ToList();
            }
        }
        
        public int AddIncident(Incident incident)
        {
            using (con = new ApplicationDbContext())
            {
                var find = con.Incidents.FirstOrDefault(x => x.Number == incident.Number);
                if (find != null)
                    throw new InvalidOperationException("Duplicate incident");

                con.Incidents.Add(incident);
                return con.SaveChanges();
            }
        }

        public int UpdateIncident(string number, Incident UpdatedIncident)
        {
            using (con = new ApplicationDbContext())
            {
                var find = con.Incidents.FirstOrDefault(x => x.Number == number);
                if (find == null)
                    throw new Exception("Old incident not exist in the db");

                var findNew = con.Incidents.Count(x => x.Number == UpdatedIncident.Number);
                if (findNew == 0)
                    throw new Exception("Old incident not exist in the db");

                find.Number = UpdatedIncident.Number;
                find.Date = UpdatedIncident.Date;
                find.CallerName = UpdatedIncident.CallerName;
                find.CallerNumber = UpdatedIncident.CallerNumber;
                find.CategoryId = UpdatedIncident.CategoryId;
                find.LocationId = UpdatedIncident.LocationId;
                               

                
                return con.SaveChanges();
            }
        }

        public int AddCategory(Category category)
        {
            using (con = new ApplicationDbContext())
            {
                con.Categories.Add(category);
                return con.SaveChanges();
            }
        }

        public int AddLocation(Location location)
        {
            using (con = new ApplicationDbContext())
            {
                con.Locations.Add(location);
                return con.SaveChanges();
            }
        }
    }
}
