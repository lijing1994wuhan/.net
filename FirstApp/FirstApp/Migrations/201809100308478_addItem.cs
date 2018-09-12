namespace FirstApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Amount = c.Double(nullable: false),
                        ExpenseDate = c.DateTime(),
                        CategoryTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryTypes", t => t.CategoryTypeId, cascadeDelete: true)
                .Index(t => t.CategoryTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "CategoryTypeId", "dbo.CategoryTypes");
            DropIndex("dbo.Items", new[] { "CategoryTypeId" });
            DropTable("dbo.Items");
            DropTable("dbo.CategoryTypes");
        }
    }
}
