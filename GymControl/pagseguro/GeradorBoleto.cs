using GymControl.core;
using GymControl.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;

namespace GymControl.pagseguro
{
    public class GeradorBoleto
    {
        private GymControlContext db = new GymControlContext();

        String sBody = @"
            {
        'reference': '#Mensalidade_ID#',
        'firstDueDate': '#FirstDueDate#',
        'numberOfPayments': '#numberOfPayments#',
        'periodicity': 'monthly',
        'amount': '#amount#',
        'instructions': 'juros de 1% ao dia e mora de 5,00',
        'description': 'Pagamento da #AcademiaNome#',
        'customer': {
            'document': {
                'type': 'CPF',
                'value': '#CPF#'
            },
            'name': '#Name#',
            'email': '#Email#',
            'phone': {
                'areaCode': '11',
                'number': '99999999'
            },
            'address': {
                'postalCode': '06065120',
                'street': 'Av. Capistrano de Abreu',
                'number': '486',
                'district': 'Osasco',
                'city': 'Sao Paulo',
                'state': 'SP'
            }
        }
    }";


        public List<GC_PagSeguroPagamento> GerarBoletos(List<GC_Mensalidade> oGC_Mensalidade)
        {
            String url = System.Configuration.ConfigurationManager.AppSettings["pagSeguro_Boleto"];
            Int32 idMensalidade = oGC_Mensalidade[0].Id;

            GC_Mensalidade targetGC_Mensalidade = (from item in db.GC_Mensalidade
                                                   where item.Id == idMensalidade
                                                   select item).FirstOrDefault();

            GC_Usuario oGC_Usuario = (from item in db.GC_Usuario
                                      where item.Id == targetGC_Mensalidade.GC_UsuarioId
                                      select item).FirstOrDefault();

            GC_Academia oGC_Academia = (from item in db.GC_Academia
                                        where item.Id == targetGC_Mensalidade.GC_AcademiaId
                                        select item).FirstOrDefault();


            String cpf = oGC_Usuario.CPF.Split('.').Aggregate((current, next) => current + "" + next).Split('-').Aggregate((current, next) => current + "" + next);

            String oBody = sBody.Replace("#Mensalidade_ID#", oGC_Mensalidade[0].Id.ToString());
            oBody = oBody.Replace("#FirstDueDate#", targetGC_Mensalidade.Vencimento.ToString("yyyy-MM-dd"));
            oBody = oBody.Replace("#amount#", (targetGC_Mensalidade.Valor - 1).ToString());
            oBody = oBody.Replace("#numberOfPayments#", oGC_Mensalidade.Count.ToString());
            oBody = oBody.Replace("#CPF#", cpf);
            oBody = oBody.Replace("#Name#", oGC_Usuario.Nome);
            oBody = oBody.Replace("#Email#", "fake_" + oGC_Usuario.Email);
            oBody = oBody.Replace("#AcademiaNome#", oGC_Academia.Nome);

            oBody = oBody.Split('\'').Aggregate((current, next) => current + "\"" + next);

            url = url.Replace("#token#", oGC_Academia.Token);
            url = url.Replace("#email#", oGC_Academia.Email);

            using (var client = new HttpClient())
            {

                var httpContent = new StringContent(oBody, Encoding.UTF8, "application/json");
                var response = client.PostAsync(url, httpContent).Result;


                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;

                    dynamic myClass = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseString);

                    List<dynamic> boletos = myClass.boletos.ToObject<List<dynamic>>();

                    List<GC_PagSeguroPagamento> lstGC_PagSeguroPagamento = new List<GC_PagSeguroPagamento>();

                    boletos.ForEach((x) =>
                    {
                        GC_PagSeguroPagamento oGC_PagSeguroPagamento = new GC_PagSeguroPagamento();
                        oGC_PagSeguroPagamento.BarCode = x.barcode;
                        oGC_PagSeguroPagamento.Code = x.code;
                        oGC_PagSeguroPagamento.Link = x.paymentLink;
                        oGC_PagSeguroPagamento.DueDate = x.dueDate;

                        lstGC_PagSeguroPagamento.Add(oGC_PagSeguroPagamento);
                    });
                    lstGC_PagSeguroPagamento = lstGC_PagSeguroPagamento.OrderBy(x => x.DueDate).ToList();
                    return lstGC_PagSeguroPagamento;
                }
                else
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    throw new Exception(responseString);
                }
            }

            return null;
            //var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://ws.pagseguro.uol.com.br/recurring-payment/boletos?email=fba_pereira@hotmail.com&token=32728DC4EF0A4615BD716904E82DA4AE");
            //httpWebRequest.ContentType = "application/json";
            //httpWebRequest.Method = "POST";

            //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            //{
            //    streamWriter.Write(oBody);
            //    streamWriter.Flush();
            //    streamWriter.Close();
            //}

            //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            //{
            //    var result = streamReader.ReadToEnd();

            //    dynamic myClass = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(result);

            //    List<dynamic> boletos = myClass.boletos.ToObject<List<dynamic>>();

            //    List<GC_PagSeguroPagamento> lstGC_PagSeguroPagamento = new List<GC_PagSeguroPagamento>();

            //    boletos.ForEach((x) =>
            //    {
            //        GC_PagSeguroPagamento oGC_PagSeguroPagamento = new GC_PagSeguroPagamento();
            //        oGC_PagSeguroPagamento.BarCode = x.barcode;
            //        oGC_PagSeguroPagamento.Code = x.code;
            //        oGC_PagSeguroPagamento.Link = x.paymentLink;
            //        oGC_PagSeguroPagamento.DueDate = x.dueDate;

            //        lstGC_PagSeguroPagamento.Add(oGC_PagSeguroPagamento);
            //    });
            //    lstGC_PagSeguroPagamento = lstGC_PagSeguroPagamento.OrderBy(x => x.DueDate).ToList();
            //    return lstGC_PagSeguroPagamento;
            //}
        }
    }
}