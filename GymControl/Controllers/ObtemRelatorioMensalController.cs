using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class ObtemRelatorioMensalController : ApiController
    {

        private GymControlContext db = new GymControlContext();

        [HttpPost]
        public List<ObtemRelatorioMensal_Response> Post([FromBody]dynamic value)
        {
            var a = db.Database.SqlQuery<ObtemRelatorioMensal_Response>("proc_mensalidade").ToList();
            return a;
        }
    }

    public class ObtemRelatorioMensal_Response
    {
        public String nome { get; set; }
        public String email { get; set; }
        public DateTime? vencimento { get; set; }
        public Decimal? valor { get; set; }
        public String status { get; set; }
    }
}
