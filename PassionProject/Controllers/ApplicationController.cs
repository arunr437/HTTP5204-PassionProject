using PassionProject.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PassionProject.Controllers
{
    public class ApplicationController : Controller
    {
        //Creating a db object of the JobPortalContext file. 
        private JobPortalContext db = new JobPortalContext();

        public ActionResult Index()
        {
            return View();
        }

        //GET: This method is used to remove an application from the application table
        public ActionResult RemoveApplication(int id,string jobId,string target)
        {
            Debug.WriteLine("Deleting Application");
            Debug.WriteLine("Seeker Id:"+id);
            Debug.WriteLine("Job Id:"+jobId);

            //This query is used to delete JobApplications with the specified SeekerId and JobId
            string query = "delete from JobApplications where seekerId = @seekerId and jobId = @jobId";
            SqlParameter[] sqlParams = new SqlParameter[2];
            sqlParams[0] = new SqlParameter("@seekerId", id);
            sqlParams[1] = new SqlParameter("@jobId", jobId);
            db.Database.ExecuteSqlCommand(query, sqlParams);   
            
            //Redirecting control back to either ShowJob or ShowSeeker based on where the request came from
            if (target == "showJob")
            {
                return RedirectToAction("ShowJob", "Job", new { id = jobId });
            }
            else if (target == "showSeeker")
            {
                return RedirectToAction("ShowSeeker", "Seeker", new { id = id });
            }
            return RedirectToAction("Home");
        }

        //GET: This function is used to add a new application into the application table
        public ActionResult AddApplication(string seekerId,string jobId,string target)
        {
            Debug.WriteLine("Adding Applicant");
            Debug.WriteLine("SeekerID:" + seekerId);
            Debug.WriteLine("JobID:" + jobId);

            //Query to insert data into the JobApplications table
            string query = "insert into JobApplications (seekerId,jobId) values (@seekerId,@jobId)";
            SqlParameter[] sqlParams = new SqlParameter[2];
            sqlParams[0] = new SqlParameter("@seekerId", seekerId);
            sqlParams[1] = new SqlParameter("@jobId", jobId);
            db.Database.ExecuteSqlCommand(query, sqlParams);

            //Redirecting control back to either ShowJob or ShowSeeker based on where the request came from
            if (target == "showJob")
            {
                return RedirectToAction("ShowJob", "Job", new { id = jobId });
            }
            else if(target == "showSeeker")
            {
                return RedirectToAction("ShowSeeker", "Seeker", new { id = seekerId });
            }
            return RedirectToAction("Home");
        }
    }
}