using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BtsProjectSite.Controllers
{
    public class CommentsController : Controller
    {
        ManageController m = new ManageController();
        // GET: Comments
        public ActionResult Index()
        {
            var c = m.CommentGetAll();
            return View(c);
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            var o = m.CommentGetByID(id.GetValueOrDefault());

            if(o== null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comments/Create
        [HttpPost]
        public ActionResult Create(int? id, LocationEditComments newComment)
        {
            //try
           // {
                // TODO: Add insert logic here
            if (!ModelState.IsValid)
            {
                //return View(newComment);
                  return RedirectToAction("edit", new { id = newComment.Id });
            }

            if(id.GetValueOrDefault() != newComment.Id)
            {
                return RedirectToAction("index");
            }

            //var editItem = m.Location
                //var addedComment = m.CommentAdd(newComment);

                /*if(addedComment == null)
                {
                    return View(newComment);
                }
                else
                {
                    return RedirectToAction("Details", new { id = addedComment.CommentId });
                }*/
            //}
            /*catch
            {
                return View();
            }*/
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comments/Edit/5
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

        // GET: Comments/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comments/Delete/5
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
