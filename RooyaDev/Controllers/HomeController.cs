using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RooyaDev.Models;
using System.Globalization;
using System.Threading;
using System.IO;

namespace RooyaDev.Controllers
{
    [HandleError(View = "ErrorPage")]
    public class HomeController : Controller
    {
        DB db = new DB();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email,string password)
        {
            if(db.Users.Any(x=>x.Email==email&&x.Password==password))
            {
                User user = db.Users.Single(x => x.Email == email && x.Password == password);
                Session["Login"] = user.ID;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = SiteResource.InvalidEmail;
            }
            return View();
        }

        //Register
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if(db.Users.Any(x=>x.Email==user.Email))
            {
                ViewBag.error = SiteResource.EmailUsed;
            }
            else
            {
                
                db.Users.Add(user);
                db.SaveChanges();
                DEL.Send_Welcome("Welcome To Rooya Development", user.Email, Server.MapPath("~/Welcome.html"));
                Session["Login"] = user.ID;
                return  RedirectToAction("Index");
            }
            return View(user);
        }

        //Language
        public ActionResult Language(String Code)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Code);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Code);

            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = Code;
            Response.Cookies.Add(cookie);
            return Redirect(Request.UrlReferrer.AbsolutePath);
        }
       
        //Sign Out
        public ActionResult SignOut()
        {
            if(Session["Login"]!=null)
            {
                Session.Remove("Login");
            }
            return RedirectToAction("Login");
        }
       
        //Subscribe
        [HttpPost]
        public ActionResult Subscribe(string Email)
        {
            if(Email.Contains("@")&&!db.Subscribers.Any(x=>x.Email==Email))
            {
                db.Subscribers.Add(new Subscriber { Email = Email });
                db.SaveChanges();
            }
            return Redirect(Request.UrlReferrer.AbsolutePath);
        }
       
        //About Us
        public ActionResult AboutUs()
        {
            return View(db.Teams.ToList());
        }

        //Portfolio
        public ActionResult Gallery()
        {
            return View(db.Galleries.ToList());
        }

        //Contact US
        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactUs(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
            return View();
        }
       
        //Pricing
        public ActionResult Pricing()
        {
            return View(db.Pricings.ToList());
        }
        [HttpPost]
        public ActionResult Order(int price_id)
        {
            if(Session["Login"]!=null)
            {
                int User_ID = (int)Session["Login"];
                Order order = new Order { Price_ID = price_id, User_ID = User_ID, Date = DateTime.Now };
                db.Orders.Add(order);
                db.SaveChanges();
                Session[price_id.ToString()] = order.ID;
                Pricing price = db.Pricings.Find(price_id);
                return PartialView("_Order",price);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpPost]
        public ActionResult Pricing(string Name,string Description,string DeadLine,HttpPostedFileBase myfile)
        {
            if(Session["Login"]!=null)
            {
                if (myfile!=null)
                {
                    if (myfile.ContentType != "application/pdf")
                    {
                        ViewBag.error = SiteResource.enterpdffile;
                        return View(db.Pricings.ToList());
                    }
                }
                Project project = new Project();
                project.Name = Name;
                project.Description = Description;
                try
                {
                    if(Request.Cookies["Language"]!=null)
                    {
                        if(Request.Cookies["Language"].Value=="ar")
                        {
                            project.Expire_Date = Convert.ToDateTime(DeadLine, new CultureInfo("ar-AE"));
                        }
                        else
                        {
                            project.Expire_Date = Convert.ToDateTime(DeadLine);
                        }
                    }
                    else
                    {
                        project.Expire_Date = Convert.ToDateTime(DeadLine);
                    }
                    if (DateTime.Now>=project.Expire_Date)
                    {
                        throw new Exception();
                    }
                }
                catch 
                {
                    ViewBag.error = SiteResource.DeadLineError;
                    return View(db.Pricings.ToList());
                }
                int User_ID = (int)Session["Login"];
                project.User_ID = User_ID;
                project.UnderWork = false;
                project.Finished = false;
                db.Projects.Add(project);
                db.SaveChanges(); 
                if(myfile!=null)
                {
                    myfile.SaveAs(Server.MapPath("~/Uploads/Project_File/" + project.ID + ".pdf"));
                }
                ViewBag.Done = SiteResource.OrderDone;
                return View(db.Pricings.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
      
        //Services
        public ActionResult Services()
        {
            return View(db.Services.ToList());
        }
        public ActionResult Service(int? id)
        {
            if(id!=null)
            {
                return View(db.Services.Find(id));
            }
            else
            {
                return RedirectToAction("Services");
            }
        }

        //Carrers
        public ActionResult Carrers()
        {
            return View(db.Carrers.ToList());
        }
        [HttpPost]
        public ActionResult Carrers(Application application,HttpPostedFileBase myfile)
        {
            if(myfile.ContentType!="application/pdf")
            {
                ViewBag.error =SiteResource.enterpdffile;
            }
            else
            {
                db.Applications.Add(application);
                db.SaveChanges();
                myfile.SaveAs(Server.MapPath("~/Uploads/CV/" + application.ID + ".pdf"));
                ViewBag.Done = SiteResource.JobDone;
            }
            return View(db.Carrers.ToList());

        }
      
        //Project
        public ActionResult Project(int? id)
        {
            if(id==null)
            {
                return RedirectToAction("Index");
            }
            if(Session["Login"]!=null)
            {
                int user_id = (int)Session["Login"];
                User user = db.Users.Find(user_id);
                Project project = db.Projects.Find(id);
                if(project==null)
                {
                    return RedirectToAction("Index");
                }
                if(project.UnderWork==false)
                {
                    return RedirectToAction("Index");
                }
                if(user.Projects.Contains(project))
                {
                    if(Session["Comments"]!=null)
                    {
                        Session.Remove("Comments");
                    }
                    return View(project);
                }
            }
            return RedirectToAction("Login");
        }
        [HttpPost]
        public ActionResult AddComment(string Comment)
        {
            if(Session["Comments"]!=null)
            {
                List<Comment> List = Session["Comments"] as List<Comment>;
                List.Add(new Comment { Comment1 = Comment });
                Session["Comments"] = List;
            }
            else
            {
                List<Comment> List = new List<Comment>();
                List.Add(new Comment { Comment1 = Comment });
                Session["Comments"] = List;
            }
            return PartialView("_Comments");
        }
        [HttpPost]
        public ActionResult SendComments(int project_id)
        {
            if(Session["Login"]==null)
            {
                return RedirectToAction("Login");
            }
            if(Session["Comments"]!=null)
            {
                List <Comment> List= Session["Comments"] as List<Comment>;
                foreach (var item in List)
                {
                    item.Project_ID = project_id;
                    db.Comments.Add(item);
                }
                db.SaveChanges();
            }
            return RedirectToAction("Project", new { id = project_id });
        }

        //Error
        public ActionResult Error()
        {
            return RedirectToAction("ErrorPage");
        }
    }
}