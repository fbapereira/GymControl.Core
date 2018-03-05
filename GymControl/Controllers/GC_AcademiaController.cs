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
    public class GC_AcademiaController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        // GET: api/GC_Academia
        public IQueryable<GC_Academia> GetGC_Academia()
        {
            return db.GC_Academia;
        }

        // GET: api/GC_Academia/5
        [ResponseType(typeof(GC_Academia))]
        public async Task<IHttpActionResult> GetGC_Academia(int id)
        {
            GC_Academia gC_Academia = await db.GC_Academia.FindAsync(id);
            if (gC_Academia == null)
            {
                return NotFound();
            }

            return Ok(gC_Academia);
        }

        // PUT: api/GC_Academia/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGC_Academia(int id, GC_Academia gC_Academia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gC_Academia.Id)
            {
                return BadRequest();
            }

            db.Entry(gC_Academia).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GC_AcademiaExists(id))
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

        // POST: api/GC_Academia
        [ResponseType(typeof(GC_Academia))]
        public async Task<IHttpActionResult> PostGC_Academia(GC_Academia gC_Academia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GC_Academia.Add(gC_Academia);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = gC_Academia.Id }, gC_Academia);
        }

        // DELETE: api/GC_Academia/5
        [ResponseType(typeof(GC_Academia))]
        public async Task<IHttpActionResult> DeleteGC_Academia(int id)
        {
            GC_Academia gC_Academia = await db.GC_Academia.FindAsync(id);
            if (gC_Academia == null)
            {
                return NotFound();
            }

            db.GC_Academia.Remove(gC_Academia);
            await db.SaveChangesAsync();

            return Ok(gC_Academia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GC_AcademiaExists(int id)
        {
            return db.GC_Academia.Count(e => e.Id == id) > 0;
        }
    }
}