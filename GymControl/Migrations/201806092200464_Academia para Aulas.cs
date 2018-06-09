namespace GymControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AcademiaparaAulas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GC_Aula", "GC_Modalidade_Id", "dbo.GC_Modalidade");
            DropIndex("dbo.GC_Aula", new[] { "GC_Modalidade_Id" });
            RenameColumn(table: "dbo.GC_Aula", name: "GC_Modalidade_Id", newName: "GC_ModalidadeId");
            AlterColumn("dbo.GC_Aula", "GC_ModalidadeId", c => c.Int(nullable: false));
            CreateIndex("dbo.GC_Aula", "GC_ModalidadeId");
            AddForeignKey("dbo.GC_Aula", "GC_ModalidadeId", "dbo.GC_Modalidade", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GC_Aula", "GC_ModalidadeId", "dbo.GC_Modalidade");
            DropIndex("dbo.GC_Aula", new[] { "GC_ModalidadeId" });
            AlterColumn("dbo.GC_Aula", "GC_ModalidadeId", c => c.Int());
            RenameColumn(table: "dbo.GC_Aula", name: "GC_ModalidadeId", newName: "GC_Modalidade_Id");
            CreateIndex("dbo.GC_Aula", "GC_Modalidade_Id");
            AddForeignKey("dbo.GC_Aula", "GC_Modalidade_Id", "dbo.GC_Modalidade", "Id");
        }
    }
}
