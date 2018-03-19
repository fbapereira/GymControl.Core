using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class ObtemMensalidadeController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        [HttpPost]
        public List<GC_Mensalidade> Post([FromBody]GC_Usuario value)
        {
            GC_Usuario oGC_Usuario = (from item in this.db.GC_Usuario
                                      where item.Id == value.Id && item.IsActive
                                      select item).FirstOrDefault();

            this.db.Entry(oGC_Usuario).Collection(b => b.Mensalidades).Load();
            return (from item in oGC_Usuario.Mensalidades
                    where item.IsActive
                    select item).OrderBy(x => x.Vencimento).ToList<GC_Mensalidade>();
        }
    }
}
