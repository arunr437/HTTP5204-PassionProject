namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobPosts", "Description1", c => c.String());
            DropColumn("dbo.JobPosts", "description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobPosts", "description", c => c.String());
            DropColumn("dbo.JobPosts", "Description1");
        }
    }
}
