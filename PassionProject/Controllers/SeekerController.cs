using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data.Entity;
using PassionProject.Data;
using PassionProject.Models;
using System.Diagnostics;
using System.IO;
using PassionProject.Models.ViewModels;

namespace PassionProject.Controllers
{
    public class SeekerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //Creating a db object of the JobPortalContext file. 
        private JobPortalContext db = new JobPortalContext();

        // GET: This method is used to get the list of Seekers
        public ActionResult ListSeekers(string searchKey)
        {
            Debug.WriteLine("Entered List Seekers... ");
            Debug.WriteLine("The entered search key is:" + searchKey);
            
            //Query to get the list of Seekers from the Seekers table
            string query = "select * from JobSeekers ";
            if (searchKey != "")
            {
                query = query + "where name like '%" + searchKey + "%'";
                Debug.WriteLine("The search query is" + query);
            }
            List<JobSeeker> seekers = db.JobSeekers.SqlQuery(query).ToList();

            //Calling the Seeker View with the list of seekers
            return View(seekers);
        }

        // GET: Function is used to call the view that will display the Add Seekerform
        public ActionResult AddSeekers()
        {
            Debug.WriteLine("Adding new Seekers..");
            return View();
        }

        //POST: This method is used to get the values from the form and insert it into the database
        [HttpPost]
        public ActionResult AddSeekers(string name, string emailId, string location)
        {
            Debug.WriteLine("Creating a new Seeker");
            Debug.WriteLine(name + emailId + location);

            //Query to insert the data from the form into the database
            string query = "insert into JobSeekers (name,emailId,location) values (@name,@emailId,@location)";
            SqlParameter[] sqlParams = new SqlParameter[3];
            sqlParams[0] = new SqlParameter("@name", name);
            sqlParams[1] = new SqlParameter("@emailId", emailId);
            sqlParams[2] = new SqlParameter("@location", location);
            db.Database.ExecuteSqlCommand(query, sqlParams);

            //Redirecting the control back to list Seekers. 
            return RedirectToAction("ListSeekers");
        }

        //GET: Function to get the specific Seeker details. 
        public ActionResult ShowSeeker(int id)
        {
            Debug.WriteLine("Entering Show Seeker");
            Debug.WriteLine("Entered Seeker ID is:" + id);

            //This query is used to get the seeker with the specifiec SeekerId
            string query = "select * from JobSeekers where SeekerId = @SeekerId";
            JobSeeker seeker = db.JobSeekers.SqlQuery(query, new SqlParameter("@SeekerId", id)).FirstOrDefault();

            //This query is used to get the list of posts which the seeker has applied
            string query2 = "select * from JobPosts p join JobApplications a on p.JobId = a.jobId join JobSeekers s on s.seekerId = a.seekerId where s.SeekerId = @SeekerId";
            List<JobPost> posts = db.JobPosts.SqlQuery(query2,new SqlParameter("@SeekerId",id)).ToList();

            //This query is used to get the list of posts which the seeker has not applied
            string query3 = "select * from JobPosts p where not exists(select A.jobId from JobApplications A where p.JobId = A.jobId and A.seekerId = @SeekerId)";
            List<JobPost> postsList = db.JobPosts.SqlQuery(query3, new SqlParameter("@SeekerId", id)).ToList();

            //Creating an object for the ShowSeeker ViewModel and adding the result of above 3 queries to it. 
            ShowSeeker showSeeker = new ShowSeeker();
            showSeeker.seeker = seeker;
            showSeeker.posts = posts;
            showSeeker.postsList = postsList;

            //Returning the showSeeker ViewModel object to the ShowSeeker view.
            return View(showSeeker);
        }

        //GET: This function is used to fetch the data that will be displayed in the update function. 
        public ActionResult UpdateSeeker(int id)
        {
            Debug.WriteLine("Entering Update Seeker");
            Debug.WriteLine("Fetching data to be displayed in the update seeker page");

            //Query to get the Seeker Details with specific SeekerId id. 
            string query = "select * from JobSeekers where SeekerId = @SeekerId";
            JobSeeker seeker = db.JobSeekers.SqlQuery(query, new SqlParameter("@SeekerId", id)).FirstOrDefault();

            //Calling the job view with the Specific Seeker details
            return View(seeker);
        }

        //POST: This function is used to Update the Seeker table with the data entered in the update page form. 
        [HttpPost]
        public ActionResult UpdateSeeker(int? id, string name, string emailId, string location)
        {
            Debug.WriteLine("Updating Seeker " + id);
            Debug.WriteLine("Updating the data entered in the form to the Seeker table ");

            //Query to update the Seeker details into the Seeker table
            string query = "update JobSeekers set name = @name,emailId = @emailId,location=@location where SeekerId = @SeekerId";
            SqlParameter[] sqlParams = new SqlParameter[4];
            sqlParams[0] = new SqlParameter("@name", name);
            sqlParams[1] = new SqlParameter("@emailId", emailId);
            sqlParams[2] = new SqlParameter("@location", location);
            sqlParams[3] = new SqlParameter("@SeekerId", id);
            db.Database.ExecuteSqlCommand(query, sqlParams);

            //Redirecting the control back to the List Seekers view. 
            return RedirectToAction("ListSeekers");

        }

        //GET: Function to delete a Seeker in the Seeker table. 
        public ActionResult DeleteSeeker(int id)
        {
            Debug.WriteLine("Deleting Seeker with the ID: ");
            Debug.WriteLine(id);

            //Query to delete the seeker with the specific seekerId id
            string query = "delete from JobSeekers where SeekerId = @SeekerId";
            Debug.WriteLine(query);
            SqlParameter[] sqlParams = new SqlParameter[1];
            sqlParams[0] = new SqlParameter("@SeekerId", id);
            db.Database.ExecuteSqlCommand(query, sqlParams);

            //Redirecting the control back to List Seekers view. 
            return RedirectToAction("ListSeekers");
        }
    }
}