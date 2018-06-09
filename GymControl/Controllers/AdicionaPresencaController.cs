using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class AdicionaPresencaController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        [HttpPost]
        public Boolean Post([FromBody]GC_Presenca value)
        {
            this.db.GC_Presenca.Add(value);
            this.db.SaveChanges();
            return true;

        }
    }
}
