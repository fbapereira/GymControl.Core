namespace GymControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pagseguronotification : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GC_PagSeguroNotification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        IsProcessed = c.Boolean(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GC_PagSeguroNotification");
        }
    }
}
