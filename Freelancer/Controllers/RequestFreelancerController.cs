using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Freelancer.Models;
using Freelancer.ViewModels;

namespace Freelancer.Controllers
{
    public class RequestFreelancerController : Controller
    {
        FreelanceDbContext db = new FreelanceDbContext();
        // GET: RequestFreelancer
        public ActionResult Index(string id)
        {

            if(id == null)
            {
                return HttpNotFound();
            }

            RequestFreelancerView freelancers = new RequestFreelancerView
            {
                categoeries = db.Departments.ToList(),
                ads = db.Jobs.Where(a => a.FreelancerClient.occupation == id).ToList()
            };

            return View(freelancers);
        }

        // GET: BookFreelancer
        public ActionResult book(int? id)
        {
            if(id == null)
            {
                return Content("ID is null");
            }

            Job job = db.Jobs.Find(id);

            return View(job);
        }

        [HttpPost]
        public ActionResult book([Bind(Include = "jobCode,jobDescription,freelancerID,hourlyRate,baseRate,imageURL")] Job job)
        {
            decimal callOutFee = 0;
            int customerID, jobCode;
            decimal vat;
        
            try
            {
                if(ModelState.IsValid)
                {

                    customerID = Convert.ToInt32(Session["memberid"].ToString());
                    jobCode = job.jobCode;
                    callOutFee = Convert.ToDecimal(job.baseRate * Convert.ToDecimal(7.5));
                    vat = Convert.ToDecimal(callOutFee * Convert.ToDecimal(0.014));

                    db.SP_FreelancerBooking(customerID, jobCode, 0, callOutFee, vat);
                }
            }catch(Exception Ex)
            {
                ViewBag.ErrorMessage = Ex.Message;

                return View("Error");
                
            }
            return RedirectToAction("Index", "Home");
        }
    }
}