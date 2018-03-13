namespace GymControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removechavedesnecessaria : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GC_Modalidade", "AcademiaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GC_Modalidade", "AcademiaId", c => c.Int(nullable: false));
        }
    }
}
