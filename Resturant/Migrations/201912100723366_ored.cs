namespace Resturant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ored : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "DishId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "DishId");
        }
    }
}
