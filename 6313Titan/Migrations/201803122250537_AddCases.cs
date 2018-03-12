namespace _6313Titan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCases : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Subject = c.String(),
                        Description = c.String(),
                        PortalId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Portals", t => t.PortalId, cascadeDelete: true)
                .Index(t => t.PortalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cases", "PortalId", "dbo.Portals");
            DropIndex("dbo.Cases", new[] { "PortalId" });
            DropTable("dbo.Cases");
        }
    }
}
