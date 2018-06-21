namespace GymControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailError : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GC_Email", "Erro", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GC_Email", "Erro");
        }
    }
}
