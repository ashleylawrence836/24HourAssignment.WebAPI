namespace _24HrAssn.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Comment", "EditedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comment", "EditedUtc");
            DropColumn("dbo.Comment", "CreatedUtc");
        }
    }
}
