
select * from JobSeekers;
select * from JobPosts;
select * from JobApplications;

select s.name,s.emailId,s.location,p.name,p.company,p.skill 
from JobSeekers s
join JobApplications a on s.SeekerId = a.seekerId
join JobPosts p on  a.jobId = p.JobId
where s.SeekerId = 4;

select * 
from JobPosts p
join JobApplications a on p.JobId = a.jobId
join JobSeekers s on s.seekerId = a.seekerId
where s.SeekerId = 4;

select * 
from JobSeekers s
join JobApplications a on s.SeekerId = a.seekerId
join JobPosts p on p.JobId = a.jobId
where p.JobId = 1021;