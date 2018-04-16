namespace GymControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GC_Email",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Corpo = c.String(nullable: false),
                        Titulo = c.String(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GC_Email");
        }
    }
}
