using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Freelancer.Models;

namespace Freelancer.Controllers
{
    public class BookingController : Controller
    {
        private FreelanceDbContext db = new FreelanceDbContext();

        // GET: Booking
       public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["memberId"].ToString());

            var bookings = db.ServiceRequests.Where(a => a.customerID == id).ToList();

            return View(bookings);
        }
    }
}