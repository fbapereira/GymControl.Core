using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class AlteraModalidadeController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        [HttpPost]
        [Authorize]
        public Boolean Post([FromBody]GC_Modalidade value)
        {
            GC_Modalidade oGC_Modalidade = (from item in db.GC_Modalidade
                                            where item.Id == value.Id
                                            select item).FirstOrDefault();
            if (oGC_Modalidade == null)
            {
                return false;
            }
            oGC_Modalidade.Nome = value.Nome;

            db.SaveChangesAsync();
            return true;

        }
    }
}
