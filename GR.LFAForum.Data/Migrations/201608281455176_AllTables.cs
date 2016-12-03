namespace GR.LFAForum.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllTables : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Users", "UserStatusId");
            CreateIndex("dbo.Posts", "UsersId");
            CreateIndex("dbo.Posts", "StatusId");
            CreateIndex("dbo.Topics", "UsersId");
            CreateIndex("dbo.Topics", "StatusId");
            CreateIndex("dbo.UserGroups", "UserId");
            CreateIndex("dbo.UserGroups", "GroupId");
            AddForeignKey("dbo.Users", "UserStatusId", "dbo.UserStatus", "UserStatusId", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "StatusId", "dbo.Status", "StatusId", cascadeDelete: true);
            AddForeignKey("dbo.Topics", "StatusId", "dbo.Status", "StatusId", cascadeDelete: true);
            AddForeignKey("dbo.Topics", "UsersId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "UsersId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.UserGroups", "GroupId", "dbo.Groups", "GroupId", cascadeDelete: true);
            AddForeignKey("dbo.UserGroups", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserGroups", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserGroups", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Posts", "UsersId", "dbo.Users");
            DropForeignKey("dbo.Topics", "UsersId", "dbo.Users");
            DropForeignKey("dbo.Topics", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Posts", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Users", "UserStatusId", "dbo.UserStatus");
            DropIndex("dbo.UserGroups", new[] { "GroupId" });
            DropIndex("dbo.UserGroups", new[] { "UserId" });
            DropIndex("dbo.Topics", new[] { "StatusId" });
            DropIndex("dbo.Topics", new[] { "UsersId" });
            DropIndex("dbo.Posts", new[] { "StatusId" });
            DropIndex("dbo.Posts", new[] { "UsersId" });
            DropIndex("dbo.Users", new[] { "UserStatusId" });
        }
    }
}
