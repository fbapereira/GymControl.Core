using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class ObtemAcademiaUsuarioController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        [HttpPost]
        public List<GC_Academia> Post([FromBody]GC_Usuario value)
        {
            return (from item in this.db.GC_Academia
                    where item.Usuarios.FirstOrDefault((x) => x.Id == value.Id) != null
                    select item).ToList();

        }
    }
}
