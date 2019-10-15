using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Freelancer.Models;
using System.Web.UI.WebControls;
using System.IO;

namespace Freelancer.Controllers
{
    public class JobsController : Controller
    {
        #pragma warning disable IDE0044 // Add readonly modifier
        private FreelanceDbContext db = new FreelanceDbContext();
        #pragma warning restore IDE0044 // Add readonly modifier

        // GET: Jobs
        public async Task<ActionResult> Index()
        {
            var jobs = db.Jobs.Include(j => j.FreelancerClient);
            return View(await jobs.ToListAsync());
        }

        // GET: Jobs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await db.Jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            ViewBag.freelancerID = new SelectList(db.FreelancerClients, "freelancerID", "freelancerName");
            return View();
        }

        // POST: Jobs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "jobCode,jobDescription,freelancerID,hourlyRate,baseRate,imageURL")] Job job)
        {
            //string fileName, extension;

            if (ModelState.IsValid)
            {
                try
                {
                    //fileName = Path.GetFileNameWithoutExtension(job.imageFile.FileName);
                    //extension = Path.GetExtension(job.imageFile.FileName);
                    //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    //job.imageURL = "~/Images/" + fileName;
                    //fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    //job.imageFile.SaveAs(fileName);

                    db.Jobs.Add(job);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                    catch (Exception Ex)
                {
                    ViewBag.ErrorMessage = Ex.Message;
                    return View("Error");
                }
            }

            ViewBag.freelancerID = new SelectList(db.FreelancerClients, "freelancerID", "freelancerName", job.freelancerID);
            return View(job);
        }

        // GET: Jobs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await db.Jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.freelancerID = new SelectList(db.FreelancerClients, "freelancerID", "freelancerName", job.freelancerID);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "jobCode,jobDescription,freelancerID,hourlyRate,baseRate,imageURL")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.freelancerID = new SelectList(db.FreelancerClients, "freelancerID", "freelancerName", job.freelancerID);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await db.Jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Job job = await db.Jobs.FindAsync(id);
            db.Jobs.Remove(job);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
