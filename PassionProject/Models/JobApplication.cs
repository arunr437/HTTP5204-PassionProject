using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProject.Models
{
    //Model For JobApplication. This class a SeekerId and a JobId as foreign key. 
    public class JobApplication
    {
        [Key]
        public int applicationId { get; set; }
        public string coverLetter { get; set; }
        public int SeekerId { get; set; }
        [ForeignKey("SeekerId")]
        public JobSeeker seeker { get; set; }
        public int jobId { get; set; }
        [ForeignKey("jobId")]
        public JobPost jobPost { get; set; }

    }
}