using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RooyaDev.Models;

namespace RooyaDev.Controllers
{
    [Authorize]
    [HandleError(View = "~/Views/Shared/Error.cshtml")]
    public class CarrersController : Controller
    {
        private DB db = new DB();

        // GET: Carrers
        public ActionResult Index()
        {
            if(Session["Skills"]!=null)
            {
                Session.Remove("Skills");
            }
            if (Session["Requirment"] != null)
            {
                Session.Remove("Requirment");
            }
            return View(db.Carrers.ToList());
        }

        // GET: Carrers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Carrer carrer = db.Carrers.Find(id);
            if (carrer == null)
            {
                return HttpNotFound();
            }
            return View(carrer);
        }

        // GET: Carrers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carrers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Salary,Type,Country")] Carrer carrer)
        {

                if(Session["Skills"]!=null)
                {
                    List<Skill> List = Session["Skills"] as List<Skill>;
                    foreach (var item in List)
                    {
                        carrer.Skills.Add(item);
                    }
                    Session.Remove("Skills");
                }
                if (Session["Requirment"] != null)
                {
                    List<Requirment> List = Session["Requirment"] as List<Requirment>;
                    foreach (var item in List)
                    {
                        carrer.Requirments.Add(item);
                    }
                    Session.Remove("Requirment");
                }
                db.Carrers.Add(carrer);
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET: Carrers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Carrer carrer = db.Carrers.Find(id);
            if (carrer == null)
            {
                return HttpNotFound();
            }
            if (Session["Skills"] != null)
            {
                Session.Remove("Skills");
            }
            if (Session["Requirment"] != null)
            {
                Session.Remove("Requirment");
            }
            return View(carrer);
        }

        // POST: Carrers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Salary,Type,Country")] Carrer carrer)
        {
            if (ModelState.IsValid)
            {
                if (Session["Skills"] != null)
                {
                    List<Skill> List = Session["Skills"] as List<Skill>;
                    foreach (var item in List)
                    {
                        item.Carrer_ID=carrer.ID;
                        db.Skills.Add(item);
                    }
                }
                if (Session["Requirment"] != null)
                {
                    List<Requirment> List = Session["Requirment"] as List<Requirment>;
                    foreach (var item in List)
                    {
                        item.Carrer_ID = carrer.ID;
                        db.Requirments.Add(item);
                    }
                }
                db.Entry(carrer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carrer);
        }
        // POST: Carrers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carrer carrer = db.Carrers.Find(id);
            db.Carrers.Remove(carrer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddSkill(string Skill)
        {
            if(Session["Skills"]!=null)
            {
                List<Skill> List = Session["Skills"] as List<Skill>;
                List.Add(new Skill { Name = Skill });
                Session["Skills"] = List;
            }
            else
            {
                List<Skill> List = new List<Models.Skill>();
                List.Add(new Skill { Name = Skill });
                Session["Skills"] = List;
            }
            return PartialView("_Skills");
        }

        [HttpPost]
        public ActionResult AddRequirment(string Requirment)
        {
            if (Session["Requirment"] != null)
            {
                List<Requirment> List = Session["Requirment"] as List<Requirment>;
                List.Add(new Requirment { Name = Requirment });
                Session["Requirment"] = List;
            }
            else
            {
                List<Requirment> List = new List<Models.Requirment>();
                List.Add(new Requirment { Name = Requirment });
                Session["Requirment"] = List;
            }
            return PartialView("_Requirment");
        }
        [HttpPost]
        public ActionResult DeleteSkill(int id)
        {
            Skill skill = db.Skills.Find(id);
            Carrer carrer = db.Carrers.Find(skill.Carrer_ID);
            db.Skills.Remove(skill);
            db.SaveChanges();
            return PartialView("_DeleteSkills", carrer);
        }
        [HttpPost]
        public ActionResult DeleteRequirment(int id)
        {
            Requirment requirment = db.Requirments.Find(id);
            Carrer carrer = db.Carrers.Find(requirment.Carrer_ID);
            db.Requirments.Remove(requirment);
            db.SaveChanges();
            return PartialView("_DeleteRequirment", carrer);
        }
        [HttpPost]
        public ActionResult DownloadCV(int id,string name)
        {
            return File(Server.MapPath("~/Uploads/CV/" + id + ".pdf"),"application/pdf",name+".pdf");
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
