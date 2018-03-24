using GymControl.core;
using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class ResetarSenhaController : ApiController
    {
        private GymControlContext db = new GymControlContext();


        [HttpPost]
        public Boolean Post([FromBody]GC_Usuario value)
        {

            GC_Usuario oUsu = (from item in db.GC_Usuario
                               where item.CPF == value.CPF
                               select item).FirstOrDefault();

            if (oUsu == null)
            {
                throw new Exception("U2X_MessageUsuario não encontrado");
            }

            oUsu.Senha = GerarSenha();
            db.SaveChanges();


            new Mailer().RecuperaSenha(oUsu.Email, oUsu.Senha);
            return true;

        }

        private String GerarSenha()
        {
            string validar = "BasicFluxRenatoFelipe";

            StringBuilder strbld = new StringBuilder(100);
            Random random = new Random();
            while (strbld.Length < 20)
            {
                strbld.Append(validar[random.Next(validar.Length)]);
            }
            return strbld.ToString();
        }
    }
}
