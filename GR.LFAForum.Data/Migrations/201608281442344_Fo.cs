namespace GR.LFAForum.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        CategoryId = c.Int(nullable: false),
                        CreatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Groups");
        }
    }
}
