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
    public class ServicesController : Controller
    {
        private DB db = new DB();

        // GET: Services
        public ActionResult Index()
        {
            if(Session["Heads"]!=null)
            {
                Session.Remove("Heads");
            }
            return View(db.Services.ToList());
        }

        // GET: Services/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Name_AR,Description,Description_AR")] Service service,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid&&Photo!=null)
            {
                if(Session["Heads"]!=null)
                {
                    List<Head> List = Session["Heads"] as List<Head>;
                    foreach (var item in List)
                    {
                        service.Heads.Add(item);
                    }
                }
                db.Services.Add(service);
                db.SaveChanges();
                Photo.SaveAs(Server.MapPath("~/Uploads/Services/" + service.ID + ".jpg"));
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: Services/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            if (Session["Heads"] != null)
            {
                Session.Remove("Heads");
            }
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Name_AR,Description,Description_AR")] Service service ,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Session["Heads"] != null)
                {
                    List<Head> List = Session["Heads"] as List<Head>;
                    foreach (var item in List)
                    {
                        item.Service_ID = service.ID;
                        db.Heads.Add(item);
                    }
                }
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                if(Photo!=null)
                {
                    Photo.SaveAs(Server.MapPath("~/Uploads/Services/" + service.ID + ".jpg"));
                }
                return RedirectToAction("Index");
            }
            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
            db.SaveChanges();
            FileInfo F = new FileInfo(Server.MapPath("~/Uploads/Services/" + id + ".jpg"));
            if(F.Exists)
            {
                F.Delete();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AddHead(string Head, string Head_AR)
        {
            if(Session["Heads"]!=null)
            {
                List<Head> List = Session["Heads"] as List<Head>;
                List.Add(new Head { Name = Head ,Name_AR=Head_AR});
                Session["Heads"] = List;
            }
            else
            {
                List<Head> List = new List<Models.Head>();
                List.Add(new Head { Name = Head,Name_AR=Head_AR });
                Session["Heads"] = List;
            }
            return PartialView("_Heads");
        }

        [HttpPost]
        public ActionResult DeleteHead(int id)
        {
            Head head = db.Heads.Find(id);
            db.Heads.Remove(head);
            db.SaveChanges();
            Service service = db.Services.Find(head.Service_ID);
            return PartialView("_DeleteHeads",service);
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
