namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedKey2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.JobApplications", "SeekerId");
            CreateIndex("dbo.JobApplications", "jobId");
            AddForeignKey("dbo.JobApplications", "jobId", "dbo.JobPosts", "jobId", cascadeDelete: true);
            AddForeignKey("dbo.JobApplications", "SeekerId", "dbo.JobSeekers", "SeekerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobApplications", "SeekerId", "dbo.JobSeekers");
            DropForeignKey("dbo.JobApplications", "jobId", "dbo.JobPosts");
            DropIndex("dbo.JobApplications", new[] { "jobId" });
            DropIndex("dbo.JobApplications", new[] { "SeekerId" });
        }
    }
}
