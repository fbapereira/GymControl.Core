namespace GymControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Academiaparaemais : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GC_Email", "GC_AcademiaId_Id", c => c.Int(nullable: true));
            CreateIndex("dbo.GC_Email", "GC_AcademiaId_Id");
            AddForeignKey("dbo.GC_Email", "GC_AcademiaId_Id", "dbo.GC_Academia", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GC_Email", "GC_AcademiaId_Id", "dbo.GC_Academia");
            DropIndex("dbo.GC_Email", new[] { "GC_AcademiaId_Id" });
            DropColumn("dbo.GC_Email", "GC_AcademiaId_Id");
        }
    }
}
