using DAL.Repositories.model;
using Demo2G1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Job> Jobs { get; }
        IGenericRepository<Application> Applications { get; }
        Task<int> CompleteAsync();
    }
}
