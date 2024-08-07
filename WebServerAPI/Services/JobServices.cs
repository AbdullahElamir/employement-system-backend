using System.Collections.Generic;
using System.Linq;
using WebServerAPI.Data;
using WebServerAPI.DTOs;
using WebServerAPI.Models;

namespace WebServerAPI.Services
{
    public class JobServices : IJobService
    {
        private readonly ApplicationDbContext _context;

        public JobServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<JobDto> GetAllJobs()
        {
            return _context.Jobs
                .Select(j => new JobDto
                {
                    JobId = j.JobId,
                    JobName = j.JobName
                }).ToList();
        }

        public JobDto GetJobById(int id)
        {
            var job = _context.Jobs.Find(id);
            if (job == null)
            {
                return null;
            }
            else {
                return new JobDto
                {
                    JobId = job.JobId,
                    JobName = job.JobName
                };
            };
        }

        public void AddJob(JobPostDto jobDto)
        {
            var job = new Job
            {
                JobName = jobDto.JobName
            };

            _context.Jobs.Add(job);
            _context.SaveChanges();
        }

        public void UpdateJob(int id, JobPostDto jobDto)
        {
            var job = _context.Jobs.Find(id);
            if (job != null)
            {
                job.JobName = jobDto.JobName;

                _context.Jobs.Update(job);
                _context.SaveChanges();
            }
        }

        public void DeleteJob(int id)
        {
            var job = _context.Jobs.Find(id);
            if (job != null)
            {
                _context.Jobs.Remove(job);
                _context.SaveChanges();
            }
        }
        
    }
}
