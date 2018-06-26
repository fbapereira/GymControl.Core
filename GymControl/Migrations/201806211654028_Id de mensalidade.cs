namespace GymControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Iddemensalidade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GC_MensalidadeLog", "GC_MensalidadeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GC_MensalidadeLog", "GC_MensalidadeId");
        }
    }
}
