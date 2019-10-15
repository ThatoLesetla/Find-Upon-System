using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Freelancer.Models;

namespace Freelancer.ViewModels
{
    public class Categories
    {
        public IEnumerable<Department> category{ get; set;}
        public string categoryIcon { get; set; }

    }
}