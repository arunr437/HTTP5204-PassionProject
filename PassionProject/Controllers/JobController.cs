using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.IO;
using PassionProject.Data;
using PassionProject.Models;
using PassionProject.Models.ViewModels;

namespace PassionProject.Controllers
{
    public class JobController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        //Creating a db object of the JobPortalContext file. 
        private JobPortalContext db = new JobPortalContext();

        // GET: This method is used to get the list of jobs
        public ActionResult ListJobs(string searchKey)
        {
            Debug.WriteLine("Entered List jobs... ");
            Debug.WriteLine("The entered search key is:" + searchKey);

            //Query to get the list of jobs from the JobPosts table
            string query = "select * from JobPosts ";
            
            //Code to implement Search Box feature
            if(searchKey!=null)
            {
                query = query + "where name like '%" + searchKey + "%'";
                Debug.WriteLine("The search query is" + query);
            }
            List<JobPost> jobs = db.JobPosts.SqlQuery(query).ToList();

            //Calling the Job View with the list of jobs
            return View(jobs);
        }

        // GET: Function is used to call the view that will display the Add form
        public ActionResult AddJobs()
        {
            Debug.WriteLine("Adding new Jobs...");
            return View();
        }
        //POST: This method is used to get the values from the form and insert it into the database
        [HttpPost]
        public ActionResult AddJobs(string name, string company, string skill, string description, string location)
        {
            Debug.WriteLine("Creating a new job with the follwing details");
            Debug.WriteLine(name + company + skill + description + location);

            //Query to create a new Job Post
            string query = "insert into JobPosts (name,company,skill,description,location) values (@name,@company,@skill,@description,@location)";
            SqlParameter[] sqlParams = new SqlParameter[5];
            sqlParams[0] = new SqlParameter("@name", name);
            sqlParams[1] = new SqlParameter("@company", company);
            sqlParams[2] = new SqlParameter("@skill", skill);
            sqlParams[3] = new SqlParameter("@description", description);
            sqlParams[4] = new SqlParameter("@location", location);
            db.Database.ExecuteSqlCommand(query, sqlParams);

            //Redirecting the control back to list jobs. 
            return RedirectToAction("ListJobs");
        }

        //GET: Function to get the specific Job details. 
        public ActionResult ShowJob(int id)
        {
            Debug.WriteLine("Entering Show Job");
            Debug.WriteLine("Entered Job ID is:"+id);

            //This query gets the job with the specified jobId
            string query = "select * from JobPosts where JobId = @JobId";
            JobPost job = db.JobPosts.SqlQuery(query, new SqlParameter("@JobId", id)).FirstOrDefault();

            //This query gets the list of seekers who have applied for the specific job. 
            string query2 = "select * from JobSeekers s join JobApplications a on s.SeekerId = a.seekerId join JobPosts p on p.JobId = a.jobId where p.JobId = @JobId; ";
            List<JobSeeker> seekers = db.JobSeekers.SqlQuery(query2, new SqlParameter("@JobId", id)).ToList();
            
            //This query gets list of seekers who have not applied for the specific job. 
            string query3 = "select * from JobSeekers S where not exists(select A.seekerId from JobApplications A where S.SeekerId = A.seekerId and A.jobId = @jobId)";
            List<JobSeeker> seekersList = db.JobSeekers.SqlQuery(query3, new SqlParameter("@JobId", id)).ToList();

            //Creating an object for the ShowJobPost ViewModel and adding the result of above 3 queries to it. 
            ShowJobPost showJobPost = new ShowJobPost();
            showJobPost.jobPost = job;
            showJobPost.seeker = seekers;
            showJobPost.seekerList = seekersList;

            //Returning the ShowJobPost ViewModel object to the ShowJob view. 
            return View(showJobPost);
            
            
        }

        //GET: This function is used to fetch the data that will be displayed in the update function. 
        public ActionResult UpdateJob(int id)
        {
            Debug.WriteLine("Entering Update Job");
            Debug.WriteLine("Fetching data to be displayed in the update job page");

            //Query to get the job Details with specific jobId id. 
            string query = "select * from JobPosts where JobId = @jobId";
            JobPost job = db.JobPosts.SqlQuery(query,new SqlParameter("@jobId",id)).FirstOrDefault();

            //Calling the job view with the Specific job details
            return View(job);
        }

        //POST: This function is used to Update the Job table with the data entered in the update page form. 
        [HttpPost]
        public ActionResult UpdateJob(int ?id, string name, string company, string skill, string description, string location)
        {
            Debug.WriteLine("Updating job " + id);
            Debug.WriteLine("Updating the data entered in the form to the Job table ");

            //Query to update the job details into the Job table
            string query = "update JobPosts set name = @name, company = @company,skill = @skill,  description = @description, location=@location where JobId = @jobId";
            SqlParameter[] sqlParams = new SqlParameter[6];
            sqlParams[0] = new SqlParameter("@name", name);
            sqlParams[1] = new SqlParameter("@company", company);
            sqlParams[2] = new SqlParameter("@skill", skill);
            sqlParams[3] = new SqlParameter("@description", description);
            sqlParams[4] = new SqlParameter("@location", location);
            sqlParams[5] = new SqlParameter("@JobId", id);
            db.Database.ExecuteSqlCommand(query,sqlParams);

            //Redirecting the control back to the List Jobs view. 
            return RedirectToAction("ListJobs");
        }
        
        //GET: Function to delete a job in the Job table. 
        public ActionResult DeleteJob(int id)
        {
            Debug.WriteLine("Deleting Jobs with the ID: ");
            Debug.WriteLine(id);

            //Query to delete the job with the specific jobId id
            string query = "delete from JobPosts where JobId = @JobId";
            Debug.WriteLine(query);
            SqlParameter[] sqlParams = new SqlParameter[1];
            sqlParams[0] = new SqlParameter("@JobId", id);
            db.Database.ExecuteSqlCommand(query, sqlParams);

            //Redirecting the control back to List Jobs view. 
            return RedirectToAction("ListJobs");
        }
    }
}
