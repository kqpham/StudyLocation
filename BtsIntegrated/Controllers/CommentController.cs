using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BtsIntegrated.Controllers
{
    public class CommentController : Controller
    {
        Manager m = new Manager();
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            return PartialView("_Comment", new CommentAdd());
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create(CommentAdd newComment, int id, double lat, double lng)
        {
            try
            {
                if(!HttpContext.User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Login", "Account");
                }
                if(!ModelState.IsValid)
                {
                    RedirectToAction("Index", "Home");
                }
                newComment.LocationId = id;
                m.LocationAddComment(newComment);

                var geoCoord = new UserGeoLocation
                {
                    Latitude = lat,
                    Longitude = lng,
                };

                
                return RedirectToAction("Markers","Home",geoCoord);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ModalAction(int id)
        {
            var d = m.LocationGetOne(id);
            if(d == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Comment", new CommentAdd());
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int? id)
        {
            var o = m.CommentGetByIdWithDetail(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = m.mapper.Map<CommentEditForm>(o);
                return PartialView(form);
            }
        }

        // POST: Comment/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, CommentEdit newComment)
        {
           if(!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new { id = newComment.CommentId });
            }
            var editedComment = m.CommentEditLines(newComment);
           // if (editedComment == null)
          //  {
               // return RedirectToAction("edit", new { id = newComment.CommentId });
          //  }
           // else
           // {
                return RedirectToAction("PubLocationDetails", new { id = newComment.CommentId });
           // }
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
