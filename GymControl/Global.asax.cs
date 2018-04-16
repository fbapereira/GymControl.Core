using GymControl.core;
using GymControl.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GymControl
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        Timer aTimer;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            new Task(() => { new Notification().SendBoletoXDias(5); }).Start();
            new Task(() => { new Notification().SendBoletoXDias(3); }).Start();
            new Task(() => { new Notification().SendBoletoXDias(1); }).Start();
            new Task(() => { new GymControl.pagseguro.Pagseguro().Proccess(); }).Start();

            aTimer = new System.Timers.Timer(60 * 60 * 1000); //one hour in milliseconds
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);


        }

        protected void Application_BeginRequest()
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");


            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, PATCH, DELETE, OPTIONS");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }


        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            new Notification().SendBoletoXDias(5);
            new Notification().SendBoletoXDias(3);
            new Notification().SendBoletoXDias(1);
            new GymControl.pagseguro.Pagseguro().Proccess();

        }
    }
}
