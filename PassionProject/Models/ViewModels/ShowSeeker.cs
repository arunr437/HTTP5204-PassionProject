using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassionProject.Models.ViewModels
{
    //This ViewModel is used to display lists of JobPosts in the Show Seeker page. 
    public class ShowSeeker
    {
        public JobSeeker seeker { get; set; }
        public List<JobPost> posts { get; set; }

        public List<JobPost> postsList { get; set; }
    }
}