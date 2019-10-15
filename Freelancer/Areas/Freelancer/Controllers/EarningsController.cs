using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Freelancer.Areas.Freelancer.ViewModels;
using Freelancer.Models;

namespace Freelancer.Areas.Freelancer.Controllers
{
    public class EarningsController : Controller
    {
        FreelanceDbContext db = new FreelanceDbContext();

        // GET: Freelancer/Earnings
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["memberID"].ToString());
            List<string> emailList = new List<string>();
            List<int> serviceIDList = new List<int>();
            foreach(var item in db.ServiceRequests)
            {
                if(item.jobCode != null)
                {
                    if (item.Job.freelancerID == id)
                    {

                        if(!emailList.Contains(item.Customer.customerEmail))
                        {
                            emailList.Add(item.Customer.customerEmail);
                        }

                        if(!serviceIDList.Contains(item.id))
                        {
                            serviceIDList.Add(item.id);
                        }
                    }
                }
            }
            BillingViewMode billing = new BillingViewMode()
            {

                invoices = db.Invoices.Where(a => a.ServiceRequest.Job.freelancerID == id).OrderByDescending(a => a.invoiceDate).ToList(),
                customers = emailList,
                serviceRequests = serviceIDList

            };

            ViewBag.CustomerEmails = new SelectList(emailList);
            ViewBag.ServiceIDs = serviceIDList;

            return View(billing);
        }

        [HttpGet]
        public ActionResult ViewInvoice(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }

            Invoice invoice = db.Invoices.Find(id);

            if(!ModelState.IsValid)
            {
                return HttpNotFound();

            }

            return View(invoice);
        }
    }
}