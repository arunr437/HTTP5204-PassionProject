namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeyAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobApplications", "jobId_jobId", "dbo.JobPosts");
            DropForeignKey("dbo.JobApplications", "post_jobId", "dbo.JobPosts");
            DropForeignKey("dbo.JobApplications", "seeker_SeekerId", "dbo.JobSeekers");
            DropForeignKey("dbo.JobApplications", "seekerId_SeekerId", "dbo.JobSeekers");
            DropIndex("dbo.JobApplications", new[] { "jobId_jobId" });
            DropIndex("dbo.JobApplications", new[] { "post_jobId" });
            DropIndex("dbo.JobApplications", new[] { "seeker_SeekerId" });
            DropIndex("dbo.JobApplications", new[] { "seekerId_SeekerId" });
            AddColumn("dbo.JobApplications", "seekerId", c => c.Int(nullable: false));
            AddColumn("dbo.JobApplications", "jobId", c => c.Int(nullable: false));
            DropColumn("dbo.JobApplications", "jobId_jobId");
            DropColumn("dbo.JobApplications", "post_jobId");
            DropColumn("dbo.JobApplications", "seeker_SeekerId");
            DropColumn("dbo.JobApplications", "seekerId_SeekerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobApplications", "seekerId_SeekerId", c => c.Int());
            AddColumn("dbo.JobApplications", "seeker_SeekerId", c => c.Int());
            AddColumn("dbo.JobApplications", "post_jobId", c => c.Int());
            AddColumn("dbo.JobApplications", "jobId_jobId", c => c.Int());
            DropColumn("dbo.JobApplications", "jobId");
            DropColumn("dbo.JobApplications", "seekerId");
            CreateIndex("dbo.JobApplications", "seekerId_SeekerId");
            CreateIndex("dbo.JobApplications", "seeker_SeekerId");
            CreateIndex("dbo.JobApplications", "post_jobId");
            CreateIndex("dbo.JobApplications", "jobId_jobId");
            AddForeignKey("dbo.JobApplications", "seekerId_SeekerId", "dbo.JobSeekers", "SeekerId");
            AddForeignKey("dbo.JobApplications", "seeker_SeekerId", "dbo.JobSeekers", "SeekerId");
            AddForeignKey("dbo.JobApplications", "post_jobId", "dbo.JobPosts", "jobId");
            AddForeignKey("dbo.JobApplications", "jobId_jobId", "dbo.JobPosts", "jobId");
        }
    }
}
