using GymControl.Models;
using GymControl.pagseguro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    [Authorize]
    public class ObtemSessaoController : ApiController
    {
        [HttpPost]
        public String Post([FromBody]GC_Academia value)
        {
            return new Pagseguro().ObtemSessao(value.Id);
        }
    }
}
