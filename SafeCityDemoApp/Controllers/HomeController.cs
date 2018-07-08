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
            Locations();
            Categories();
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreateIncident(Incident incident)
        {
            try
            {
                var res = dataConn.AddIncident(incident);
                Locations();
                Categories();
                return View(incident);
            }
            catch (Exception ex )
            {
                throw ex;
            }          
           
        }


        [HttpGet]
        public ActionResult EditIncident(string Number)
        {
            Locations();
            Categories();

            var incident = dataConn.GetIncidentByNumber(Number);
            return View(incident);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditIncident(Incident incident)
        {
            try
            {
                var res = dataConn.UpdateIncident(incident.Number,incident);
                Locations();
                Categories();
                return View(incident);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        #region Viewbag data

        private void Locations()
        {
            var data = dataConn.GetLocations()?.ToList();

            var select = new SelectList(new List<string>() {"--Select--"});
            if (data != null && data.Count > 0)
                select = new SelectList(data, "Id", "Name");

            ViewBag.Locations = select;
        }

        private void Categories()
        {

            var data = dataConn.GetCategories()?.ToList();

            var select = new SelectList(new List<string>() { "--Select--" });
            if (data != null && data.Count > 0)
                select = new SelectList(data, "Id", "Name");

            ViewBag.Categories = select;
        }


        #endregion
    }
}