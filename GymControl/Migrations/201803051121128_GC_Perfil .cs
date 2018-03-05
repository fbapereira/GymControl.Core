namespace GymControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GC_Perfil : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GC_UsuarioGC_Academia", "GC_Usuario_Id", "dbo.GC_Usuario");
            DropForeignKey("dbo.GC_UsuarioGC_Academia", "GC_Academia_Id", "dbo.GC_Academia");
            DropIndex("dbo.GC_UsuarioGC_Academia", new[] { "GC_Usuario_Id" });
            DropIndex("dbo.GC_UsuarioGC_Academia", new[] { "GC_Academia_Id" });
            AddColumn("dbo.GC_Academia", "GC_Usuario_Id", c => c.Int());
            AddColumn("dbo.GC_Academia", "GC_Usuario_Id1", c => c.Int());
            AddColumn("dbo.GC_Usuario", "GC_Academia_Id", c => c.Int());
            AddColumn("dbo.GC_Perfil", "GC_AcademiaId_Id", c => c.Int());
            CreateIndex("dbo.GC_Academia", "GC_Usuario_Id");
            CreateIndex("dbo.GC_Academia", "GC_Usuario_Id1");
            CreateIndex("dbo.GC_Usuario", "GC_Academia_Id");
            CreateIndex("dbo.GC_Perfil", "GC_AcademiaId_Id");
            AddForeignKey("dbo.GC_Academia", "GC_Usuario_Id", "dbo.GC_Usuario", "Id");
            AddForeignKey("dbo.GC_Academia", "GC_Usuario_Id1", "dbo.GC_Usuario", "Id");
            AddForeignKey("dbo.GC_Usuario", "GC_Academia_Id", "dbo.GC_Academia", "Id");
            AddForeignKey("dbo.GC_Perfil", "GC_AcademiaId_Id", "dbo.GC_Academia", "Id");
            DropTable("dbo.GC_UsuarioGC_Academia");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GC_UsuarioGC_Academia",
                c => new
                    {
                        GC_Usuario_Id = c.Int(nullable: false),
                        GC_Academia_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GC_Usuario_Id, t.GC_Academia_Id });
            
            DropForeignKey("dbo.GC_Perfil", "GC_AcademiaId_Id", "dbo.GC_Academia");
            DropForeignKey("dbo.GC_Usuario", "GC_Academia_Id", "dbo.GC_Academia");
            DropForeignKey("dbo.GC_Academia", "GC_Usuario_Id1", "dbo.GC_Usuario");
            DropForeignKey("dbo.GC_Academia", "GC_Usuario_Id", "dbo.GC_Usuario");
            DropIndex("dbo.GC_Perfil", new[] { "GC_AcademiaId_Id" });
            DropIndex("dbo.GC_Usuario", new[] { "GC_Academia_Id" });
            DropIndex("dbo.GC_Academia", new[] { "GC_Usuario_Id1" });
            DropIndex("dbo.GC_Academia", new[] { "GC_Usuario_Id" });
            DropColumn("dbo.GC_Perfil", "GC_AcademiaId_Id");
            DropColumn("dbo.GC_Usuario", "GC_Academia_Id");
            DropColumn("dbo.GC_Academia", "GC_Usuario_Id1");
            DropColumn("dbo.GC_Academia", "GC_Usuario_Id");
            CreateIndex("dbo.GC_UsuarioGC_Academia", "GC_Academia_Id");
            CreateIndex("dbo.GC_UsuarioGC_Academia", "GC_Usuario_Id");
            AddForeignKey("dbo.GC_UsuarioGC_Academia", "GC_Academia_Id", "dbo.GC_Academia", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GC_UsuarioGC_Academia", "GC_Usuario_Id", "dbo.GC_Usuario", "Id", cascadeDelete: true);
        }
    }
}
