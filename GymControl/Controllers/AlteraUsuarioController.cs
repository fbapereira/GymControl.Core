using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class AlteraUsuarioController : ApiController
    {

        private GymControlContext db = new GymControlContext();

        [HttpPost]
        [Authorize]
        public Boolean Post([FromBody]GC_Usuario gC_Usuario)
        {


            List<GC_Usuario> lst = (from item in db.GC_Usuario
                                    where (item.CPF == gC_Usuario.CPF ||
                                    item.Email == gC_Usuario.Email ||
                                    item.Login == gC_Usuario.Login) && item.IsActive && item.Id != gC_Usuario.Id
                                    select item).ToList();

            if (lst.Count > 0)
            {
                throw new Exception("Dados Duplicados");
            }


            GC_Usuario oGC_Usuario = (from item in db.GC_Usuario
                                      where item.Id == gC_Usuario.Id
                                      select item).FirstOrDefault();

            oGC_Usuario.Login = gC_Usuario.Login;
            oGC_Usuario.CPF = gC_Usuario.CPF;
            oGC_Usuario.Nome = gC_Usuario.Nome;
            oGC_Usuario.Email = gC_Usuario.Email;
            oGC_Usuario.Senha = gC_Usuario.Senha;
            oGC_Usuario.Telefone = gC_Usuario.Telefone;

            db.SaveChangesAsync();

            return true;
        }
    }
}
