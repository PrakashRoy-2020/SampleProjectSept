namespace ProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CId = c.Int(nullable: false, identity: true),
                        CName = c.String(),
                    })
                .PrimaryKey(t => t.CId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
