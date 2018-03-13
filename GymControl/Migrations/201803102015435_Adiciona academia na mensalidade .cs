namespace GymControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicionaacademianamensalidade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GC_Mensalidade", "GC_MensalidadeStatusId_Id", "dbo.GC_MensalidadeStatus");
            DropIndex("dbo.GC_Mensalidade", new[] { "GC_MensalidadeStatusId_Id" });
            AddColumn("dbo.GC_Mensalidade", "GC_MensalidadeStatusId", c => c.Int(nullable: false));
            AddColumn("dbo.GC_Mensalidade", "GC_AcademiaId", c => c.Int(nullable: false));
            DropColumn("dbo.GC_Mensalidade", "GC_MensalidadeStatusId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GC_Mensalidade", "GC_MensalidadeStatusId_Id", c => c.Int(nullable: false));
            DropColumn("dbo.GC_Mensalidade", "GC_AcademiaId");
            DropColumn("dbo.GC_Mensalidade", "GC_MensalidadeStatusId");
            CreateIndex("dbo.GC_Mensalidade", "GC_MensalidadeStatusId_Id");
            AddForeignKey("dbo.GC_Mensalidade", "GC_MensalidadeStatusId_Id", "dbo.GC_MensalidadeStatus", "Id", cascadeDelete: true);
        }
    }
}
