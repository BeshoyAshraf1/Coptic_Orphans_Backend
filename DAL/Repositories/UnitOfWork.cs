using DAL.Repositories.applicationDBcontext;
using DAL.Repositories.model;
using Demo2G1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Jobs = new GenericRepository<Job>(_context);
            Applications = new GenericRepository<Application>(_context);
        }

        public IGenericRepository<Job> Jobs { get; }
        public IGenericRepository<Application> Applications { get; }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
