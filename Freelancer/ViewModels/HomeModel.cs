using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Freelancer.Models;

namespace Freelancer.ViewModels
{
    public class HomeModel
    {
        public IEnumerable<Department> departments { get; set; }
        public IEnumerable<Job> trendigAds { get; set; }
    }
}