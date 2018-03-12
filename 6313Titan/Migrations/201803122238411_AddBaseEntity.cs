namespace _6313Titan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBaseEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Portals", "DateCreated", c => c.DateTime());
            AddColumn("dbo.Portals", "UserCreated", c => c.String());
            AddColumn("dbo.Portals", "DateModified", c => c.DateTime());
            AddColumn("dbo.Portals", "UserModified", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Portals", "UserModified");
            DropColumn("dbo.Portals", "DateModified");
            DropColumn("dbo.Portals", "UserCreated");
            DropColumn("dbo.Portals", "DateCreated");
        }
    }
}
