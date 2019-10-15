using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Freelancer.Models;
using System.Data;
using System.Data.Entity;

namespace Freelancer.Areas.Freelancer.Controllers
{
    public class BookingsController : Controller
    {
        FreelanceDbContext db = new FreelanceDbContext();

        // GET: Freelancer/Bookings
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ApproveBooking(int? id)
        {

            if(id == null)
            {
                return Content("ID is null");
            }

            try
            {
                ServiceRequest service = db.ServiceRequests.Find(id);

                if(service != null)
                {
                    service.verified = true;

                    db.Entry(service).State = EntityState.Modified;
                    db.SaveChanges();
                }
            } catch(Exception Ex)
            {
                ViewBag.ErrorMessage = Ex.Message;
                return View("Error");
            }
            return RedirectToAction("Index", "MemberHome");
        }

        public ActionResult CompletedBooking()
        {
            int id = Convert.ToInt32(Session["memberID"].ToString());
            var completedBookings = db.ServiceRequests.Where(a => a.verified == true && a.Job.freelancerID == id).ToList();

            return View(completedBookings);
        }

        public ActionResult FreelancerRequests()
        {
            
            int id = Convert.ToInt32(Session["memberID"].ToString());

            FreelancerClient freelancer = db.FreelancerClients.Find(id);
            var requests = db.ServiceRequests.Where(a => a.serviceDescription != "Service booked through available ads" && a.Category == freelancer.occupation).ToList();

            return View(requests);
        }
    }
}