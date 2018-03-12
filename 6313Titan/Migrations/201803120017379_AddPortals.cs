namespace _6313Titan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPortals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Portals",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Portals");
        }
    }
}
