using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Freelancer.Models;

namespace Freelancer.ViewModels
{
    public class RequestFreelancerView
    {
        public IEnumerable<string> locations { get; set; }
        public IEnumerable<Department> categoeries { get; set; }
        public IEnumerable<Job> ads { get; set; }

    }
}