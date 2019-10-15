using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Freelancer.Areas.Freelancer.ViewModels;
using System.Data.Entity;
using Freelancer.Models;
using Freelancer.Areas.Freelancer.Models;

namespace Freelancer.Areas.Freelancer.Controllers
{

   // [Authorize (Roles = RoleName.FreelanceMembership)]
    public class MemberHomeController : Controller
    {
        FreelanceDbContext db = new FreelanceDbContext();
       
        // GET: Freelancer/MemberHome
        [HttpGet]
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["memberId"].ToString());
            List<ServiceRequest> services = db.ServiceRequests.Where(a => a.Job.freelancerID == id && a.verified == true).ToList();

            ProfitSummary profitSummary = new ProfitSummary(id, services);

            profitSummary.setProfitSummary();

            List<Category> categories = new List<Category>();
            // Declare all available departments
            foreach (var item in db.Departments.ToList())
            {
                Category category = new Category();
                category.code = item.departmentCode;
                category.name = item.departmentName;

                foreach(var i in db.ServiceRequests)
                {
                    category.requests = db.ServiceRequests.Where(a => a.Job.FreelancerClient.occupation == category.code).Count();
                }

                categories.Add(category);

                
            }

            HomeModel homeModel = new HomeModel()
            {
                requests = db.ServiceRequests.Where(a => a.Job.freelancerID == id && a.verified == false).ToList(),
                totalServices = services.Count(),
                totalCustomers = services.GroupBy(a => a.customerID).Count(),
                totalIncome = profitSummary.totalEarnings,
                topCategories = categories,
                weekEarnings = profitSummary.weeklyEarnings,
                bestMonthSales = profitSummary.highestSellingMonth,
                monthSales = profitSummary.highestMonthSales
            };

            

            return View(homeModel);
        }

     

        public ActionResult Logout(string id)
        {
            Session.Abandon();
            
            return Redirect("/Home/Login");
        }

        public ActionResult ComingSoon()
        {

            return View();
        }

    }
}