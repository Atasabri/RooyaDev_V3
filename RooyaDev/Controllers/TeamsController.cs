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
    public class TeamsController : Controller
    {
        private DB db = new DB();

        // GET: Teams
        public ActionResult Index()
        {
            return View(db.Teams.ToList());
        }

        // GET: Teams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }
        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Job,FaceBook,Twitter,LinkedIn")] Team team,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid&&Photo!=null)
            {
                db.Teams.Add(team);
                db.SaveChanges();
                Photo.SaveAs(Server.MapPath("~/Uploads/Team/" + team.ID + ".jpg"));
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: Teams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Job,FaceBook,Twitter,LinkedIn")] Team team,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
                if(Photo!=null)
                {
                    Photo.SaveAs(Server.MapPath("~/Uploads/Team/" + team.ID + ".jpg"));
                }
                return RedirectToAction("Index");
            }
            return View(team);
        }
        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Team team = db.Teams.Find(id);
            db.Teams.Remove(team);
            db.SaveChanges();
            FileInfo F = new FileInfo(Server.MapPath("~/Uploads/Team/" + id + ".jpg"));
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
