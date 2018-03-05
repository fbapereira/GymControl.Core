using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class LoginController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        [HttpPost]
        public GC_Usuario Post([FromBody]GC_Usuario value)
        {
            GC_Usuario oGC_Usuario = (from item in this.db.GC_Usuario
                                      where item.Senha == value.Senha && (item.Email == value.Email || item.Login == value.Login)
                                      select item).FirstOrDefault();
            return oGC_Usuario;

        }
    }
}
