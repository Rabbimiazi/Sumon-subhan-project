namespace Resturant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class email : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mails",
                c => new
                    {
                        MailId = c.Int(nullable: false, identity: true),
                        TO = c.String(),
                        From = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        Name = c.String(),
                        ProfileName = c.String(),
                        CategoryType = c.String(),
                    })
                .PrimaryKey(t => t.MailId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Mails");
        }
    }
}
