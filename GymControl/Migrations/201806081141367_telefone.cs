namespace GymControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class telefone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GC_Modalidade", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.GC_Usuario", "Telefone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GC_Usuario", "Telefone");
            DropColumn("dbo.GC_Modalidade", "IsActive");
        }
    }
}
