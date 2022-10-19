namespace Resturant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menueadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menues", "ImsgeUrl", c => c.String());
            AddColumn("dbo.Menues", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menues", "IsActive");
            DropColumn("dbo.Menues", "ImsgeUrl");
        }
    }
}
