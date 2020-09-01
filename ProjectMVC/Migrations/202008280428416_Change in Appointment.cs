namespace ProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeinAppointment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "AId", "dbo.Appointments");
            DropIndex("dbo.Products", new[] { "AId" });
            DropColumn("dbo.Products", "AId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "AId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "AId");
            AddForeignKey("dbo.Products", "AId", "dbo.Appointments", "AId", cascadeDelete: true);
        }
    }
}
