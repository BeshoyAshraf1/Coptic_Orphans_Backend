using BAL.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.managers
{
    public interface IJobManager
    {
        Task<PagedResponse<JobViewModel>> GetAllJobs(int pageNumber, int pageSize);
        Task<JobViewModel> GetJobById(int id);
        Task<ApplicationViewModel> ApplyForJob(ApplicationViewModel application);
    }
}
