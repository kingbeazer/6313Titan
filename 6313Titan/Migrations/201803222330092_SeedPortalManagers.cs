namespace _6313Titan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedPortalManagers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [UserId]) VALUES (N'34c09f26-ddaa-4d7d-a21d-04c5fdae7635', N'ryan_7229@hotmail.co.uk', 1, N'ACqf6d/d8/bdj+vouAKs2Mrtw/pdxa3pnBxR5QSUNxUg6FM/Awg7kZz7HBtMZ1Q2jA==', N'3a65b9e7-188f-4dd4-9e64-0d6f9ec7fa7d', NULL, 0, 0, NULL, 1, 0, N'ryan_7229@hotmail.co.uk', N'b30b9986-cfb8-479f-bd3f-555028b72295')");
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [UserId]) VALUES (N'88967234-b1b6-4111-9718-af100c5fd2fd', N'beattie.edwin@gmail.com', 1, N'APRi54UC+ARrYTIDMB3Uv/HjBwDoUaldcCBHO62UGMB5CNCovEMmpcNGYyH7JVTnyg==', N'2e5ef450-6a03-49fe-9067-515c1aa2dbd8', NULL, 0, 0, NULL, 1, 0, N'beattie.edwin@gmail.com', N'acc2ba1e-fcce-4e6a-850b-0e849cc923a0')");
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [UserId]) VALUES (N'932e8d79-e5dc-4a30-b25c-2ce56126d7d1', N'portalmanager@titan.co.uk', 1, N'AFtTOyOKq/vLoA/yJUiy35uMQV/MUtk2NAtjXwp7eFKuTIB+YNYpBDPLizWfWL2ERw==', N'fb13eefa-95e8-4078-87c1-f85f95d7f405', NULL, 0, 0, NULL, 1, 0, N'portalmanager@titan.co.uk', N'e7968d3f-00fa-4f0e-9a57-cf417a547ebd')");
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'aae3e47d-314e-43c5-99cc-7eef2891bd83', N'CanManagePortals')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'932e8d79-e5dc-4a30-b25c-2ce56126d7d1', N'aae3e47d-314e-43c5-99cc-7eef2891bd83')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'34c09f26-ddaa-4d7d-a21d-04c5fdae7635', N'aae3e47d-314e-43c5-99cc-7eef2891bd83')");
        }
        
        public override void Down()
        {
        }
    }
}
