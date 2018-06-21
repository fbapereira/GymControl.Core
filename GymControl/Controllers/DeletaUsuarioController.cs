using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class DeletaUsuarioController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        [HttpPost]
        [Authorize]
        public Boolean Post([FromBody]GC_Usuario gC_Usuario)
        {



            GC_Usuario oGC_Usuario = (from item in db.GC_Usuario
                                      where item.Id == gC_Usuario.Id
                                      select item).FirstOrDefault();

            oGC_Usuario.IsActive = false;

            db.SaveChangesAsync();

            return true;
        }
    }
}
