using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class AdicionaMensalidadeUsuarioController : ApiController
    {


        private GymControlContext db = new GymControlContext();

        [HttpPost]
        [Authorize]
        public Boolean Post([FromBody]dynamic value)
        {
            Int32 oGC_UsuarioId = value.GC_UsuarioId;
            Int32 oGC_MensalidadeId = value.GC_MensalidadeId;

            GC_Usuario oGC_Usuario = (from item in this.db.GC_Usuario
                                      where item.Id == oGC_UsuarioId
                                      select item).FirstOrDefault();

            if (oGC_Usuario == null) { return false; }

            GC_Mensalidade oGC_Mensalidade = (from item in this.db.GC_Mensalidade
                                              where item.Id == oGC_MensalidadeId
                                              select item).FirstOrDefault();

            if (oGC_Mensalidade == null) { return false; }

            oGC_Usuario.Mensalidades = new Collection<GC_Mensalidade>();
            oGC_Usuario.Mensalidades.Add(oGC_Mensalidade);
            db.SaveChangesAsync();
            return true;

        }
    }
}
