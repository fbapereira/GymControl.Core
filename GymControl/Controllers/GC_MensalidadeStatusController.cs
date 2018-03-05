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
    public class GC_MensalidadeStatusController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        // GET: api/GC_MensalidadeStatus
        public IQueryable<GC_MensalidadeStatus> GetGC_MensalidadeStatus()
        {
            return db.GC_MensalidadeStatus;
        }

        // GET: api/GC_MensalidadeStatus/5
        [ResponseType(typeof(GC_MensalidadeStatus))]
        public async Task<IHttpActionResult> GetGC_MensalidadeStatus(int id)
        {
            GC_MensalidadeStatus gC_MensalidadeStatus = await db.GC_MensalidadeStatus.FindAsync(id);
            if (gC_MensalidadeStatus == null)
            {
                return NotFound();
            }

            return Ok(gC_MensalidadeStatus);
        }

        // PUT: api/GC_MensalidadeStatus/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGC_MensalidadeStatus(int id, GC_MensalidadeStatus gC_MensalidadeStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gC_MensalidadeStatus.Id)
            {
                return BadRequest();
            }

            db.Entry(gC_MensalidadeStatus).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GC_MensalidadeStatusExists(id))
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

        // POST: api/GC_MensalidadeStatus
        [ResponseType(typeof(GC_MensalidadeStatus))]
        public async Task<IHttpActionResult> PostGC_MensalidadeStatus(GC_MensalidadeStatus gC_MensalidadeStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GC_MensalidadeStatus.Add(gC_MensalidadeStatus);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = gC_MensalidadeStatus.Id }, gC_MensalidadeStatus);
        }

        // DELETE: api/GC_MensalidadeStatus/5
        [ResponseType(typeof(GC_MensalidadeStatus))]
        public async Task<IHttpActionResult> DeleteGC_MensalidadeStatus(int id)
        {
            GC_MensalidadeStatus gC_MensalidadeStatus = await db.GC_MensalidadeStatus.FindAsync(id);
            if (gC_MensalidadeStatus == null)
            {
                return NotFound();
            }

            db.GC_MensalidadeStatus.Remove(gC_MensalidadeStatus);
            await db.SaveChangesAsync();

            return Ok(gC_MensalidadeStatus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GC_MensalidadeStatusExists(int id)
        {
            return db.GC_MensalidadeStatus.Count(e => e.Id == id) > 0;
        }
    }
}