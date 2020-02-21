using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProject.Models
{
    //This is the jobSeerker class. The primary key is SeekerId. It a One-to-Many relationship with jobApplication.  
    public class JobSeeker
    {
        [Key]
        public int SeekerId { get; set; }
        public string name { get; set; }
        public string emailId { get; set; }
        public string location { get; set; }
    }
}