using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class MinhaInformacoesController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        [HttpPost]
        public GC_Usuario Post([FromBody]GC_Usuario value)
        {
            // busca usuario    
            GC_Usuario oGC_Usuario = (from item in db.GC_Usuario
                                      where item.CPF == value.CPF
                                      select item).FirstOrDefault();

            return oGC_Usuario;
        }
    }
}
