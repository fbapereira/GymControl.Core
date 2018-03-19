﻿using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class DeletaMensalidadeController : ApiController
    {
        private GymControlContext db = new GymControlContext();

        [HttpPost]
        public Boolean Post([FromBody]GC_Mensalidade gC_Mensalidade)
        {



            GC_Mensalidade oGC_Mensalidade = (from item in db.GC_Mensalidade
                                      where item.Id == gC_Mensalidade.Id
                                      select item).FirstOrDefault();

            oGC_Mensalidade.IsActive = false;

            db.SaveChangesAsync();

            return true;
        }
    }
}
