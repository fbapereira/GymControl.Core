namespace GymControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Id : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GC_Modalidade", "GC_Academia_Id", "dbo.GC_Academia");
            DropIndex("dbo.GC_Modalidade", new[] { "GC_Academia_Id" });
            RenameColumn(table: "dbo.GC_Modalidade", name: "GC_Academia_Id", newName: "GC_AcademiaId");
            AlterColumn("dbo.GC_Modalidade", "GC_AcademiaId", c => c.Int(nullable: false));
            CreateIndex("dbo.GC_Modalidade", "GC_AcademiaId");
            AddForeignKey("dbo.GC_Modalidade", "GC_AcademiaId", "dbo.GC_Academia", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GC_Modalidade", "GC_AcademiaId", "dbo.GC_Academia");
            DropIndex("dbo.GC_Modalidade", new[] { "GC_AcademiaId" });
            AlterColumn("dbo.GC_Modalidade", "GC_AcademiaId", c => c.Int());
            RenameColumn(table: "dbo.GC_Modalidade", name: "GC_AcademiaId", newName: "GC_Academia_Id");
            CreateIndex("dbo.GC_Modalidade", "GC_Academia_Id");
            AddForeignKey("dbo.GC_Modalidade", "GC_Academia_Id", "dbo.GC_Academia", "Id");
        }
    }
}
