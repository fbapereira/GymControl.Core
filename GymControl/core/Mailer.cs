using GymControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace GymControl.core
{
    public class Mailer
    {
        private static GymControlContext db = new GymControlContext();
        private void Log(MailMessage oMailMessage)
        {
            GC_Email oGC_Email = new GC_Email();

            oGC_Email.Corpo = oMailMessage.Body;
            oGC_Email.Data = DateTime.Now;
            oGC_Email.Email = oMailMessage.To[0].Address;
            oGC_Email.Titulo = oMailMessage.Subject;


            db.GC_Email.Add(oGC_Email);
            db.SaveChanges();

        }


        public bool RecuperaSenha(string email, string senha)
        {
            String body = "<html><head><style>html{line-height:1.5;font-family:\"Roboto\",sans-serif;font-weight:normal;color:rgba(0, 0, 0, 0.87)}</style></head><body style=\"margin: 0px\"><div style=\"height: 50px; background: black\"><center> <img style=\"height: 40px; margin - top:5px\" src=\"http://app.basicflux.com/img/logo_header.png\"/></center </div><div style=\"height:50px; margin-left:20%; width:60%;\"><h1 style=\"color:purple\">Nova Senha</h1><p> Você solicitiou uma nova senha no TheFlux! Sua nova senha é:</p><div style=\"height:50px; background:purple; color:white\"><center style=\"vertical-align: middle;line-height: 50px;\">{0}</center></div><p> Você pode trocar sua senha a qualquer momento, selecionando o menu \"Usuário\", então clicando na chave ao lado do seu nome.</p><p> Atenciosamente,</p><p> Equipe BasicFlux</p></div></body></html>";

            MailMessage message = new MailMessage();
            message.From = new MailAddress("contato@basicflux.com");

            message.To.Add(new MailAddress(email));

            message.Subject = "THEFLUX - Troca de Senha";
            body = body.Replace("{0}", senha);
            message.Body = body;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Send(message);
            this.Log(message);
            return true;

        }

        public bool ContaAReceber(string email, string conta, String valor)
        {
            String body = "<html><head><style>html{line-height:1.5;font-family:\"Roboto\",sans-serif;font-weight:normal;color:rgba(0, 0, 0, 0.87)}</style></head><body style=\"margin: 0px\"><div style=\"height: 50px; background: black\"><center> <img style=\"height: 40px; margin - top:5px\" src=\"http://app.basicflux.com/img/logo_header.png\" /></center</div><div style=\"height:50px; margin-left:20%; width:60%;\"><h1 style=\"color:purple\">Conta Atrasada</h1><p> Você registrou um pagamento ({0}) no TheFlux! E ele vence hoje:</p><div style=\"height:50px; background:purple; color:white\"><center style=\"vertical-align: middle;line-height: 50px;\">{1}</center></div><p> Não se esqueça de marcar a conta como paga.</p><p> Atenciosamente,</p><p> Equipe BasicFlux</p></div></body></html>";
            MailMessage message = new MailMessage();
            message.From = new MailAddress("contato@basicflux.com");

            message.To.Add(new MailAddress(email));

            message.Subject = "THEFLUX - Conta a Receber";
            body = body.Replace("{0}", conta);
            body = body.Replace("{1}", valor);
            message.Body = body;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Send(message);
            this.Log(message);
            return true;

        }

        public bool ContaAPagar(string email, string conta, String valor)
        {
            String body = "<html><head><style>html{line-height:1.5;font-family:\"Roboto\",sans-serif;font-weight:normal;color:rgba(0, 0, 0, 0.87)}</style></head><body style=\"margin: 0px\"><div style=\"height: 50px; background: black\"><center> <img style=\"height: 40px; margin - top:5px\" src=\"http://app.basicflux.com/img/logo_header.png\" /></center</div><div style=\"height:50px; margin-left:20%; width:60%;\"><h1 style=\"color:purple\">Conta Atrasada</h1><p> Você registrou uma conta ({0}) no TheFlux! E ela vence hoje:</p><div style=\"height:50px; background:purple; color:white\"><center style=\"vertical-align: middle;line-height: 50px;\">{1}</center></div><p> Não se esqueça de marcar a conta como paga.</p><p> Atenciosamente,</p><p> Equipe BasicFlux</p></div></body></html>";

            MailMessage message = new MailMessage();
            message.From = new MailAddress("contato@basicflux.com");

            message.To.Add(new MailAddress(email));

            message.Subject = "THEFLUX - Conta a Vencer";
            body = body.Replace("{0}", conta);
            body = body.Replace("{1}", valor);
            message.Body = body;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Send(message);
            this.Log(message);
            return true;

        }

        public bool Comprovante(string email, string conta, String valor, String data)
        {
            String body = "<html><head><style>html{line-height:1.5;font-family:\"Roboto\",sans-serif;font-weight:normal;color:rgba(0, 0, 0, 0.87)}</style></head><body style=\"margin: 0px\"><div style=\"height: 50px; background: black\"><center> <img style=\"height: 40px; margin - top:5px\" src=\"http://app.basicflux.com/img/logo_header.png\" /></center</div><div style=\"height:50px; margin-left:20%; width:60%;\"><h1 style=\"color:purple\">Conta Paga</h1><p> Você pagou a conta ({0}) registrada para o dia {{2}} no TheFlux! O valor pago foi de:</p><div style=\"height:50px; background:purple; color:white\"><center style=\"vertical-align: middle;line-height: 50px;\">{{1}}</center></div><p> Não se esqueça de marcar a conta como paga.</p><p> Atenciosamente,</p><p> Equipe BasicFlux</p></div></body></html>";

            MailMessage message = new MailMessage();
            message.From = new MailAddress("contato@basicflux.com");

            message.To.Add(new MailAddress(email));

            message.Subject = "THEFLUX - Conta a Vencer";
            body = body.Replace("{0}", conta);
            body = body.Replace("{1}", valor);
            body = body.Replace("{2}", data);
            message.Body = body;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Send(message);
            this.Log(message);
            return true;

        }

        public bool Boleto(string email, string nome, string vencimento, string boleto, string url)
        {
            String body = "<html><head> <style>html{line-height: 1.5; font-family: \"Roboto\",sans-serif;font-weight:normal;color:rgba(0, 0, 0, 0.87)}</style></head><body style=\"margin: 0px\"> <div style=\"height: 50px; background: black\"> <div style=\"height: 50px; margin - left:20 %; width: 60 %; \"><br/><br/> <h1 style=\"color: purple\">Seu Boleto</h1> <p> Olá,{0}este é o seu boleto com vencimento para{1},você pode imprimir clicando <a href=\"{3}\">aqui</a>:</p><div style=\"height: 50px; background: purple; color: white\"> <center style=\"vertical - align: middle; line - height: 50px; \">{2}</center> </div><p> Atenciosamente,</p><p> Equipe BasicFlux</p></div></body></html>";

            MailMessage message = new MailMessage();
            message.From = new MailAddress("contato@basicflux.com");

            message.To.Add(new MailAddress(email));

            message.Subject = "THEFLUX - Boleto gerado";
            body = body.Replace("{0}", nome);
            body = body.Replace("{1}", vencimento);
            body = body.Replace("{2}", boleto);
            body = body.Replace("{3}", url);
            message.Body = body;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Send(message);
            this.Log(message);
            return true;
        }

        public bool PreVencimento(string email, string nome, string vencimento, string boleto, string url, string dias)
        {

            String body = "<html><head><style>html{line-height: 1.5;font-family: \"Roboto\",sans-serif;font-weight:normal;color:rgba(0, 0, 0, 0.87)}</style></head><body style=\"margin: 0px\"><div style=\"height: 50px; backsground: black\"><div style=\"height:50px; margin-left:20%; width:60%;\"><br/><br/><h1 style=\"color:purple\">Seu Boleto</h1><p> Olá, {0} este é o seu boleto com que vence em {3} dia(s) ({1}),você pode imprimir clicando <a href=\"{4}\">aqui</a>:</p><div style=\"height:50px; background:purple; color:white\"><center style=\"vertical-align: middle;line-height: 50px;\">{2}</center></div><p> Atenciosamente,</p><p> Equipe BasicFlux</p></div></body></html>";

            MailMessage message = new MailMessage();
            message.From = new MailAddress("contato@basicflux.com");

            message.To.Add(new MailAddress(email));

            message.Subject = "BASICFLUX - Aviso de Vencimento " + dias + " dias";
            body = body.Replace("{0}", nome);
            body = body.Replace("{1}", vencimento);
            body = body.Replace("{2}", boleto);
            body = body.Replace("{3}", dias);
            body = body.Replace("{4}", url);
            message.Body = body;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Send(message);
            this.Log(message);
            return true;
        }

    }
}