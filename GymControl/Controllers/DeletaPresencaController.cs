using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class DeletaPresencaController : ApiController
    {

        private GymControlContext db = new GymControlContext();

        [HttpPost]
        public Boolean Post([FromBody]GC_Presenca gC_Presenca)
        {
            GC_Presenca oGC_Presenca = (from item in db.GC_Presenca
                                        where item.Id == gC_Presenca.Id
                                        select item).FirstOrDefault();

            db.GC_Presenca.Remove(oGC_Presenca);

            db.SaveChangesAsync();

            return true;
        }
    }
}
