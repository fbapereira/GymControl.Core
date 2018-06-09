using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class ObtemEmailController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        [HttpPost]
        public List<GC_Email> Post([FromBody]GC_Academia oGC_Academia)
        {
            return (from item in db.GC_Email
                    where item.GC_AcademiaId.Id == oGC_Academia.Id
                    select item)
                    .ToList()
                    .OrderBy(x => x.Id)
                    .Take(100)
                    .ToList(); ;
        }

    }
}
