namespace GymControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeyFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GC_Perfil", "GC_Usuario_Id", "dbo.GC_Usuario");
            DropIndex("dbo.GC_Perfil", new[] { "GC_Usuario_Id" });
            CreateTable(
                "dbo.GC_PerfilGC_Usuario",
                c => new
                    {
                        GC_Perfil_Id = c.Int(nullable: false),
                        GC_Usuario_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GC_Perfil_Id, t.GC_Usuario_Id })
                .ForeignKey("dbo.GC_Perfil", t => t.GC_Perfil_Id, cascadeDelete: true)
                .ForeignKey("dbo.GC_Usuario", t => t.GC_Usuario_Id, cascadeDelete: true)
                .Index(t => t.GC_Perfil_Id)
                .Index(t => t.GC_Usuario_Id);
            
            DropColumn("dbo.GC_Perfil", "GC_Usuario_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GC_Perfil", "GC_Usuario_Id", c => c.Int());
            DropForeignKey("dbo.GC_PerfilGC_Usuario", "GC_Usuario_Id", "dbo.GC_Usuario");
            DropForeignKey("dbo.GC_PerfilGC_Usuario", "GC_Perfil_Id", "dbo.GC_Perfil");
            DropIndex("dbo.GC_PerfilGC_Usuario", new[] { "GC_Usuario_Id" });
            DropIndex("dbo.GC_PerfilGC_Usuario", new[] { "GC_Perfil_Id" });
            DropTable("dbo.GC_PerfilGC_Usuario");
            CreateIndex("dbo.GC_Perfil", "GC_Usuario_Id");
            AddForeignKey("dbo.GC_Perfil", "GC_Usuario_Id", "dbo.GC_Usuario", "Id");
        }
    }
}
