namespace GymControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Avisos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GC_Mensalidade", "IsAvisoCinco", c => c.Boolean(nullable: false));
            AddColumn("dbo.GC_Mensalidade", "IsAvisoTres", c => c.Boolean(nullable: false));
            AddColumn("dbo.GC_Mensalidade", "IsAvisoUm", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GC_Mensalidade", "IsAvisoUm");
            DropColumn("dbo.GC_Mensalidade", "IsAvisoTres");
            DropColumn("dbo.GC_Mensalidade", "IsAvisoCinco");
        }
    }
}
