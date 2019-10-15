using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Freelancer.Models;
using System.Data.Entity;
using System.Web.UI.WebControls;
using System.IO;

namespace Freelancer.Areas.Freelancer.Controllers
{
    public class PostJobController : Controller
    {
        FreelanceDbContext db = new FreelanceDbContext();

        // GET: Freelancer/PostJob
        public ActionResult Index()
        {
         
            int id = Convert.ToInt32(Session["memberId"].ToString());

            var adverts = db.Jobs.Where(a => a.freelancerID == id).ToList();

            return View(adverts);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "jobCode,jobDescription,freelancerID,hourlyRate,baseRate,imageURL")]Job newJob)
        public ActionResult Create(Job newJob)
        {
            int id = Convert.ToInt32(Session["memberId"].ToString());

            string fileName = Path.GetFileNameWithoutExtension(newJob.ImageFile.FileName);
            string extension = Path.GetExtension(newJob.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
            newJob.imageURL = "~/images/" + fileName;

            fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
            newJob.ImageFile.SaveAs(fileName);
            
            try
            {
                if(ModelState.IsValid)
                {
                    newJob.freelancerID = id;
                    newJob.datePosted = DateTime.Now;
                    db.Jobs.Add(newJob);
                    db.SaveChanges();

                    return RedirectToAction("Index");

                }
            }catch(Exception Ex)
            {
                ViewBag.ErrorMessage = Ex.Message;

                return View("Error");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }

            Job job = db.Jobs.Find(id);

            if(job == null)
            {
                return HttpNotFound();
            }

            return View(job);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "jobCode, jobDescription, freelancerID, hourlyRate, baseRate, imageURL")]Job job)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    db.Entry(job).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index", "MemberHome");
                }
            } catch(Exception Ex)
            {
                ViewBag.ErrorMessage = Ex.Message;

                return View("Error");
            }
            return View();
        }

        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }

            Job job = db.Jobs.Find(id);

            if(job == null)
            {
                return HttpNotFound();
            }

            return View(job);
        }

        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }

            Job job = db.Jobs.Find(id);

            if(job == null)
            {
                return HttpNotFound();
            }

            return View(job);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();

            return RedirectToAction("Index", "MemberHome");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}