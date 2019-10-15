using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Freelancer.Models;
using Freelancer.Areas.Freelancer.Models;
namespace Freelancer.Areas.Freelancer.ViewModels
{
    public class HomeModel
    {
        public IEnumerable<ServiceRequest> requests { get; set; }
        public int totalServices { get; set; }
        public int totalCustomers { get; set; }
        public double weekEarnings { get; set; }
        public double totalIncome { get; set; }
        public IEnumerable<Category> topCategories { get; set; }
        public string bestMonthSales { get; set; }
        public double monthSales { get; set; }
    }
}