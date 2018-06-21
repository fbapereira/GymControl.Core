using GymControl.core;
using GymControl.Models;
using GymControl.paposms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace GymControl.Controllers
{
    public class EnviaBoletoSMSController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        [HttpPost]
         public bool Post([FromBody]GC_Mensalidade value)
        {
            value = (from item in db.GC_Mensalidade
                     where item.Id == value.Id
                     select item).FirstOrDefault();

            GC_Usuario oGC_Usuario = (from item in db.GC_Usuario
                                      where item.Id == value.GC_UsuarioId
                                      select item).FirstOrDefault();

            GC_Academia OGC_Academia = (from item in db.GC_Academia
                                        where item.Id == value.GC_AcademiaId
                                        select item).FirstOrDefault();


            GC_PagSeguroPagamento oGC_PagSeguroPagamento = (from item in db.GC_PagSeguroPagamento
                                                            where item.GC_MensalidadeId == value.Id
                                                            select item).FirstOrDefault();

            if (oGC_Usuario.Telefone == null) { return false; }

            String message = "Olá {0}! Seu boleto com vencimento para {1} referente a academia {3} pode ser impresso em {2}";

            message = message.Replace("{0}", oGC_Usuario.Nome);
            message = message.Replace("{1}", value.Vencimento.ToString("dd/MM/yyyy"));
            message = message.Replace("{2}", "http://basicflux.com/#/eu");
            message = message.Replace("{3}", OGC_Academia.Nome);

            new PapoSms().EnviarMensalidade(oGC_Usuario.Telefone, message);
            return true;
        }
    }
}
