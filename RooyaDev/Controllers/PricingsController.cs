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
    public class PricingsController : Controller
    {
        private DB db = new DB();

        // GET: Pricings
        public ActionResult Index()
        {
            return View(db.Pricings.ToList());
        }

        // GET: Pricings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Pricing pricing = db.Pricings.Find(id);
            if (pricing == null)
            {
                return HttpNotFound();
            }
            return View(pricing);
        }
        // POST: Pricings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Name_AR")] Pricing pricing,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid&&Photo!=null)
            {
                db.Pricings.Add(pricing);
                db.SaveChanges();
                Photo.SaveAs(Server.MapPath("~/Uploads/Pricing/" + pricing.ID + ".jpg"));
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: Pricings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Pricing pricing = db.Pricings.Find(id);
            if (pricing == null)
            {
                return HttpNotFound();
            }
            return View(pricing);
        }

        // POST: Pricings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Name_AR")] Pricing pricing,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pricing).State = EntityState.Modified;
                db.SaveChanges();
                if(Photo!=null)
                {
                    Photo.SaveAs(Server.MapPath("~/Uploads/Pricing/" + pricing.ID + ".jpg"));
                }
                return RedirectToAction("Index");
            }
            return View(pricing);
        }
        // POST: Pricings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pricing pricing = db.Pricings.Find(id);
            db.Pricings.Remove(pricing);
            db.SaveChanges();
            FileInfo F = new FileInfo(Server.MapPath("~/Uploads/Pricing/" + id + ".jpg"));
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
