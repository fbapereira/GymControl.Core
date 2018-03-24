using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Xml;

namespace GymControl.pagseguro
{
    public class Pagseguro
    {
        private GymControlContext db = new GymControlContext();

        public String ObtemSessao(Int32 IdAcademia)
        {

            GC_Academia targetGC_Academia = (from item in db.GC_Academia
                                             where item.Id == IdAcademia
                                             select item).FirstOrDefault();

            String oBody = @"{
                                'email': '#email#',
                                'token': '#token#'
                    }";

            String sURL = "https://ws.sandbox.pagseguro.uol.com.br/v2/sessions?email=#email#&token=#token#";

            oBody = oBody.Replace("#email#", targetGC_Academia.Email);
            oBody = oBody.Replace("#token#", targetGC_Academia.Token);

            sURL = sURL.Replace("#email#", targetGC_Academia.Email);
            sURL = sURL.Replace("#token#", targetGC_Academia.Token);

            using (var client = new HttpClient())
            {

                var httpContent = new StringContent(oBody, Encoding.UTF8, "application/json");
                var response = client.PostAsync(sURL, httpContent).Result;


                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;


                    XmlDocument oDoc = new XmlDocument();
                    oDoc.LoadXml(responseString);
                    return oDoc.GetElementsByTagName("id")[0].InnerText;
                }
            }

