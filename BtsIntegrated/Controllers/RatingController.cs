using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BtsIntegrated.Controllers
{
    public class RatingController : Controller
    {
        Manager m = new Manager();
        // GET: Rating
        public ActionResult Index()
        {
            return View();
        }

        // GET: Rating/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Rating/Create
        public ActionResult Create()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login","Account");
            }
            
            return PartialView("_Rating",new RatingAdd());
        }

        // POST: Rating/Create
        [HttpPost]
        public ActionResult Create(RatingAdd newRating, int id,double lat,double lng)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            if (!ModelState.IsValid)
            {
                RedirectToAction("Index","Home");
            }
            newRating.LocationId = id;
             m.RatingAdd(newRating);

            //if (addedRating == null)
            //{
            //    return View(newRating);
            //}
            var userGeoCoord = new UserGeoLocation
            {
                Latitude = lat,
                Longitude = lng,
                //Locations = m.LocationGetAll()

            };
            return RedirectToAction("Markers","Home",userGeoCoord);

        }

        // GET: Rating/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rating/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //// GET: Rating/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Rating/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public ActionResult ModalAction(int id)
        {
            var data = m.LocationGetOne(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Rating", new RatingAdd());
        }
    }
}
