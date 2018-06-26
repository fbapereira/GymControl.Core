using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GymControl.core;
using GymControl.Models;
using GymControl.pagseguro;

namespace GymControl.Controllers
{
    public class GC_MensalidadeController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        // GET: api/GC_Mensalidade
        public IQueryable<GC_Mensalidade> GetGC_Mensalidade()
        {
            return (from item in db.GC_Mensalidade
                    where item.IsActive
                    select item).OrderBy(x => x.Vencimento);
        }

        // GET: api/GC_Mensalidade/5
        [ResponseType(typeof(GC_Mensalidade))]
        public async Task<IHttpActionResult> GetGC_Mensalidade(int id)
        {
            GC_Mensalidade gC_Mensalidade = await db.GC_Mensalidade.FindAsync(id);
            if (gC_Mensalidade == null)
            {
                return NotFound();
            }

            return Ok(gC_Mensalidade);
        }

        // PUT: api/GC_Mensalidade/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGC_Mensalidade(int id, GC_Mensalidade gC_Mensalidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gC_Mensalidade.Id)
            {
                return BadRequest();
            }

            db.Entry(gC_Mensalidade).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GC_MensalidadeExists(id))
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

        // POST: api/GC_Mensalidade
        [Authorize]
        [ResponseType(typeof(GC_Mensalidade))]
        public async Task<IHttpActionResult> PostGC_Mensalidade(GC_Mensalidade gC_Mensalidade)
        {
            db.GC_Mensalidade.Add(gC_Mensalidade);

            gC_Mensalidade.GC_MensalidadeStatusId = 1;
            gC_Mensalidade.IsActive = true;
            db.SaveChanges();

            new MensalidadeLogger().Log(gC_Mensalidade, (ClaimsIdentity)User.Identity, "Criada pelo usuario");

            return Ok(gC_Mensalidade);
        }

        // DELETE: api/GC_Mensalidade/5
        [ResponseType(typeof(GC_Mensalidade))]
        public async Task<IHttpActionResult> DeleteGC_Mensalidade(int id)
        {
            GC_Mensalidade gC_Mensalidade = await db.GC_Mensalidade.FindAsync(id);
            if (gC_Mensalidade == null)
            {
                return NotFound();
            }

            db.GC_Mensalidade.Remove(gC_Mensalidade);
            await db.SaveChangesAsync();

            return Ok(gC_Mensalidade);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GC_MensalidadeExists(int id)
        {
            return db.GC_Mensalidade.Count(e => e.Id == id) > 0;
        }
    }
}