using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PassionProject.Models;

namespace PassionProject.Data
{
    
    //The context class is used to query or save data into the database. 
    public class JobPortalContext :DbContext
    {
        public JobPortalContext() : base()
        {

        }

        
        public System.Data.Entity.DbSet<JobPost> JobPosts { get; set; }
        public System.Data.Entity.DbSet<JobSeeker> JobSeekers { get; set; } 
        public System.Data.Entity.DbSet<JobApplication> JobApplications { get; set; }
    }


}