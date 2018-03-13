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
    public class GC_PagSeguroPagamentoController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        // GET: api/GC_PagSeguroPagamento
        public IQueryable<GC_PagSeguroPagamento> GetGC_PagSeguroPagamento()
        {
            return db.GC_PagSeguroPagamento;
        }

        // GET: api/GC_PagSeguroPagamento/5
        [ResponseType(typeof(GC_PagSeguroPagamento))]
        public async Task<IHttpActionResult> GetGC_PagSeguroPagamento(int id)
        {
            GC_PagSeguroPagamento gC_PagSeguroPagamento = await db.GC_PagSeguroPagamento.FindAsync(id);
            if (gC_PagSeguroPagamento == null)
            {
                return NotFound();
            }

            return Ok(gC_PagSeguroPagamento);
        }

        // PUT: api/GC_PagSeguroPagamento/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGC_PagSeguroPagamento(int id, GC_PagSeguroPagamento gC_PagSeguroPagamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gC_PagSeguroPagamento.Id)
            {
                return BadRequest();
            }

            db.Entry(gC_PagSeguroPagamento).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GC_PagSeguroPagamentoExists(id))
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

        // POST: api/GC_PagSeguroPagamento
        [ResponseType(typeof(GC_PagSeguroPagamento))]
        public async Task<IHttpActionResult> PostGC_PagSeguroPagamento(GC_PagSeguroPagamento gC_PagSeguroPagamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GC_PagSeguroPagamento.Add(gC_PagSeguroPagamento);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = gC_PagSeguroPagamento.Id }, gC_PagSeguroPagamento);
        }

        // DELETE: api/GC_PagSeguroPagamento/5
        [ResponseType(typeof(GC_PagSeguroPagamento))]
        public async Task<IHttpActionResult> DeleteGC_PagSeguroPagamento(int id)
        {
            GC_PagSeguroPagamento gC_PagSeguroPagamento = await db.GC_PagSeguroPagamento.FindAsync(id);
            if (gC_PagSeguroPagamento == null)
            {
                return NotFound();
            }

            db.GC_PagSeguroPagamento.Remove(gC_PagSeguroPagamento);
            await db.SaveChangesAsync();

            return Ok(gC_PagSeguroPagamento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GC_PagSeguroPagamentoExists(int id)
        {
            return db.GC_PagSeguroPagamento.Count(e => e.Id == id) > 0;
        }
    }
}