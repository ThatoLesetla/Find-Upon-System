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
using System.Text;
using System.IO;

namespace Freelancer.Controllers
{
    public class FreelancerClientsController : Controller
    {
        private FreelanceDbContext db = new FreelanceDbContext();

        // GET: FreelancerClients
        public async Task<ActionResult> Index()
        {
            var freelancerClients = db.FreelancerClients.Include(f => f.Department);
            return View(await freelancerClients.ToListAsync());
            
        }

        // GET: FreelancerClients/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreelancerClient freelancerClient = await db.FreelancerClients.FindAsync(id);
            if (freelancerClient == null)
            {
                return HttpNotFound();
            }
            return View(freelancerClient);
        }

        // GET: FreelancerClients/Create
        public ActionResult Create()
        {
            ViewBag.occupation = new SelectList(db.Departments, "departmentCode", "departmentName");
            return View();
        }

        // POST: FreelancerClients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "freelancerID,freelancerName,freelancerSurname,freelancerEmail,freelancerPhone,freelancerAddress,city,postalCode,freelancerWebsite,occupation,bio,imageURL, ImageFile")] FreelancerClient freelancerClient)
        {

            if (ModelState.IsValid)
            {
               try
                {
                    string fileName = Path.GetFileNameWithoutExtension(freelancerClient.ImageFile.FileName);
                    string extension = Path.GetExtension(freelancerClient.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                    freelancerClient.imageURL = "~/images/" + fileName;

                    fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
                    freelancerClient.ImageFile.SaveAs(fileName);

                    db.FreelancerClients.Add(freelancerClient);
                    await db.SaveChangesAsync();

                    return RedirectToAction("Create", "Users", new { newUserId = freelancerClient.freelancerID, role = "member" });

                }
                catch (Exception Ex)
                {
                    ViewBag.ErrorMessage = Ex.Message;
                    return View("Error");
                }
            }

            ViewBag.occupation = new SelectList(db.Departments, "departmentCode", "departmentName", freelancerClient.occupation);
            return View(freelancerClient);
        }

        // GET: FreelancerClients/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreelancerClient freelancerClient = await db.FreelancerClients.FindAsync(id);
            if (freelancerClient == null)
            {
                return HttpNotFound();
            }
            ViewBag.occupation = new SelectList(db.Departments, "departmentCode", "departmentName", freelancerClient.occupation);
            return View(freelancerClient);
        }

        // POST: FreelancerClients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "freelancerID,freelancerName,freelancerSurname,freelancerEmail,freelancerPhone,freelancerAddress,city,postalCode,freelancerWebsite,occupation,bio,imageURL")] FreelancerClient freelancerClient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(freelancerClient).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.occupation = new SelectList(db.Departments, "departmentCode", "departmentName", freelancerClient.occupation);
            return View(freelancerClient);
        }

        // GET: FreelancerClients/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreelancerClient freelancerClient = await db.FreelancerClients.FindAsync(id);
            if (freelancerClient == null)
            {
                return HttpNotFound();
            }
            return View(freelancerClient);
        }

        // POST: FreelancerClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FreelancerClient freelancerClient = await db.FreelancerClients.FindAsync(id);
            db.FreelancerClients.Remove(freelancerClient);
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
