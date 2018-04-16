using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymControl.core
{
    public class Notification
    {

        private GymControlContext db = new GymControlContext();

        public void SendBoletoXDias(Int32 dias)
        {

            List<Notification_Response> lstNotification_Response = db.Database.SqlQuery<Notification_Response>("proc_select_boleto " + dias.ToString()).ToList();
            lstNotification_Response.ForEach((x) =>
            {
                DateTime oDt = Convert.ToDateTime(x.Vencimento);
                new Mailer().PreVencimento(x.email, x.nome, oDt.ToString("dd/MM/yyyy"), x.barcode, x.Link, dias.ToString());
                GC_Mensalidade oGC_Mensalidade = (from item in db.GC_Mensalidade
                                                  where item.Id == x.Id
                                                  select item).FirstOrDefault();

                if (dias == 5) oGC_Mensalidade.IsAvisoCinco = true;
                if (dias == 3) oGC_Mensalidade.IsAvisoTres = true;
                if (dias == 1) oGC_Mensalidade.IsAvisoUm = true;
            });
            db.SaveChanges();
        }
    }

    public class Notification_Response
    {
        public Int32 Id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string barcode { get; set; }
        public string Link { get; set; }
        public DateTime? Vencimento { get; set; }
    }
}