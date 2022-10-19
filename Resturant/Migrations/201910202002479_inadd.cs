namespace Resturant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inadd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reserves", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reserves", "Date", c => c.String());
        }
    }
}
