
using GymControl.Models;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;


namespace GymControl
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private GymControlContext db;

        public SimpleAuthorizationServerProvider()
        {
            db = new GymControlContext();
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;
            context.TryGetFormCredentials(out clientId, out clientSecret);



            GC_Usuario oGC_Usuario = (from item in this.db.GC_Usuario
                                      where item.Senha == clientSecret && (item.Email == clientId || item.Login == clientId) && item.IsActive
                                      select item).FirstOrDefault();
            if (oGC_Usuario != null)
            {
                context.Validated(clientId);
            }

            return base.ValidateClientAuthentication(context);
        }

        public override Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        {

            GC_Usuario oGC_Usuario = (from item in this.db.GC_Usuario
                                      where (item.Email == context.ClientId || item.Login == context.ClientId) && item.IsActive
                                      select item).FirstOrDefault();
            var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, oGC_Usuario.Nome));
            oAuthIdentity.AddClaim(new Claim(ClaimTypes.Sid, oGC_Usuario.Id.ToString()));

            var ticket = new AuthenticationTicket(oAuthIdentity, new AuthenticationProperties());
            context.Validated(ticket);
            return base.GrantClientCredentials(context);
        }
    }
}