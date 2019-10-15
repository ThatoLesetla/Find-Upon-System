using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Freelancer.Models;

namespace Freelancer.Controllers.Api
{
    public class ServiceRequestsController : ApiController
    {
        private FreelanceDbContext db = new FreelanceDbContext();

        // GET: api/ServiceRequests
        public IQueryable<ServiceRequest> GetServiceRequests()
        {
            return db.ServiceRequests;
        }

        // GET: api/ServiceRequests/5
        [ResponseType(typeof(ServiceRequest))]
        public async Task<IHttpActionResult> GetServiceRequest(int id)
        {
            ServiceRequest serviceRequest = await db.ServiceRequests.FindAsync(id);
            if (serviceRequest == null)
            {
                return NotFound();
            }

            return Ok(serviceRequest);
        }

        // PUT: api/ServiceRequests/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutServiceRequest(int id, ServiceRequest serviceRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceRequest.id)
            {
                return BadRequest();
            }

            db.Entry(serviceRequest).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceRequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ServiceRequests
        [ResponseType(typeof(ServiceRequest))]
        public async Task<IHttpActionResult> PostServiceRequest(ServiceRequest serviceRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiceRequests.Add(serviceRequest);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = serviceRequest.id }, serviceRequest);
        }

        // DELETE: api/ServiceRequests/5
        [ResponseType(typeof(ServiceRequest))]
        public async Task<IHttpActionResult> DeleteServiceRequest(int id)
        {
            ServiceRequest serviceRequest = await db.ServiceRequests.FindAsync(id);
            if (serviceRequest == null)
            {
                return NotFound();
            }

            db.ServiceRequests.Remove(serviceRequest);
            await db.SaveChangesAsync();

            return Ok(serviceRequest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceRequestExists(int id)
        {
            return db.ServiceRequests.Count(e => e.id == id) > 0;
        }
    }
}