using System.Data.Entity.Migrations;

namespace Event.Migrations
{
    public partial class sql : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [NationalId], [Image]) VALUES (N'52a161c7-67d3-4bfb-8791-35e2134d3462', N'„Õ„œ', N'¬–—êÊ‰', N'azargoonm@gmail.com', 0, N'ACCvAITyD3QHlZhz5qAeqgNIjbK492pJGylGXd9kufTxtnA7ZGe2EAb6sxjASPwBNg==', N'039c563a-8ba5-424f-a0c2-9908435e1b1a', N'8578577', 0, 0, NULL, 1, 0, N'azargoonm@gmail.com', N'0019734778', NULL)


INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'75e29fe9-8659-4604-b938-b95ddc02a427', N'admin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'52a161c7-67d3-4bfb-8791-35e2134d3462', N'75e29fe9-8659-4604-b938-b95ddc02a427')

");
        }

        public override void Down()
        {
        }
    }
}