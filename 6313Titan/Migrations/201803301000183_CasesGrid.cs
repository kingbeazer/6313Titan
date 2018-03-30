namespace _6313Titan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CasesGrid : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Contacts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        WorkNumber = c.String(),
                        MobileNumber = c.String(),
                        PortalId = c.Guid(nullable: false),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