            return null;
        }

        public GC_PagSeguroPagamento Checkout(GC_Mensalidade oMensalidade, GC_Usuario oAluno, GC_Academia oInstituicao, String token, String senderHash)
        {
            string urlPagSeguro = System.Configuration.ConfigurationManager.AppSettings["pagSeguroURL_CHECKOUT"];
            string urlNotification = System.Configuration.ConfigurationManager.AppSettings["notificationURL_" + oInstituicao.Id];

            String sXML = @"<?xml version='1.0' encoding='ISO-8859-1' standalone='yes'?>
                                <payment>
                                    <mode>default</mode>
                                    <method>creditCard</method>
                                    <sender>
                                        <name>#nome#</name>
                                        <email>#email#</email>
                                        <phone>
                                            <areaCode>11</areaCode>
                                            <number>30380000</number>
                                        </phone>
                                        <documents>
                                            <document>
                                                <type>CPF</type>
                                                <value>#cpf#</value>
                                            </document>
                                        </documents>
                                        <hash>#senderHash#</hash>
                                    </sender>
                                    <notificationURL>#notificationURL#</notificationURL>
                                    <currency>BRL</currency>
    
                                    <items>
                                        <item>
                                            <id>1</id>
                                            <description>#descricao#</description>
                                            <quantity>1</quantity>
                                            <amount>#valor#</amount>
                                        </item>
                                    </items>
                                    <extraAmount>0.00</extraAmount>
                                    <reference>R123456</reference>
                                    <shipping>
                                        <address>
                                            <street>Av. capistrano de Abreu</street>
                                            <number>486</number>
                                            <complement>1 andar</complement>
                                            <district>Jaguaribe</district>
                                            <city>Osasco</city>
                                            <state>SP</state>
                                            <country>BRA</country>
                                            <postalCode>06065120</postalCode>
                                        </address>
                                        <type>3</type>
                                        <cost>0.00</cost>
                                    </shipping>
                                    <creditCard>
                                        <token>#creditCardToken#</token>
                                        <installment>
                                            <quantity>1</quantity>
                                            <value>#valor#</value>
                                        </installment>
                                        <holder>
                                            <name>Nome No Cartao</name>
                                            <documents>
                                                <document>
                                                    <type>CPF</type>
                                                    <value>#cpf#</value>
                                                </document>
                                            </documents>
                                            <birthDate>20/10/1980</birthDate>
                                            <phone>
                                                <areaCode>11</areaCode>
                                                <number>999991111</number>
                                            </phone>
                                        </holder>
                                        <billingAddress>
                                            <street>Av. capistrano de Abreu</street>
                                            <number>486</number>
                                            <complement>1 andar</complement>
                                            <district>Jaguaribe</district>
                                            <city>Osasco</city>
                                            <state>SP</state>
                                            <country>BRA</country>
                                            <postalCode>06065120</postalCode>
                                        </billingAddress>
                                    </creditCard>
                                </payment>";




            sXML = sXML.Replace("#descricao#", "Mensalidade (" + oMensalidade.Vencimento.ToString("DD") + "/" + oMensalidade.Vencimento.ToString("YYYY") + ")");
            sXML = sXML.Replace("#valor#", Convert.ToInt32(oMensalidade.Valor).ToString("N2"));
            sXML = sXML.Replace("#valor#", Convert.ToInt32(oMensalidade.Valor).ToString("N2"));
            sXML = sXML.Replace("#nome#", oAluno.Nome);
            sXML = sXML.Replace("#email#", oAluno.Email);
            sXML = sXML.Replace("#cpf#", oAluno.CPF);
            sXML = sXML.Replace("#cpf#", oAluno.CPF);
            sXML = sXML.Replace("#reference#", oMensalidade.Id.ToString());
            sXML = sXML.Replace("#creditCardToken#", token);
            sXML = sXML.Replace("#senderHash#", senderHash);
            sXML = sXML.Replace("#notificationURL#", urlNotification);

            urlPagSeguro = urlPagSeguro.Replace("#emailInstituicao#", oInstituicao.Email);
            urlPagSeguro = urlPagSeguro.Replace("#token#", oInstituicao.Token);

            using (var client = new HttpClient())
            {

                var httpContent = new StringContent(sXML, Encoding.UTF8, "application/xml");
                var response = client.PostAsync(urlPagSeguro, httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;

                    // by calling .Result you are synchronously reading the result
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(responseString);

                    GC_PagSeguroPagamento oPagSeguroPagamento = new GC_PagSeguroPagamento();

                    XmlNodeList nodeList = xml.GetElementsByTagName("code");
                    oPagSeguroPagamento.Code = nodeList[0].InnerText;

                    nodeList = xml.GetElementsByTagName("date");
                    oPagSeguroPagamento.DueDate = nodeList[0].InnerText;

                    return oPagSeguroPagamento;
                }
            }
            return null;
        }

        public Boolean Proccess()
        {
            List<GC_PagSeguroNotification> lstNotifications = (from item in db.GC_PagSeguroNotification
                                                               where !item.IsProcessed
                                                               select item).ToList();
            lstNotifications.ForEach((x) => { this.ProcessNotification(x.Code, x.Address); });
            return true;
        }

        public Boolean ProcessNotification(String code, String port)
        {

            string idInstituicao = System.Configuration.ConfigurationManager.AppSettings["pagSeguro_" + port];
            GC_Academia oInstituicao = (from item in db.GC_Academia
                                        where item.Id.ToString() == idInstituicao
                                        select item).FirstOrDefault();

            string urlPagSeguro = System.Configuration.ConfigurationManager.AppSettings["pagSeguroURL_NOTIFICATION"];

            urlPagSeguro = urlPagSeguro.Replace("#email#", oInstituicao.Email);
            urlPagSeguro = urlPagSeguro.Replace("#token#", oInstituicao.Token);
            urlPagSeguro = urlPagSeguro.Replace("#code#", code);

            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>();
                var content = new FormUrlEncodedContent(values);
                var response = client.GetAsync(urlPagSeguro).Result;


                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;

                    // by calling .Result you are synchronously reading the result
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(responseString);

                    XmlNodeList nodeList = xml.GetElementsByTagName("status");
                    String status = nodeList[0].InnerText;

                    nodeList = xml.GetElementsByTagName("code");
                    String pagseguroCode = nodeList[0].InnerText;

                    GC_PagSeguroPagamento oGC_PagSeguroPagamento = (from item in db.GC_PagSeguroPagamento
                                                                    where item.Code == pagseguroCode
                                                                    select item).FirstOrDefault();

                    GC_Mensalidade oGC_Mensalidade = (from item in db.GC_Mensalidade
                                                      where item.Id == oGC_PagSeguroPagamento.GC_MensalidadeId
                                                      select item).FirstOrDefault();

                    oGC_Mensalidade.GC_MensalidadeStatusId = Convert.ToInt32(status);

                    db.SaveChanges();
                    return true;
                }
            }
            return true;
        }

    }
}