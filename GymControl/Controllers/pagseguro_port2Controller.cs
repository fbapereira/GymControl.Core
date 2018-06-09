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
    public class pagseguro_port2Controller : ApiController
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
                oGC_PagSeguroNotification.Address = "PORT_2";
                oGC_PagSeguroNotification.Code = code;
                oGC_PagSeguroNotification.IsProcessed = false;
                db.GC_PagSeguroNotification.Add(oGC_PagSeguroNotification);
                Int32 id = db.SaveChanges();
                //oGC_PagSeguroNotification.Id =
                new Pagseguro().ProcessNotification(code, "PORT_2");

                oGC_PagSeguroNotification.IsProcessed = true;
                db.SaveChanges();

                return true;
            }
            return false;
        }
    }
}
