namespace GymControl.Migrations
{
    using GymControl.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GymControl.Models.GymControlContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GymControl.Models.GymControlContext context)
        {


            //context.GC_Perfil.AddOrUpdate(x => x.Id,
            //  new GC_Perfil() { Id = 1, Nome = "Aluno" },
            //  new GC_Perfil() { Id = 2, Nome = "Professor" },
            //  new GC_Perfil() { Id = 3, Nome = "Administrador" },
            //  new GC_Perfil() { Id = 3, Nome = "Super Usuario" }
            //  );

            //GC_Perfil a = new GC_Perfil();

            //GC_Academia oAcademia = new GC_Academia() { Id = 1, Email = "none@hotmail.com", Nome = "Academia de Controle" };

            //context.GC_Academia.AddOrUpdate(x => x.Id,
            //   oAcademia
            //    );

            //List<GC_Academia> lstGC_Academia = new List<GC_Academia>();
            //lstGC_Academia.Add(oAcademia);
            //context.GC_Usuario.AddOrUpdate(x => x.Id,
            //    new GC_Usuario() { Id = 1, Login = "Renato.Garcia", Senha = "@1234qwer", CPF = "222.333.444-05", Email = "none@hotmail.com", Nome = "Renato Garcia", Academias = lstGC_Academia },
            //    new GC_Usuario() { Id = 1, Login = "Felipe.Borges", Senha = "@1234qwer", CPF = "430.760.208-03", Email = "none@hotmail.com", Nome = "Felipe Borges", Academias = lstGC_Academia }
            //    );

        }
    }
}
