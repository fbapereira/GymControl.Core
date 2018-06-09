using GymControl.core;
using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class EnviaBoletoController : ApiController
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

            return new Mailer().Boleto(oGC_Usuario.Email, oGC_Usuario.Nome, value.Vencimento.ToString("dd/MM/yyyy"), oGC_PagSeguroPagamento.BarCode, oGC_PagSeguroPagamento.Link, OGC_Academia.Nome, OGC_Academia);

        }
    }
}
