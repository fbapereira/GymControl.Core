namespace GymControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GC_Academia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Token = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GC_Modalidade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        AcademiaId = c.Int(nullable: false),
                        GC_Academia_Id = c.Int(),
                        GC_Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GC_Academia", t => t.GC_Academia_Id)
                .ForeignKey("dbo.GC_Usuario", t => t.GC_Usuario_Id)
                .Index(t => t.GC_Academia_Id)
                .Index(t => t.GC_Usuario_Id);
            
            CreateTable(
                "dbo.GC_Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        CPF = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GC_Mensalidade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Vencimento = c.DateTime(nullable: false),
                        GC_MensalidadeStatusId_Id = c.Int(nullable: false),
                        GC_Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GC_MensalidadeStatus", t => t.GC_MensalidadeStatusId_Id, cascadeDelete: true)
                .ForeignKey("dbo.GC_Usuario", t => t.GC_Usuario_Id)
                .Index(t => t.GC_MensalidadeStatusId_Id)
                .Index(t => t.GC_Usuario_Id);
            
            CreateTable(
                "dbo.GC_MensalidadeStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GC_Perfil",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GC_UsuarioGC_Academia",
                c => new
                    {
                        GC_Usuario_Id = c.Int(nullable: false),
                        GC_Academia_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GC_Usuario_Id, t.GC_Academia_Id })
                .ForeignKey("dbo.GC_Usuario", t => t.GC_Usuario_Id, cascadeDelete: true)
                .ForeignKey("dbo.GC_Academia", t => t.GC_Academia_Id, cascadeDelete: true)
                .Index(t => t.GC_Usuario_Id)
                .Index(t => t.GC_Academia_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GC_Modalidade", "GC_Usuario_Id", "dbo.GC_Usuario");
            DropForeignKey("dbo.GC_Mensalidade", "GC_Usuario_Id", "dbo.GC_Usuario");
            DropForeignKey("dbo.GC_Mensalidade", "GC_MensalidadeStatusId_Id", "dbo.GC_MensalidadeStatus");
            DropForeignKey("dbo.GC_UsuarioGC_Academia", "GC_Academia_Id", "dbo.GC_Academia");
            DropForeignKey("dbo.GC_UsuarioGC_Academia", "GC_Usuario_Id", "dbo.GC_Usuario");
            DropForeignKey("dbo.GC_Modalidade", "GC_Academia_Id", "dbo.GC_Academia");
            DropIndex("dbo.GC_UsuarioGC_Academia", new[] { "GC_Academia_Id" });
            DropIndex("dbo.GC_UsuarioGC_Academia", new[] { "GC_Usuario_Id" });
            DropIndex("dbo.GC_Mensalidade", new[] { "GC_Usuario_Id" });
            DropIndex("dbo.GC_Mensalidade", new[] { "GC_MensalidadeStatusId_Id" });
            DropIndex("dbo.GC_Modalidade", new[] { "GC_Usuario_Id" });
            DropIndex("dbo.GC_Modalidade", new[] { "GC_Academia_Id" });
            DropTable("dbo.GC_UsuarioGC_Academia");
            DropTable("dbo.GC_Perfil");
            DropTable("dbo.GC_MensalidadeStatus");
            DropTable("dbo.GC_Mensalidade");
            DropTable("dbo.GC_Usuario");
            DropTable("dbo.GC_Modalidade");
            DropTable("dbo.GC_Academia");
        }
    }
}
