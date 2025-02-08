using AutoMapper;
using BAL.ViewModel;
using DAL.Repositories;
using DAL.Repositories.model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BAL.managers
{
    public class JobManager : IJobManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly string _resumeStoragePath;
        public JobManager(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _config = config;
            _resumeStoragePath = _config["FileStorage:ResumesPath"] ?? Path.Combine("wwwroot", "resumes");
            Directory.CreateDirectory(_resumeStoragePath);
        }

        public async Task<PagedResponse<JobViewModel>> GetAllJobs(int pageNumber, int pageSize)
        {
            var jobs = await _unitOfWork.Jobs.GetAllAsync();
            var pagedJobs = jobs.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResponse<JobViewModel>
            {
                Data = _mapper.Map<List<JobViewModel>>(pagedJobs),
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = jobs.Count()
            };
        }

        public async Task<JobViewModel> GetJobById(int id)
        {
            var job = await _unitOfWork.Jobs.GetByIdAsync(id);
            return _mapper.Map<JobViewModel>(job);
        }

        public async Task<ApplicationViewModel> ApplyForJob(ApplicationViewModel application)
        {
            var job = await _unitOfWork.Jobs.GetByIdAsync(application.JobId);
            if (job == null) throw new KeyNotFoundException("Job not found");

           
            var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(application.ResumeFile.FileName)}";
            var filePath = Path.Combine(_resumeStoragePath, uniqueFileName);

      
            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await application.ResumeFile.CopyToAsync(stream);
            }

            var newApplication = new Application
            {
                JobId = application.JobId,
                ApplicantName = application.ApplicantName,
                Email = application.Email,
                Resume = uniqueFileName,
                AppliedDate = DateTime.UtcNow
            };

            await _unitOfWork.Applications.AddAsync(newApplication);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ApplicationViewModel>(newApplication);
        }


    }
}
