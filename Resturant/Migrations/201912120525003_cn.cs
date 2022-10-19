namespace Resturant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Confirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "Served", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Served");
            DropColumn("dbo.Orders", "Confirmed");
        }
    }
}
