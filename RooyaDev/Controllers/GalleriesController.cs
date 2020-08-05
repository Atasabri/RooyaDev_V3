using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RooyaDev.Models;
using System.IO;

namespace RooyaDev.Controllers
{
    [Authorize]
    [HandleError(View = "~/Views/Shared/Error.cshtml")]
    public class GalleriesController : Controller
    {
        private DB db = new DB();

        // GET: Galleries
        public ActionResult Index()
        {
            return View(db.Galleries.ToList());
        }

        // GET: Galleries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        // POST: Galleries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Name_AR,Description,Description_AR")] Gallery gallery,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid&&Photo!=null)
            {
                db.Galleries.Add(gallery);
                db.SaveChanges();
                Photo.SaveAs(Server.MapPath("~/Uploads/Gallery/" + gallery.ID + ".jpg"));
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: Galleries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        // POST: Galleries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Name_AR,Description,Description_AR")] Gallery gallery,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gallery).State = EntityState.Modified;
                db.SaveChanges();
                if(Photo!=null)
                {
                    Photo.SaveAs(Server.MapPath("~/Uploads/Gallery/" + gallery.ID + ".jpg"));
                }
                return RedirectToAction("Index");
            }
            return View(gallery);
        }


        // POST: Galleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gallery gallery = db.Galleries.Find(id);
            db.Galleries.Remove(gallery);
            db.SaveChanges();
            FileInfo F = new FileInfo(Server.MapPath("~/Uploads/Gallery/" + id + ".jpg"));
            if(F.Exists)
            {
                F.Delete();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
