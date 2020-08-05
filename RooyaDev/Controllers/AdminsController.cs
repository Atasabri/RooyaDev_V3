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
    [HandleError(View ="~/Views/Shared/Error.cshtml")]
    public class AdminsController : Controller
    {
        private DB db = new DB();

        // GET: Admins
        public ActionResult Index()
        {
            return View(db.Admins.ToList());
        }

        // GET: Admins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            int adminID = int.Parse(User.Identity.Name);
            if (db.Admins.Find(adminID).Type==0&&id!= adminID)
            {
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        // GET: Admins/Create

        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,User_Name,Password,Type")] Admin admin,HttpPostedFileBase Photo)
        {
                if(db.Admins.Any(x=>x.User_Name==admin.User_Name))
                {
                    ViewData["error"] = "This User Name Is Used !";
                    return RedirectToAction("Index");
                }
                db.Admins.Add(admin);
                db.SaveChanges();
                Photo.SaveAs(Server.MapPath("~/Uploads/Admins/" + admin.ID + ".jpg"));
                return RedirectToAction("Index");
        }

        // GET: Admins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            int adminID = int.Parse(User.Identity.Name);
            if (db.Admins.Find(adminID).Type == 0)
            {
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,User_Name,Password,Type")] Admin admin,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (db.Admins.Where(x=>x.ID!=admin.ID).Any(x => x.User_Name == admin.User_Name))
                {
                    ViewData["error"] = "This User Name Is Used !";
                    return RedirectToAction("Index");
                }
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                if(Photo!=null)
                {
                    Photo.SaveAs(Server.MapPath("~/Uploads/Admins/" + admin.ID + ".jpg"));
                }
                if (admin.ID == int.Parse(User.Identity.Name))
                {
                    return RedirectToAction("Login", "Auth");
                }
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
            db.SaveChanges();
            FileInfo F = new FileInfo(Server.MapPath("~/Uploads/Admins/" + id + ".jpg"));
            if(F.Exists)
            {
                F.Delete();
            }
            if(id==int.Parse(User.Identity.Name))
            {
                return RedirectToAction("Login", "Auth");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Dashboard()
        {
            return View(db);
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
