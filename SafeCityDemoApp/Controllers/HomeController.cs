using SafeCityDemoApp.SafeCityDemoServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SafeCityDemoApp.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
            dataConn = new SafeCityDemoServiceReference.SafeCityDemoServiceContractClient("BasicHttpBinding_ISafeCityDemoServiceContract");

        }

        SafeCityDemoServiceReference.SafeCityDemoServiceContractClient dataConn;

        public ActionResult Index()
        {
            var incidents = dataConn.GetAllIncidents()?.ToList();
            return View(incidents);
        }



        public ActionResult GetIncidentByIncidentNumber(string Number)
        {
            var incident = dataConn.GetIncidentByNumber(Number);
            return View(incident);
        }

        [HttpGet]
        public ActionResult CreateIncident()
        {

            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreateIncident(Incident incident)
        {
            var res = dataConn.AddIncident(incident);

            return View(incident);
        }
    }
}