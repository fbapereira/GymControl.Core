using GymControl.Models;
using GymControl.pagseguro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class GerarBoletosController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        [Authorize]
        [HttpPost]
        public Boolean Post([FromBody]List<GC_Mensalidade> value)
        {
            value = value.OrderBy(x => x.Vencimento).ToList<GC_Mensalidade>();

            List<GC_PagSeguroPagamento> lstGC_PagSeguroPagamento = new GeradorBoleto().GerarBoletos(value);

            Int32 UsuarioId = value[0].GC_UsuarioId;
            GC_Usuario oGC_Usuario = (from item in this.db.GC_Usuario
                                      where item.Id == UsuarioId
                                      select item).FirstOrDefault();


            if (lstGC_PagSeguroPagamento == null || lstGC_PagSeguroPagamento.Count == 0)
            {
                return false;
            }

            for (int i = 0; i < value.Count; i++)
            {
                lstGC_PagSeguroPagamento[i].GC_MensalidadeId = value[i].Id;
            }

            db.GC_PagSeguroPagamento.AddRange(lstGC_PagSeguroPagamento);
            db.SaveChangesAsync();
            return true;

        }

    }
}
