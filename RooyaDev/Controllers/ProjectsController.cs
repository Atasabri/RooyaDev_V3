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
using System.Globalization;

namespace RooyaDev.Controllers
{
    [Authorize]
    [HandleError(View = "~/Views/Shared/Error.cshtml")]
    public class ProjectsController : Controller
    {
        private DB db = new DB();

        // GET: Projects
        public ActionResult Index()
        {
            if(Session["Tasks"]!=null)
            {
                Session.Remove("Tasks");
            }
            if (Session["Links"] != null)
            {
                Session.Remove("Links");
            }
            var projects = db.Projects.Include(p => p.User);
            return View(projects.ToList());
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }
        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,UnderWork,Finished,Expire_Date,Description,User_ID")] Project project,List<HttpPostedFileBase> Photos,HttpPostedFileBase logo,string Expire_Date)
        {
            if (Request.Cookies["Language"] != null)
            {
                if (Request.Cookies["Language"].Value == "ar")
                {
                    project.Expire_Date = Convert.ToDateTime(Expire_Date, new CultureInfo("ar-AE"));
                }
                else
                {
                    project.Expire_Date = Convert.ToDateTime(Expire_Date);
                }
            }
            else
            {
                project.Expire_Date = Convert.ToDateTime(Expire_Date);
            }
            if (Session["Tasks"]!=null)
                {
                    List<Task> List = Session["Tasks"] as List<Task>;
                    foreach (var item in List)
                    {
                        project.Tasks.Add(item);
                    }
                    Session.Remove("Tasks");
                }
                if (Session["Links"] != null)
                {
                    List<Project_Videos> List = Session["Links"] as List<Project_Videos>;
                    foreach (var item in List)
                    {
                        project.Project_Videos.Add(item);
                    }
                    Session.Remove("Links");
                }
                db.Projects.Add(project);
                db.SaveChanges();
                if(Photos[0]!=null)
                {
                    foreach (var item in Photos)
                    {
                        item.SaveAs(Server.MapPath("~/Uploads/Projects/" + project.ID + "Img" + item.FileName));
                    }
                }
                if (logo != null)
                {
                    logo.SaveAs(Server.MapPath("~/Uploads/Project_Logo/" + project.ID + ".jpg"));
                }
                return RedirectToAction("Index");         
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            if (Session["Tasks"] != null)
            {
                Session.Remove("Tasks");
            }
            if (Session["Links"] != null)
            {
                Session.Remove("Links");
            }
            ViewBag.User_ID = new SelectList(db.Users, "ID", "Name", project.User_ID);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,UnderWork,Finished,Expire_Date,Description,User_ID")] Project project,List<HttpPostedFileBase>Photos,HttpPostedFileBase logo)
        {
            if (ModelState.IsValid)
            {
                if (Session["Tasks"] != null)
                {
                    List<Task> List = Session["Tasks"] as List<Task>;
                    foreach (var item in List)
                    {
                        item.Project_ID = project.ID;
                        db.Tasks.Add(item);
                    }
                    Session.Remove("Tasks");
                }
                if (Session["Links"] != null)
                {
                    List<Project_Videos> List = Session["Links"] as List<Project_Videos>;
                    foreach (var item in List)
                    {
                        item.Project_ID = project.ID;
                        db.Project_Videos.Add(item);
                    }
                    Session.Remove("Links");
                }
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                if(Photos[0]!=null)
                {
                    foreach (var item in Photos)
                    {
                        item.SaveAs(Server.MapPath("~/Uploads/Projects/" + project.ID + "Img" + item.FileName));
                    }
                }
                if(logo!=null)
                {
                    logo.SaveAs(Server.MapPath("~/Uploads/Project_Logo/"+project.ID+".jpg"));
                }
                return RedirectToAction("Index");
            }
            ViewBag.User_ID = new SelectList(db.Users, "ID", "Name", project.User_ID);
            return View(project);
        }
        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            string[]files= Directory.GetFiles(Server.MapPath("~/Uploads/Projects"), id + "*");
            foreach (var item in files)
            {
                FileInfo F = new FileInfo(item);
                if(F.Exists)
                {
                    F.Delete();
                }
            }
            FileInfo Logo = new FileInfo(Server.MapPath("~/Uploads/Project_Logo/" + id + ".jpg"));
            if(Logo.Exists)
            {
                Logo.Delete();
            }
            FileInfo File = new FileInfo(Server.MapPath("~/Uploads/Project_File/" + id + ".pdf"));
            if (File.Exists)
            {
                File.Delete();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AddTask(string Task)
        {
            if(Session["Tasks"]!=null)
            {
                List<Task> List = Session["Tasks"] as List<Task>;
                List.Add(new Task { Name = Task });
                Session["Tasks"] = List;
            }
            else
            {
                List<Task> List = new List<Task>();
                List.Add(new Task { Name = Task });
                Session["Tasks"] = List;
            }
            return PartialView("_Tasks");
        }
        [HttpPost]
        public ActionResult DeleteTask(int id)
        {
            Task task = db.Tasks.Find(id);
            Project project = db.Projects.Find(task.Project_ID);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return PartialView("_DeleteTask",project);
        }
        [HttpPost]
        public ActionResult DeletePhoto(string Path,int id)
        {
            Project project = db.Projects.Find(id);
            FileInfo F = new FileInfo(Path);
            if(F.Exists)
            {
                F.Delete();
            }
            return PartialView("_DeletePhoto", project);           
        }
        [HttpPost]
        public ActionResult AddLink(string url)
        {
            if(Session["Links"]!=null)
            {
                List<Project_Videos> List = Session["Links"] as List<Project_Videos>;
                List.Add(new Project_Videos { Link = url });
                Session["Links"] = List;
            }
            else
            {
                List<Project_Videos> List = new List<Project_Videos>();
                List.Add(new Project_Videos { Link = url });
                Session["Links"] = List;
            }
            return PartialView("_Links");
        }
        [HttpPost]
        public ActionResult DeleteLink(int id)
        {
            Project_Videos Link = db.Project_Videos.Find(id);
            Project project = db.Projects.Find(Link.Project_ID);
            db.Project_Videos.Remove(Link);
            db.SaveChanges();
            return PartialView("_DeleteLinks", project);
        }
        [HttpPost]
        public ActionResult FinishTask(int id)
        {
            Task task = db.Tasks.Find(id);
            Project project = db.Projects.Find(task.Project_ID);
            task.Finished = true;
            db.Entry(task).State = EntityState.Modified;
            db.SaveChanges();
            return PartialView("_DeleteTask", project);
        }
        [HttpPost]
        public ActionResult Download(string path,string name)
        {
            return File(path, "application/pdf", name + ".pdf");
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
