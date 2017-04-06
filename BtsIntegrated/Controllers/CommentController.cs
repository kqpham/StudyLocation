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
                if (!HttpContext.User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Login", "Account");
                }
                if (!ModelState.IsValid)
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


                return RedirectToAction("Markers", "Home", geoCoord);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ModalAction(int id)
        {
            var d = m.LocationGetOne(id);
            if (d == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Comment", new CommentAdd());
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int? id)
        {
            var o = m.CommentGetById(id.GetValueOrDefault());
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = m.mapper.Map<CommentEditForm>(o);
                return View(form);
            }
            //return View();
        }

        // POST: Comment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, CommentEdit newComment, int locId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("edit", new { id = newComment });
            }
            if (id.GetValueOrDefault() != newComment.CommentId)
            {
                return RedirectToAction("PubLocationDetails");
            }
            var editedComment = m.CommentEdit2(newComment);
            var locationNum = new locationB
            {
                LocationId = locId
            };

            return RedirectToAction("../Location/PubLocationDetails", new { id = locId });

        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int id)
        {
            //var c = m.LocationGetOneWithComment(id);
            var c = m.CommentGetById(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            //DeleteComment(id);
            return PartialView(c);
        }

        // POST: Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteComment(int? id, int locId)
        {

            // TODO: Add delete logic here
            var d = m.RemoveComment(id.GetValueOrDefault());
            if (d == false)
            {
                return HttpNotFound();
            }
            //m.RemoveComment(id);
            return RedirectToAction("../Location/PubLocationDetails", new { id = locId });
            //return RedirectToAction("Index");
        }
    }
}
