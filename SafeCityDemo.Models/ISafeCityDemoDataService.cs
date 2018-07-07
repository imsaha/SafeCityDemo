using SafeCityDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SafeCityDemo
{
    public interface ISafeCityDemoDataService
    {
        ICollection<Incident> Incidents();

        ICollection<Incident> Incidents(string Number);

        ICollection<Incident> Incidents(Expression<Func<Incident,bool>> expression);

        ICollection<Category> GetCategories();


        ICollection<Category> GetLocations();
    }

    public class SafeCityDemoDataService : ISafeCityDemoDataService
    {
        public SafeCityDemoDataService(ApplicationDbContext context)
        {
            con = context;
        }

        ApplicationDbContext con;
        public ICollection<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public ICollection<Category> GetLocations()
        {
            throw new NotImplementedException();
        }

        public ICollection<Incident> Incidents()
        {
            throw new NotImplementedException();
        }

        public ICollection<Incident> Incidents(string Number)
        {
            throw new NotImplementedException();
        }

        public ICollection<Incident> Incidents(Expression<Func<Incident, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}