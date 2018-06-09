namespace GymControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModulodeAula : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GC_Aula",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        GC_Modalidade_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GC_Modalidade", t => t.GC_Modalidade_Id)
                .Index(t => t.GC_Modalidade_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GC_Aula", "GC_Modalidade_Id", "dbo.GC_Modalidade");
            DropIndex("dbo.GC_Aula", new[] { "GC_Modalidade_Id" });
            DropTable("dbo.GC_Aula");
        }
    }
}
