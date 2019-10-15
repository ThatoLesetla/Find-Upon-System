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
using System.Web.Security;

namespace Freelancer.Controllers
{
    public class UsersController : Controller
    {
        private FreelanceDbContext db = new FreelanceDbContext();

        // GET: Users
        public async Task<ActionResult> Index()
        {
            var users = db.Users.Include(u => u.Customer).Include(u => u.FreelancerClient);
            return View(await users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
   
            ViewBag.userID = new SelectList(db.Customers, "customerID", "customerName");
            ViewBag.freelancerID = new SelectList(db.FreelancerClients, "freelancerID", "freelancerName");
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<ActionResult> Create([Bind(Include = "id,userID,userName,userPassword,emailStatus,registerDate,userRole,freelancerID")] User user, int newUserId, string role, FormCollection form)
        {
            string password = FormsAuthentication.HashPasswordForStoringInConfigFile(form["password"], "SHA1");


            try
            {
                user.registerDate = DateTime.Now;
                    user.emailStatus = false;
                    user.userPassword = password;

                    if (role == "user")
                    {
                        //db.Customers.Find(newUserId);
                        user.customerId = newUserId;
                        user.userRole = "user";

                    }
                    else if (role == "member")
                    {
                        user.freelancerID = newUserId;
                        user.userRole = "member";
                    }

                    db.Users.Add(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Login", "Home");

            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMessage = Ex.Message;
                return View("Error");
            }


            ViewBag.userID = new SelectList(db.Customers, "customerID", "customerName", user.customerId);
            ViewBag.freelancerID = new SelectList(db.FreelancerClients, "freelancerID", "freelancerName", user.freelancerID);
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.userID = new SelectList(db.Customers, "customerID", "customerName", user.customerId);
            ViewBag.freelancerID = new SelectList(db.FreelancerClients, "freelancerID", "freelancerName", user.freelancerID);
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,userID,userName,userPassword,emailStatus,registerDate,userRole,freelancerID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.userID = new SelectList(db.Customers, "customerID", "customerName", user.customerId);
            ViewBag.freelancerID = new SelectList(db.FreelancerClients, "freelancerID", "freelancerName", user.freelancerID);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            User user = await db.Users.FindAsync(id);
            db.Users.Remove(user);
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
