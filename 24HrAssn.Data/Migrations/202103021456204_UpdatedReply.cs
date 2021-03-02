namespace _24HrAssn.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedReply : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Comment");
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        ReplyId = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        Author = c.Guid(nullable: false),
                        CommentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReplyId)
                .ForeignKey("dbo.Comment", t => t.CommentId, cascadeDelete: true)
                .Index(t => t.CommentId);
            
            AlterColumn("dbo.Comment", "CommentId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Comment", "CommentId");
            DropColumn("dbo.Comment", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comment", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Reply", "CommentId", "dbo.Comment");
            DropIndex("dbo.Reply", new[] { "CommentId" });
            DropPrimaryKey("dbo.Comment");
            AlterColumn("dbo.Comment", "CommentId", c => c.Int(nullable: false));
            DropTable("dbo.Reply");
            AddPrimaryKey("dbo.Comment", "CommentId");
        }
    }
}
