using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class ObtemPerfilController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        [HttpPost]
        [Authorize]
        public List<GC_Perfil> Post([FromBody]dynamic value)
        {
            Int32 UsuarioId = value.UsuarioId;
            Int32 AcademiaId = value.AcademiaId;

            return (from item in this.db.GC_Perfil
                    where item.GC_Usuarios.FirstOrDefault((x) => x.Id == UsuarioId) != null &&
                    item.GC_AcademiaId.Id == AcademiaId
                    select item).ToList();

        }

    }
}
