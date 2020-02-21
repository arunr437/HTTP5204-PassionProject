using PassionProject.Data;
using PassionProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PassionProject.Controllers
{
    public class HomeController : Controller
    {
        private JobPortalContext db = new JobPortalContext();
        public ActionResult Index()
        {
            return View();
        }

        //POST: This method is used to validate the password and redirect to the entered seeker's page. 
        [HttpPost]
        public ActionResult Index(string user,string password)
        {
  
            if (password == "password")
            {
                string query = "select * from JobSeekers where name = @user";
                JobSeeker job = db.JobSeekers.SqlQuery(query, new SqlParameter("@user", user)).FirstOrDefault();
                return RedirectToAction("ShowSeeker", "Seeker", new { id = job.SeekerId });
            }
            else
            {
                return View(null, null, "Invalid Username/Password");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}