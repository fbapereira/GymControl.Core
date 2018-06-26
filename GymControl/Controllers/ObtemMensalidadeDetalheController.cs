using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class ObtemMensalidadeDetalheController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        //[Authorize]
        [HttpPost]
        public List<GC_MensalidadeLog> Post([FromBody]GC_Mensalidade value)
        {
            return (from item in this.db.GC_MensalidadeLog
                    where value.Id == item.GC_MensalidadeId
                    select item).ToList();
        }
    }
}
