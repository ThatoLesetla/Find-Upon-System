using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Freelancer.Models;

namespace Freelancer.Models
{
    public class CompetitiveSummary
    {
        FreelanceDbContext db = new FreelanceDbContext();
        private double _marketShare;
        private double _revenue;
        private int _freelancers;
        private FreelancerClient _freelancer;

      
        public CompetitiveSummary(FreelancerClient freelancerClient, double revenue = 0, int freelancers = 0, double marketShare = 0)
        {
            _freelancer = freelancerClient;
            _revenue = revenue;
            _freelancers = freelancers;
            _marketShare = marketShare;
        }

        public double getMarketShare()
        {
            return _marketShare;
        }

        public double getRevenue()
        {
            return _revenue;
        }

        public int getFreelancers()
        {
            return _freelancers;
        }

        public void calculateCompetitiveSummary()
        {
            setRevenue();
            settFreelancers();
            setMarketShare();

            return;
        }
        public void setMarketShare()
        {
            double freelancerClientRevenue = 0;

            foreach(var item in db.Invoices.ToList())
            {
                if(item.ServiceRequest.Job.freelancerID == _freelancer.freelancerID)
                {
                    freelancerClientRevenue += Convert.ToDouble(item.totalAmount);
                }
            }

            _marketShare = freelancerClientRevenue / _revenue * 100;
            
        }

        public void setRevenue()
        {
            double totalRevenue = 0;
            
            foreach(var item in db.Invoices.ToList())
            {
                totalRevenue += Convert.ToDouble(item.totalAmount);
            }

            _revenue = totalRevenue;
        }

        public void settFreelancers()
        {
            int totalFreelancers = db.FreelancerClients.Count();

            _freelancers = totalFreelancers;
        }


        ~CompetitiveSummary()
        {

        }
    }
}