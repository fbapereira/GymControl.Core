namespace GymControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarPresenca : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GC_Presenca",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aula_Id = c.Int(nullable: false),
                        Usuario_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GC_Aula", t => t.Aula_Id, cascadeDelete: true)
                .ForeignKey("dbo.GC_Usuario", t => t.Usuario_Id, cascadeDelete: true)
                .Index(t => t.Aula_Id)
                .Index(t => t.Usuario_Id);
            
            AddColumn("dbo.GC_Aula", "Inicio", c => c.DateTime(nullable: false));
            AddColumn("dbo.GC_Aula", "Fim", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GC_Presenca", "Usuario_Id", "dbo.GC_Usuario");
            DropForeignKey("dbo.GC_Presenca", "Aula_Id", "dbo.GC_Aula");
            DropIndex("dbo.GC_Presenca", new[] { "Usuario_Id" });
            DropIndex("dbo.GC_Presenca", new[] { "Aula_Id" });
            DropColumn("dbo.GC_Aula", "Fim");
            DropColumn("dbo.GC_Aula", "Inicio");
            DropTable("dbo.GC_Presenca");
        }
    }
}
