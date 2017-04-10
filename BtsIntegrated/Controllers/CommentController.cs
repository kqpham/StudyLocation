using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BtsIntegrated.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        Manager m = new Manager();
        // GET: Comment
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            return RedirectToAction("Index", "Home");
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
        public void Create(CommentAdd newComment, int id, double lat, double lng)
        {
            try
            {
                if (!HttpContext.User.Identity.IsAuthenticated)
                {
                     RedirectToAction("Login", "Account");
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


                //return RedirectToAction("Index", "Home");
            }
            catch
            {
                 RedirectToAction("Index","Home");
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
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new { id = newComment });
            }
            if (id.GetValueOrDefault() != newComment.CommentId)
            {
                return RedirectToAction("PubLocationDetails","Location");
            }
            var editedComment = m.CommentEdit2(newComment);
            var locationNum = new locationB
            {
                LocationId = locId
            };

            return RedirectToAction("PubLocationDetails","Location", new { id = locId });

        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int id)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
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
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            var d = m.RemoveComment(id.GetValueOrDefault());
            if (d == false)
            {
                return HttpNotFound();
            }
            //m.RemoveComment(id);
            return RedirectToAction("PubLocationDetails","Location", new { id = locId });
            //return RedirectToAction("Index");
        }
        public ActionResult DeleteAction(int id)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            var d = m.CommentGetById(id);
            if (d == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", d);
        }
    }
}