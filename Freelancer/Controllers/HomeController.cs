using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Freelancer.Models;
using Freelancer.ViewModels;
using System.Web.Security;
using System.Data.Entity;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace Freelancer.Controllers
{
    public class HomeController : Controller 
    {
        private FreelanceDbContext db = new FreelanceDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            HomeModel homeModel = new HomeModel
            {
                departments = db.Departments.ToList(),
                trendigAds = db.Jobs.ToList().OrderByDescending(a => a.datePosted)
            };

            return View(homeModel);
        }


        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [Obsolete]
        public ActionResult Login(FormCollection userLogin)
        {

            // Form Collection Varialbes
            string password = FormsAuthentication.HashPasswordForStoringInConfigFile(userLogin["password"], "SHA1");
            string username = userLogin["username"];

            //try
            //{
            //var userObj = db.Users.Where(a => a.userName.Equals(username) && a.userPassword.Equals(password)).FirstOrDefault();
            var userObj = db.Users.Where(a => a.userName == username && a.userPassword == password).FirstOrDefault();
                
                if (userObj != null)
                {
       
                    Session["userName"] = userObj.userName.ToString();
                    Session["userId"] = userObj.id.ToString();
                    Session["userrole"] = userObj.userRole.ToString();
                    Session.Timeout = 1200;

                    if (userObj.userRole == "user")
                    {
                        Session["name"] = userObj.Customer.customerName.ToString();
                        Session["memberId"] = userObj.customerId.ToString();
                        Session["email"] = userObj.Customer.customerEmail.ToString();
                        Session["address"] = userObj.Customer.customerAddress.ToString();
                        return RedirectToAction("Index");
                    }
                    else if (userObj.userRole == "member")
                    {
                        Session["email"] = userObj.FreelancerClient.freelancerEmail.ToString();
                        Session["name"] = userObj.FreelancerClient.freelancerName.ToString();
                        Session["memberId"] = userObj.freelancerID.ToString();
                        Session["imageURL"] = userObj.FreelancerClient.imageURL.ToString();
                    
                        return Redirect("/Freelancer/MemberHome/Index");

                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    ViewBag.ErrorMessage = Ex.Message;
            //    return View("Error");
            //}

            ModelState.AddModelError("LoginError", "Invalid Login");
            return View();
        }

        public ActionResult LogOff()
        {
            Session.Abandon();

            return RedirectToAction("Login");
        }


        [HttpGet]
        public ActionResult ServiceRequest()
        {
            ViewBag.Category = new SelectList(db.Departments, "departmentCode", "departmentName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ServiceRequest([Bind(Include = "serviceDescription, Category, deliveryDate, budget")] ServiceRequest request, FormCollection form)
        {
         
            
            if(ModelState.IsValid)
            {
                try
                {
                    request.deliveryDate = Convert.ToDateTime(form["deliveryDate"]);
                    request.requestDate = DateTime.Now;
                    request.verified = false;
                    request.customerID = Convert.ToInt32(Session["memberId"].ToString());
                    request.verified = false;
                    request.isDeleted = false;

                    db.ServiceRequests.Add(request);
                    db.SaveChanges();

                    return RedirectToAction("Index");

                }
                catch (Exception Ex)
                {
                    ViewBag.ErrorMessage = Ex.Message;
                    return View("Error");
                }
            }

            ViewBag.Category = new SelectList(db.Departments, "departmentCode", "departmentName");
            return View();
        }
      
        public ActionResult weeklyNewsletter()
        {
            
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                string text = System.IO.File.ReadAllText(@"C:\Users\DELL\Downloads\web\index.html", Encoding.UTF8);

                mail.From = new MailAddress("allsafe.za@gmail.com");
                mail.To.Add("tlesetla6198@gmail.com");
                mail.Subject = "Test Mail - 1";

                mail.IsBodyHtml = true;
                string htmlBody;

                htmlBody = text;

                mail.Body = htmlBody;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("allsafe.za@gmail.com", "19982013@");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                //MessageBox.Show("mail Send");

            } catch (Exception Ex)
            {
                return Content("Mail failed" + Ex.Message);
            }

            return Content("Mail sent successfuly");
        }
        public ActionResult ComingSoon()
        {
            return View();
        }

    
    }
}