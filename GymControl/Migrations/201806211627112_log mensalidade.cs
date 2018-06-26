namespace GymControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class logmensalidade : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GC_MensalidadeLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Observacao = c.String(),
                        GC_UsuarioId = c.Int(nullable: false),
                        logDate = c.DateTime(nullable: false),
                        GC_MensalidadeStatusId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GC_MensalidadeLog");
        }
    }
}
