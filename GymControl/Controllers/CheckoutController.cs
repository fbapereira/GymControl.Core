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
    public class CheckoutController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        [HttpPost]
        public GC_PagSeguroPagamento Post([FromBody]dynamic value)
        {
            Int32 idMensalidade = Convert.ToInt32(value.Id);
            GC_Mensalidade oMensalidade = new GC_Mensalidade();
            oMensalidade = (from item in db.GC_Mensalidade
                            where item.Id == idMensalidade
                            select item).FirstOrDefault();

            GC_Academia oGC_Academia = (from item in db.GC_Academia
                                        where oMensalidade.GC_AcademiaId == item.Id
                                        select item).FirstOrDefault();

            GC_Usuario oGC_Usuario = (from item in db.GC_Usuario
                                      where item.Id == oMensalidade.GC_UsuarioId
                                      select item).FirstOrDefault();

            GC_PagSeguroPagamento oPagSeguroPagamento = new Pagseguro().Checkout(oMensalidade, oGC_Usuario, oGC_Academia, value.token.ToString(), value.senderHash.ToString());

            oPagSeguroPagamento.GC_MensalidadeId = idMensalidade;

            db.GC_PagSeguroPagamento.Add(oPagSeguroPagamento);
            oMensalidade.GC_MensalidadeStatusId = 2;

            db.SaveChanges();



            oPagSeguroPagamento.GC_MensalidadeId = oMensalidade.GC_AcademiaId;

            return oPagSeguroPagamento;

        }
    }
}
