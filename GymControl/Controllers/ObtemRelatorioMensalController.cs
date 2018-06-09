using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;

namespace GymControl.Controllers
{
    //[Authorize]
    public class ObtemRelatorioMensalController : ApiController
    {

        private GymControlContext db = new GymControlContext();

        [HttpPost]
        public List<ObtemRelatorioMensal_Response> Post([FromBody]dynamic value)
        {
            dynamic mes = Convert.ToInt32(value.mes);
            dynamic academiaId = Convert.ToInt32(value.academia);

            var claims = ((ClaimsIdentity)Thread.CurrentPrincipal.Identity).Claims;

            var a = db.Database.SqlQuery<ObtemRelatorioMensal_Response>("proc_mensalidade @mes, @idAcademia", new SqlParameter("mes", mes), new SqlParameter("idAcademia", academiaId)).ToList();
            //var a = db.Database.SqlQuery<ObtemRelatorioMensal_Response>("proc_mensalidade @mes = " + mes.ToString()).ToList();

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
