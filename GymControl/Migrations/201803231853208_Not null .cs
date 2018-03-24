namespace GymControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Notnull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GC_PagSeguroNotification", "IsProcessed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GC_PagSeguroNotification", "IsProcessed", c => c.Boolean());
        }
    }
}
