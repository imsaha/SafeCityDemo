using SafeCityDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SafeCityDemo
{
    [ServiceContract]
    public interface ISafeCityDemoServiceContract
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        ICollection<Incident> GetAllIncidents();

        [OperationContract]
        Incident GetIncidentByNumber(string Number);

        [OperationContract]
        ICollection<Incident> GetIncidentByCallerNumber(string CallerNumber);
        
        [OperationContract]
        ICollection<Category> GetCategories();

        [OperationContract]
        ICollection<Location> GetLocations();

        [OperationContract]
        int AddIncident(Incident incident);

        [OperationContract]
        int UpdateIncident(string number, Incident UpdatedIncident);

        [OperationContract]
        int AddCategory(Category category);

        [OperationContract]
        int AddLocation(Location location);


    }
}
