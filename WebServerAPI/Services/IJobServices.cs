using System.Collections.Generic;
using WebServerAPI.DTOs;

namespace WebServerAPI.Services
{
    public interface IJobService
    {
        List<JobDto> GetAllJobs();
        JobDto GetJobById(int id);
        void AddJob(JobPostDto employee);
        void UpdateJob(int id, JobPostDto Uemployee);
        void DeleteJob(int id);
    }
}
