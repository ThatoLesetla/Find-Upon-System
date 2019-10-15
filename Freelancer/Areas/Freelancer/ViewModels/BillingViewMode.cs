using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Freelancer.Models;

namespace Freelancer.Areas.Freelancer.ViewModels
{
    public class BillingViewMode : HomeModel
    {
        public IEnumerable<Invoice> invoices { get; set; }
        public IEnumerable<string> customers { get; set; }
        public IEnumerable<int> serviceRequests { get; set; }

    }
}