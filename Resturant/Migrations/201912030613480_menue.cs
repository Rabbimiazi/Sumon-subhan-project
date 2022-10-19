namespace Resturant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menue : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menues",
                c => new
                    {
                        MenueId = c.Int(nullable: false, identity: true),
                        MenueName = c.String(),
                        DishTitle = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Materials = c.String(),
                        Materials1 = c.String(),
                        Materials2 = c.String(),
                        Materials3 = c.String(),
                    })
                .PrimaryKey(t => t.MenueId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Menues");
        }
    }
}
