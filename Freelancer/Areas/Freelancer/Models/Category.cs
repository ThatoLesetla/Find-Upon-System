using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freelancer.Areas.Freelancer.Models
{
    public class Category
    {
        public string code { get; set; }
        public string name { get; set; }
        public int requests { get; set; }
    }
}