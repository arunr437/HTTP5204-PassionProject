using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProject.Models
{
    //This is the jobPost class. Its Primary Key is jobID. It has a one-many relationship with JobApplication.
    public class JobPost
    {
        [Key]
        public int jobId {get;set;}
        public string name {get;set;}
        public string company{get;set;}
        public string skill {get;set;}
        public string description {get; set;}
        public string location {get;set;}
    }
}