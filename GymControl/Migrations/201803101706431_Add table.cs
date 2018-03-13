namespace GymControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GC_PagSeguroPagamento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Link = c.String(),
                        BarCode = c.String(),
                        GC_MensalidadeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GC_PagSeguroPagamento");
        }
    }
}
