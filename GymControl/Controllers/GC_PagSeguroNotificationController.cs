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
using GymControl.Models;

namespace GymControl.Controllers
{
    public class GC_PagSeguroNotificationController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        // GET: api/GC_PagSeguroNotification
        public IQueryable<GC_PagSeguroNotification> GetGC_PagSeguroNotification()
        {
            return db.GC_PagSeguroNotification;
        }

        // GET: api/GC_PagSeguroNotification/5
        [ResponseType(typeof(GC_PagSeguroNotification))]
        public async Task<IHttpActionResult> GetGC_PagSeguroNotification(int id)
        {
            GC_PagSeguroNotification gC_PagSeguroNotification = await db.GC_PagSeguroNotification.FindAsync(id);
            if (gC_PagSeguroNotification == null)
            {
                return NotFound();
            }

            return Ok(gC_PagSeguroNotification);
        }

        // PUT: api/GC_PagSeguroNotification/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGC_PagSeguroNotification(int id, GC_PagSeguroNotification gC_PagSeguroNotification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gC_PagSeguroNotification.Id)
            {
                return BadRequest();
            }

            db.Entry(gC_PagSeguroNotification).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GC_PagSeguroNotificationExists(id))
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

        // POST: api/GC_PagSeguroNotification
        [ResponseType(typeof(GC_PagSeguroNotification))]
        public async Task<IHttpActionResult> PostGC_PagSeguroNotification(GC_PagSeguroNotification gC_PagSeguroNotification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GC_PagSeguroNotification.Add(gC_PagSeguroNotification);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = gC_PagSeguroNotification.Id }, gC_PagSeguroNotification);
        }

        // DELETE: api/GC_PagSeguroNotification/5
        [ResponseType(typeof(GC_PagSeguroNotification))]
        public async Task<IHttpActionResult> DeleteGC_PagSeguroNotification(int id)
        {
            GC_PagSeguroNotification gC_PagSeguroNotification = await db.GC_PagSeguroNotification.FindAsync(id);
            if (gC_PagSeguroNotification == null)
            {
                return NotFound();
            }

            db.GC_PagSeguroNotification.Remove(gC_PagSeguroNotification);
            await db.SaveChangesAsync();

            return Ok(gC_PagSeguroNotification);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GC_PagSeguroNotificationExists(int id)
        {
            return db.GC_PagSeguroNotification.Count(e => e.Id == id) > 0;
        }
    }
}