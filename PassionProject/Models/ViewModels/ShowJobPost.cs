using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassionProject.Models.ViewModels
{
    //This ViewModel is used to display list of seekers in the Show JobPost page. 
    public class ShowJobPost
    {
        public JobPost jobPost { get; set; }
        public List<JobSeeker> seeker { get; set; }
        public List<JobSeeker> seekerList { get; set; }
    }
}