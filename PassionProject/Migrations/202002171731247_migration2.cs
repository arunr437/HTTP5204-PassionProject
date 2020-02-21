namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobSeekers",
                c => new
                    {
                        SeekerId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        emailId = c.String(),
                        location = c.String(),
                    })
                .PrimaryKey(t => t.SeekerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.JobSeekers");
        }
    }
}
