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
    public class GC_UsuarioController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        // GET: api/GC_Usuario
        public IQueryable<GC_Usuario> GetGC_Usuario()
        {
            return db.GC_Usuario;
        }

        // GET: api/GC_Usuario/5
        [ResponseType(typeof(GC_Usuario))]
        public async Task<IHttpActionResult> GetGC_Usuario(int id)
        {
            GC_Usuario gC_Usuario = await db.GC_Usuario.FindAsync(id);
            if (gC_Usuario == null)
            {
                return NotFound();
            }

            return Ok(gC_Usuario);
        }

        // PUT: api/GC_Usuario/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGC_Usuario(int id, GC_Usuario gC_Usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gC_Usuario.Id)
            {
                return BadRequest();
            }

            db.Entry(gC_Usuario).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GC_UsuarioExists(id))
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

        // POST: api/GC_Usuario
        [ResponseType(typeof(GC_Usuario))]
        public async Task<IHttpActionResult> PostGC_Usuario(GC_Usuario gC_Usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GC_Usuario.Add(gC_Usuario);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = gC_Usuario.Id }, gC_Usuario);
        }

        // DELETE: api/GC_Usuario/5
        [ResponseType(typeof(GC_Usuario))]
        public async Task<IHttpActionResult> DeleteGC_Usuario(int id)
        {
            GC_Usuario gC_Usuario = await db.GC_Usuario.FindAsync(id);
            if (gC_Usuario == null)
            {
                return NotFound();
            }

            db.GC_Usuario.Remove(gC_Usuario);
            await db.SaveChangesAsync();

            return Ok(gC_Usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GC_UsuarioExists(int id)
        {
            return db.GC_Usuario.Count(e => e.Id == id) > 0;
        }
    }
}