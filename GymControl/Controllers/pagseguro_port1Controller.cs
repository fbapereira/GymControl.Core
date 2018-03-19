using GymControl.Models;
using GymControl.pagseguro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace GymControl.Controllers
{
    public class pagseguro_port1Controller : ApiController
    {
        private GymControlContext db = new GymControlContext();


        [HttpPost]
        public Boolean Post([FromUri]object instituicao)
        {
            var code = HttpContext.Current.Request.Params["notificationCode"];
            var type = HttpContext.Current.Request.Params["notificationType"];

            if (String.Equals("transaction", type))
            {
                GC_PagSeguroNotification oGC_PagSeguroNotification = new GC_PagSeguroNotification();
                oGC_PagSeguroNotification.Address = "PORT_1";
                oGC_PagSeguroNotification.Code = code;
                oGC_PagSeguroNotification.IsProcessed = false;
                db.GC_PagSeguroNotification.Add(oGC_PagSeguroNotification);
                oGC_PagSeguroNotification.Id = db.SaveChanges();

                new Pagseguro().ProcessNotification(code, "PORT_1");

                oGC_PagSeguroNotification.IsProcessed = true;
                db.SaveChanges();

                return true;
            }
            return false;
        }
    }
}
