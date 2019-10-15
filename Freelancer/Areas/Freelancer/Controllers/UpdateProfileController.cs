using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Freelancer.Models;
using System.Data.Entity;
using System.Net;

namespace Freelancer.Areas.Freelancer.Controllers
{
    //[Authorize (Roles = RoleName.FreelanceMembership)]
    public class UpdateProfileController : Controller
    {

        FreelanceDbContext db = new FreelanceDbContext();

        // GET: Freelancer/UpdateProfile
        public ActionResult Index()
        {
           
            return View();
        }


       
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreelancerClient userObj = db.FreelancerClients.Find(id);

            if(userObj == null)
            {
                return HttpNotFound();
            }
            ViewBag.occupation = new SelectList(db.Departments, "departmentCode", "departmentName", userObj.occupation);

            return View(userObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "freelancerID,freelancerName,freelancerSurname,freelancerEmail,freelancerPhone,freelancerAddress,city,postalCode,freelancerWebsite,occupation,bio,imageURL")] FreelancerClient freelancer)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    freelancer.occupation = "CRP";
                    db.Entry(freelancer).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index", "MemberHome");
                }
            } catch(Exception Ex)
            {
                ViewBag.ErrorMessage = Ex.Message;
                return View("Error");
            }
            return Content("There's a error in this method");
        }


        [HttpGet]
        public ActionResult UserEdit(int? id)
        {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }

                var userObj = db.Users.Find(id);

                if (userObj == null)
                {
                    return HttpNotFound();
                }

            return View(userObj);
        }

        [HttpPost]
        public ActionResult UserEdit([Bind(Include = "id,userID,userName,userPassword,emailStatus,registerDate,userRole,freelancerID")] User user)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index", "MemberHome");
                }
            } catch(Exception Ex)
            {
                ViewBag.ErrorMessage = Ex.Message;
                return View("Error");
            }

            return View(user);
        }
    }
}