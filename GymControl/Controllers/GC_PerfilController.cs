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
    public class GC_PerfilController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        // GET: api/GC_Perfil
        public IQueryable<GC_Perfil> GetGC_Perfil()
        {
            return db.GC_Perfil;
        }

        // GET: api/GC_Perfil/5
        [ResponseType(typeof(GC_Perfil))]
        public async Task<IHttpActionResult> GetGC_Perfil(int id)
        {
            GC_Perfil gC_Perfil = await db.GC_Perfil.FindAsync(id);
            if (gC_Perfil == null)
            {
                return NotFound();
            }

            return Ok(gC_Perfil);
        }

        // PUT: api/GC_Perfil/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGC_Perfil(int id, GC_Perfil gC_Perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gC_Perfil.Id)
            {
                return BadRequest();
            }

            db.Entry(gC_Perfil).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GC_PerfilExists(id))
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

        // POST: api/GC_Perfil
        [ResponseType(typeof(GC_Perfil))]
        public async Task<IHttpActionResult> PostGC_Perfil(GC_Perfil gC_Perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GC_Perfil.Add(gC_Perfil);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = gC_Perfil.Id }, gC_Perfil);
        }

        // DELETE: api/GC_Perfil/5
        [ResponseType(typeof(GC_Perfil))]
        public async Task<IHttpActionResult> DeleteGC_Perfil(int id)
        {
            GC_Perfil gC_Perfil = await db.GC_Perfil.FindAsync(id);
            if (gC_Perfil == null)
            {
                return NotFound();
            }

            db.GC_Perfil.Remove(gC_Perfil);
            await db.SaveChangesAsync();

            return Ok(gC_Perfil);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GC_PerfilExists(int id)
        {
            return db.GC_Perfil.Count(e => e.Id == id) > 0;
        }
    }
}