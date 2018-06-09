using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class ObtemModalidadeController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        [HttpPost]
        public List<GC_Modalidade> Post([FromBody]GC_Academia value)
        {
            return (from item in this.db.GC_Modalidade
                    where item.GC_AcademiaId == value.Id
                    select item).ToList();


        }
    }
}
