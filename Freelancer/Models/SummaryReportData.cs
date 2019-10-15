using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Freelancer.Models
{
    public class SummaryReportData
    {
        [Display(Name = "Market Share")]
        public double marketShare { get; set; }

        [Display(Name = "Market Revenue")]
        public double marketRevenue { get; set; }

        [Display(Name = "Total Freelancers")]
        public int numFreelancers { get; set; }

        [Display(Name = "Services Rendered")]
        public int servicesRendered { get; set; }

        [Display(Name = "Serviced Customers")]
        public int totalCustomers { get; set; }

        [Display(Name = "Weekly Earnings")]
        public double weeklyEarnings { get; set; }

        [Display(Name = "Total Earnings")]
        public double totalEarnings { get; set; }
    }
}