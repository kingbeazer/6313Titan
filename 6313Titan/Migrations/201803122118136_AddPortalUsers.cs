namespace _6313Titan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPortalUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PortalUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PortalId = c.Long(nullable: false),
                        UserId = c.String(),
                        Portal_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Portals", t => t.Portal_Id)
                .Index(t => t.Portal_Id);
            
            AddColumn("dbo.AspNetUsers", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PortalUsers", "Portal_Id", "dbo.Portals");
            DropIndex("dbo.PortalUsers", new[] { "Portal_Id" });
            DropColumn("dbo.AspNetUsers", "UserId");
            DropTable("dbo.PortalUsers");
        }
    }
}
