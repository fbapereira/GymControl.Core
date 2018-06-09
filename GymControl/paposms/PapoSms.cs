using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace GymControl.paposms
{
    public class PapoSms
    {

        public void EnviarMensalidade(string numero, string mensagem)
        {
            string sUsuario = System.Configuration.ConfigurationManager.AppSettings["papoUsuario"];
            string sSenha = System.Configuration.ConfigurationManager.AppSettings["papoSenha"];

            var DataToSend = new NameValueCollection();
            DataToSend.Add("user", sUsuario);
            DataToSend.Add("pass", sSenha);
            DataToSend.Add("numbers", numero);
            DataToSend.Add("message", mensagem);
            DataToSend.Add("return_format", "json");

            using (WebClient ObjWebClient = new WebClient())
            {
                var ServiceUrl = "https://www.paposms.com/webservice/1.0/send/";
                byte[] ResultBytes = ObjWebClient.UploadValues(ServiceUrl, "POST", DataToSend);
                string ResultString = Encoding.UTF8.GetString(ResultBytes);
            }
        }
    }
}