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
    public class AdicionaUsuarioAcademiaController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        [HttpPost]
        [Authorize]
        public Boolean Post([FromBody]dynamic value)
        {
            Int32 GC_AcademiaId = value.GC_AcademiaId;
            Int32 GC_UsuarioId = value.GC_UsuarioId;


            GC_Academia oGC_Academia = (from item in this.db.GC_Academia
                                        where item.Id == GC_AcademiaId
                                        select item).FirstOrDefault();

            if (oGC_Academia == null) { return false; }

            GC_Usuario oGC_Usuario = (from item in this.db.GC_Usuario
                                      where item.Id == GC_UsuarioId
                                      select item).FirstOrDefault();

            if (oGC_Usuario == null) { return false; }

            oGC_Academia.Usuarios = new Collection<GC_Usuario>();
            oGC_Academia.Usuarios.Add(oGC_Usuario);
            db.SaveChangesAsync();
            return true;

        }
    }
}
