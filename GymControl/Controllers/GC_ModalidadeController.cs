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
    public class GC_ModalidadeController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        // GET: api/GC_Modalidade
        public IQueryable<GC_Modalidade> GetGC_Modalidade()
        {
            return db.GC_Modalidade;
        }

        // GET: api/GC_Modalidade/5
        [ResponseType(typeof(GC_Modalidade))]
        public async Task<IHttpActionResult> GetGC_Modalidade(int id)
        {
            GC_Modalidade gC_Modalidade = await db.GC_Modalidade.FindAsync(id);
            if (gC_Modalidade == null)
            {
                return NotFound();
            }

            return Ok(gC_Modalidade);
        }

        // PUT: api/GC_Modalidade/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGC_Modalidade(int id, GC_Modalidade gC_Modalidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gC_Modalidade.Id)
            {
                return BadRequest();
            }

            db.Entry(gC_Modalidade).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GC_ModalidadeExists(id))
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

        // POST: api/GC_Modalidade
        [ResponseType(typeof(GC_Modalidade))]
        public async Task<IHttpActionResult> PostGC_Modalidade(GC_Modalidade gC_Modalidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GC_Modalidade.Add(gC_Modalidade);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = gC_Modalidade.Id }, gC_Modalidade);
        }

        // DELETE: api/GC_Modalidade/5
        [ResponseType(typeof(GC_Modalidade))]
        public async Task<IHttpActionResult> DeleteGC_Modalidade(int id)
        {
            GC_Modalidade gC_Modalidade = await db.GC_Modalidade.FindAsync(id);
            if (gC_Modalidade == null)
            {
                return NotFound();
            }

            db.GC_Modalidade.Remove(gC_Modalidade);
            await db.SaveChangesAsync();

            return Ok(gC_Modalidade);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GC_ModalidadeExists(int id)
        {
            return db.GC_Modalidade.Count(e => e.Id == id) > 0;
        }
    }
}