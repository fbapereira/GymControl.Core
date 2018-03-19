using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class ObtemUsuariosAcademiaController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        [HttpPost]
        public List<GC_Usuario> Post([FromBody]GC_Academia value)
        {
            return (from item in this.db.GC_Usuario
                    where item.Academias.FirstOrDefault((x) => x.Id == value.Id) != null && item.IsActive
                    select item).ToList();

        }
    }
}
