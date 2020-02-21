namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobPosts", "description", c => c.String());
            DropColumn("dbo.JobPosts", "Description1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobPosts", "Description1", c => c.String());
            DropColumn("dbo.JobPosts", "description");
        }
    }
}
