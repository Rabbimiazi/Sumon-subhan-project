namespace Resturant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Subject = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.Reserves",
                c => new
                    {
                        ReserveId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Date = c.String(),
                        Time = c.String(),
                        Person = c.String(),
                        Confirmed = c.Boolean(nullable: false),
                        Served = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ReserveId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reserves");
            DropTable("dbo.Contacts");
        }
    }
}
