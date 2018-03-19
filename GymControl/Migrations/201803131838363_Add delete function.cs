namespace GymControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adddeletefunction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GC_Usuario", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.GC_Mensalidade", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GC_Mensalidade", "IsActive");
            DropColumn("dbo.GC_Usuario", "IsActive");
        }
    }
}
