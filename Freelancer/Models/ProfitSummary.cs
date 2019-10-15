using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Freelancer.Models;

namespace Freelancer.Models
{
    public class ProfitSummary 
    {
        FreelanceDbContext db = new FreelanceDbContext();

        private int _freelancerID;
        private IEnumerable<ServiceRequest> _services;
        public double weeklyEarnings { get; set; } 
        public double totalEarnings { get; set; }
        public double highestMonthSales { get; set; }
        public string highestSellingMonth { get; set; }

        public ProfitSummary(int freelancerID = 0, IEnumerable<ServiceRequest> services = null)
        {
            _freelancerID = freelancerID;
            _services = services;

        }
        public void setProfitSummary()
        {
            double total = 0;
            double weeklyTotal = 0;
            TimeSpan numDays;
            var freelancer = db.FreelancerClients.Find(_freelancerID);
            string highestMonth = null;
            double highestSales = 0;

            HighestMonth(ref highestMonth, ref highestSales, _freelancerID);

            foreach (var item in db.Invoices.ToList())
            {
                if (item.ServiceRequest.Job.freelancerID == _freelancerID && item.ServiceRequest.verified == true)
                {
                    // Total cash earned
                    total = total + Convert.ToDouble(item.totalAmount);

                    // NumDays is used to calculate weekly sales
                    numDays = DateTime.Now.Subtract(item.invoiceDate);

                    if (numDays.TotalDays <= 7)
                    {
                        weeklyTotal = weeklyTotal + Convert.ToDouble(item.totalAmount);
                    }
                }
            }

            weeklyEarnings = weeklyTotal;
            totalEarnings = total;
            highestSellingMonth = highestMonth;
            highestMonthSales = highestSales;
        }

        public void HighestMonth(ref string highestMonth, ref double highestSales, int id)
        {
            double total;
            double highestTotal = 0;
            int month = 0;

            for (int i = 1; i <= 12; i++)
            {
                total = 0;

                var monthSales = db.Invoices.Where(a => a.invoiceDate.Month == i && a.ServiceRequest.Job.freelancerID == id).ToList();

                for (int m = 0; m < monthSales.Count(); m++)
                {
                    total = total + Convert.ToDouble(monthSales[m].totalAmount);
                }

                if (total > highestTotal)
                {
                    highestTotal = total;
                    month = i;
                }
            }

            switch (month)
            {
                case 1:
                    highestMonth = "January";
                    break;

                case 2:
                    highestMonth = "February";
                    break;

                case 3:
                    highestMonth = "March";
                    break;

                case 4:
                    highestMonth = "April";
                    break;

                case 5:
                    highestMonth = "May";
                    break;

                case 6:
                    highestMonth = "June";
                    break;

                case 7:
                    highestMonth = "July";
                    break;

                case 8:
                    highestMonth = "August";
                    break;

                case 9:
                    highestMonth = "September";
                    break;

                case 10:
                    highestMonth = "October";
                    break;

                case 11:
                    highestMonth = "November";
                    break;

                case 12:
                    highestMonth = "December";
                    break;
            }

            highestSales = highestTotal;
            return;
        }

        ~ProfitSummary()
        {

        }
    }
}