namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedApplication : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobApplications",
                c => new
                    {
                        applicationId = c.Int(nullable: false, identity: true),
                        coverLetter = c.String(),
                        jobId_jobId = c.Int(),
                        post_jobId = c.Int(),
                        seeker_SeekerId = c.Int(),
                        seekerId_SeekerId = c.Int(),
                    })
                .PrimaryKey(t => t.applicationId)
                .ForeignKey("dbo.JobPosts", t => t.jobId_jobId)
                .ForeignKey("dbo.JobPosts", t => t.post_jobId)
                .ForeignKey("dbo.JobSeekers", t => t.seeker_SeekerId)
                .ForeignKey("dbo.JobSeekers", t => t.seekerId_SeekerId)
                .Index(t => t.jobId_jobId)
                .Index(t => t.post_jobId)
                .Index(t => t.seeker_SeekerId)
                .Index(t => t.seekerId_SeekerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobApplications", "seekerId_SeekerId", "dbo.JobSeekers");
            DropForeignKey("dbo.JobApplications", "seeker_SeekerId", "dbo.JobSeekers");
            DropForeignKey("dbo.JobApplications", "post_jobId", "dbo.JobPosts");
            DropForeignKey("dbo.JobApplications", "jobId_jobId", "dbo.JobPosts");
            DropIndex("dbo.JobApplications", new[] { "seekerId_SeekerId" });
            DropIndex("dbo.JobApplications", new[] { "seeker_SeekerId" });
            DropIndex("dbo.JobApplications", new[] { "post_jobId" });
            DropIndex("dbo.JobApplications", new[] { "jobId_jobId" });
            DropTable("dbo.JobApplications");
        }
    }
}
