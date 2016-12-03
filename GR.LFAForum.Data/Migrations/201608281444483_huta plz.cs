namespace GR.LFAForum.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hutaplz : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Created = c.DateTime(nullable: false),
                        LastActivity = c.DateTime(nullable: false),
                        IsModerator = c.Boolean(nullable: false),
                        UserStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false, maxLength: 200),
                        Context = c.String(),
                        Created = c.DateTime(nullable: false),
                        TopicId = c.Int(nullable: false),
                        UsersId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        TopicId = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false, maxLength: 200),
                        Created = c.DateTime(nullable: false),
                        UsersId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TopicId);
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.GroupId });
            
            CreateTable(
                "dbo.UserStatus",
                c => new
                    {
                        UserStatusId = c.Int(nullable: false, identity: true),
                        UserStatusName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.UserStatusId);
            
            AddColumn("dbo.Groups", "Users_UserId", c => c.Int());
            CreateIndex("dbo.Categories", "StatusId");
            CreateIndex("dbo.Groups", "CategoryId");
            CreateIndex("dbo.Groups", "Users_UserId");
            AddForeignKey("dbo.Categories", "StatusId", "dbo.Status", "StatusId", cascadeDelete: true);
            AddForeignKey("dbo.Groups", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.Groups", "Users_UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Groups", "Users_UserId", "dbo.Users");
            DropForeignKey("dbo.Groups", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "StatusId", "dbo.Status");
            DropIndex("dbo.Posts", new[] { "TopicId" });
            DropIndex("dbo.Groups", new[] { "Users_UserId" });
            DropIndex("dbo.Groups", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "StatusId" });
            DropColumn("dbo.Groups", "Users_UserId");
            DropTable("dbo.UserStatus");
            DropTable("dbo.UserGroups");
            DropTable("dbo.Topics");
            DropTable("dbo.Posts");
            DropTable("dbo.Users");
            DropTable("dbo.Status");
        }
    }
}
