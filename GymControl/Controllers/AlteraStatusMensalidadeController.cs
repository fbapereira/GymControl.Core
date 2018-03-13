using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class AlteraStatusMensalidadeController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        [HttpPost]
        public Boolean Post([FromBody]dynamic value)
        {
            Int32 oGC_StatusId = value.GC_StatusId;
            Int32 oGC_MensalidadeId = value.GC_MensalidadeId;

            GC_MensalidadeStatus oGC_MensalidadeStatus = (from item in this.db.GC_MensalidadeStatus
                                                          where item.Id == oGC_StatusId
                                                          select item).FirstOrDefault();

            if (oGC_MensalidadeStatus == null) { return false; }

            GC_Mensalidade oGC_Mensalidade = (from item in this.db.GC_Mensalidade
                                              where item.Id == oGC_MensalidadeId
                                              select item).FirstOrDefault();

            if (oGC_Mensalidade == null) { return false; }

            oGC_Mensalidade.GC_MensalidadeStatusId = oGC_MensalidadeStatus.Id;
            db.SaveChangesAsync();
            return true;

        }
    }
}
