namespace Resturant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menues", "AdminPerson", c => c.String());
            AddColumn("dbo.Orders", "AdminPerson", c => c.String());
            AddColumn("dbo.Reserves", "AdminPerson", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reserves", "AdminPerson");
            DropColumn("dbo.Orders", "AdminPerson");
            DropColumn("dbo.Menues", "AdminPerson");
        }
    }
}
