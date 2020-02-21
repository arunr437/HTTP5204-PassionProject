namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobPosts", "company", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobPosts", "company");
        }
    }
}
