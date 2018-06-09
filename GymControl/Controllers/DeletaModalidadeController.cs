using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class DeletaModalidadeController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        [HttpPost]
        public Boolean Post([FromBody]GC_Modalidade gC_Modalidade)
        {
            GC_Modalidade oGC_Modalidade = (from item in db.GC_Modalidade
                                            where item.Id == gC_Modalidade.Id
                                            select item).FirstOrDefault();

            oGC_Modalidade.IsActive = false;

            db.SaveChangesAsync();

            return true;
        }
    }
}
