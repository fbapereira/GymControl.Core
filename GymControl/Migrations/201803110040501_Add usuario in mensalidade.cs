namespace GymControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addusuarioinmensalidade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GC_Mensalidade", "GC_Usuario_Id", "dbo.GC_Usuario");
            DropIndex("dbo.GC_Mensalidade", new[] { "GC_Usuario_Id" });
            RenameColumn(table: "dbo.GC_Mensalidade", name: "GC_Usuario_Id", newName: "GC_UsuarioId");
            AlterColumn("dbo.GC_Mensalidade", "GC_UsuarioId", c => c.Int(nullable: false));
            CreateIndex("dbo.GC_Mensalidade", "GC_UsuarioId");
            AddForeignKey("dbo.GC_Mensalidade", "GC_UsuarioId", "dbo.GC_Usuario", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GC_Mensalidade", "GC_UsuarioId", "dbo.GC_Usuario");
            DropIndex("dbo.GC_Mensalidade", new[] { "GC_UsuarioId" });
            AlterColumn("dbo.GC_Mensalidade", "GC_UsuarioId", c => c.Int());
            RenameColumn(table: "dbo.GC_Mensalidade", name: "GC_UsuarioId", newName: "GC_Usuario_Id");
            CreateIndex("dbo.GC_Mensalidade", "GC_Usuario_Id");
            AddForeignKey("dbo.GC_Mensalidade", "GC_Usuario_Id", "dbo.GC_Usuario", "Id");
        }
    }
}
