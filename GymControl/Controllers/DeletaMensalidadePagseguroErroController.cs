using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class DeletaMensalidadePagseguroErroController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        [HttpPost]
        [Authorize]
        public Boolean Post([FromBody]GC_Usuario gc_Usuario)
        {
            // Mensalidades
            db.Database.ExecuteSqlCommand("proc_delete_mensalidade_errada " + gc_Usuario.Id);
            return true;
        }
    }
}
