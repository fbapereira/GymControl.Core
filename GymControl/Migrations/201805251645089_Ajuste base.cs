namespace GymControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajustebase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GC_Modalidade", "GC_Usuario_Id", "dbo.GC_Usuario");
            DropIndex("dbo.GC_Modalidade", new[] { "GC_Usuario_Id" });
            DropColumn("dbo.GC_Modalidade", "GC_Usuario_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GC_Modalidade", "GC_Usuario_Id", c => c.Int());
            CreateIndex("dbo.GC_Modalidade", "GC_Usuario_Id");
            AddForeignKey("dbo.GC_Modalidade", "GC_Usuario_Id", "dbo.GC_Usuario", "Id");
        }
    }
}
