namespace ProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductForiegnKeyinAppointment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "Id");
            AddForeignKey("dbo.Appointments", "Id", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Id", "dbo.Products");
            DropIndex("dbo.Appointments", new[] { "Id" });
            DropColumn("dbo.Appointments", "Id");
        }
    }
}
