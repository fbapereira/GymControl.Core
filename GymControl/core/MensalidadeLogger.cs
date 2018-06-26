using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Web;

namespace GymControl.core
{
    public class MensalidadeLogger
    {
        private GymControlContext db = new GymControlContext();

        public void Log(GC_Mensalidade gC_Mensalidade, ClaimsIdentity identity, string Obs)
        {
            try
            {
                GC_MensalidadeLog oGC_MensalidadeLog = new GC_MensalidadeLog();

                if (identity != null)
                {
                    Claim id = (from item in identity.Claims
                                where item.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"
                                select item).FirstOrDefault();
                    oGC_MensalidadeLog.GC_UsuarioId = Convert.ToInt32(id.Value);

                }

                oGC_MensalidadeLog.GC_MensalidadeId = gC_Mensalidade.Id;
                oGC_MensalidadeLog.GC_MensalidadeStatusId = gC_Mensalidade.GC_MensalidadeStatusId;
                oGC_MensalidadeLog.IsActive = gC_Mensalidade.IsActive;
                oGC_MensalidadeLog.logDate = DateTime.Now;
                oGC_MensalidadeLog.Observacao = Obs;

                db.GC_MensalidadeLog.Add(oGC_MensalidadeLog);
                db.SaveChanges();
            }
            catch (Exception e)
            {
            }
        }
    }
}
