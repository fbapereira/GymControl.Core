using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class ObtemPagseguroController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        [HttpPost]
        public GC_PagSeguroPagamento Post([FromBody]GC_Mensalidade value)
        {

            return (from item in this.db.GC_PagSeguroPagamento
                    where item.GC_MensalidadeId == value.Id
                    select item).FirstOrDefault();

        }

    }
}
