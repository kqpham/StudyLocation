using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using System.Xml.Linq;

namespace BtsIntegrated.Controllers
{
    public class HomeController : Controller
    {
        Manager m = new Manager();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[Route("Markers/{postalCode}")]
        public ActionResult Markers()
        {
            //if (postalCode.IsEmpty())
            //{
            //    return View("Index");
            //}
            //var data = m.GetUserLatLngCoords(postalCode);
            //var userGeoCoord = new UserGeoWithLocations
            //{
            //    Latitude = data[0],
            //    Longitude = data[1],
            //    Locations = m.LocationGetAll()

            //};
            //return View(userGeoCoord);
            return View("Index");
        }

        //POST
        [HttpPost]
        //[Route("Markers/{postalCode}")]
        public ActionResult Markers(string postalCode)
        {
            //SetTemp(postalCode);
            if (postalCode.IsEmpty())
            {
                return View("Index");
            }
            var data = m.GetUserLatLngCoords(postalCode);
            var userGeoCoord = new UserGeoWithLocations
            {
                Latitude = data[0],
                Longitude = data[1],
                Locations = m.LocationGetAll()
                
            };
            return View(userGeoCoord);
        }
    }
}