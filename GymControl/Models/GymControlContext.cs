using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GymControl.Models
{
    public class GymControlContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public GymControlContext() : base("name=GymControlContext")
        {
        }

        public System.Data.Entity.DbSet<GymControl.Models.GC_Aula> GC_Aula { get; set; }

        public System.Data.Entity.DbSet<GymControl.Models.GC_Academia> GC_Academia { get; set; }

        public System.Data.Entity.DbSet<GymControl.Models.GC_Mensalidade> GC_Mensalidade { get; set; }

        public System.Data.Entity.DbSet<GymControl.Models.GC_MensalidadeStatus> GC_MensalidadeStatus { get; set; }

        public System.Data.Entity.DbSet<GymControl.Models.GC_Modalidade> GC_Modalidade { get; set; }

        public System.Data.Entity.DbSet<GymControl.Models.GC_Perfil> GC_Perfil { get; set; }

        public System.Data.Entity.DbSet<GymControl.Models.GC_Usuario> GC_Usuario { get; set; }

        public System.Data.Entity.DbSet<GymControl.Models.GC_PagSeguroPagamento> GC_PagSeguroPagamento { get; set; }

        public System.Data.Entity.DbSet<GymControl.Models.GC_PagSeguroNotification> GC_PagSeguroNotification { get; set; }

        public System.Data.Entity.DbSet<GymControl.Models.GC_Email> GC_Email { get; set; }

        public System.Data.Entity.DbSet<GymControl.Models.GC_Presenca> GC_Presenca { get; set; }

        public System.Data.Entity.DbSet<GymControl.Models.GC_MensalidadeLog> GC_MensalidadeLog { get; set; }
    }
}
