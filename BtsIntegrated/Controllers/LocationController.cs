using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BtsIntegrated.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LocationController : Controller
    {
        Manager m = new Manager();
        // GET: Location
        public ActionResult Index()
        {
            var data = m.LocationGetAll();
            return View(data);
        }

        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            var data = m.LocationGetOne(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }
        [AllowAnonymous]
        public ActionResult PubLocationDetails(int? id)
        {
            var o = m.LocationGetOneWithComment(id.GetValueOrDefault());
            //add rating data here
            o.RatingValue = m.GetAvgRatingForOneLocation(id.GetValueOrDefault());
            o.CommentUserName = m.GetUserNameForComment(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }
        // GET: Location/Create
        public ActionResult Create()
        {
            return View(new LocationWithTimings());
        }

        // POST: Location/Create
        [HttpPost]
        public ActionResult Create(LocationWithTimings newLocation)
        {
            if (!ModelState.IsValid)
            {
                return View(newLocation);
            }
            var addedLocation = m.LocationAdd(newLocation);

            if (addedLocation == null)
            {
                return View(newLocation);
            }
            return RedirectToAction("Details", new { id = addedLocation.LocationId });
        }

        // GET: Location/Edit/5
        public ActionResult Edit(int? id)
        {
            var data = m.LocationGetOne(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            //var editForm = m.mapper.Map<LocationWithTimings>(data);
            return View(data);
        }

        // POST: Location/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, LocationWithTimings newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new { id = newItem.LocationId });
            }
            if (id.GetValueOrDefault() != newItem.LocationId)
            {
                return RedirectToAction("Index");
            }
            var editedItem = m.LocationEditExisting(newItem);

            if (editedItem == null)
            {
                return RedirectToAction("Edit", new { id = newItem.LocationId });
            }
            return RedirectToAction("Index");
        }

        // GET: Location/Delete/5
        public ActionResult Delete(int id)
        {
            var data = m.LocationGetOne(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            DeleteConfirmed(id);
            //return View(data);
            return RedirectToAction("Index");
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public void DeleteConfirmed(int id)
        {
            var data = m.LocationGetOne(id);
            if (data == null)
            {
                return;
                //return HttpNotFound();
            }
            m.LocationRemove(id);
            //return RedirectToAction("Index");
        }

        public ActionResult ModalAction(int id)
        {
            var data = m.LocationGetOne(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Location", data);
        }
    }
}