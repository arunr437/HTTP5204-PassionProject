namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobPosts", "name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobPosts", "name");
        }
    }
}
