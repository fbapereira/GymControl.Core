namespace GymControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addduedate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GC_PagSeguroPagamento", "DueDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GC_PagSeguroPagamento", "DueDate");
        }
    }
}
