namespace Expense.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryTypes : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO CategoryTypes(Id,Name) VALUES(1,'Food')");
            Sql("INSERT INTO CategoryTypes(Id,Name) VALUES(2,'Shopping')");
            Sql("INSERT INTO CategoryTypes(Id,Name) VALUES(3,'Travel')");
            Sql("INSERT INTO CategoryTypes(Id,Name) VALUES(4,'Health')");
        }
        
        public override void Down()
        {
        }
    }
}
