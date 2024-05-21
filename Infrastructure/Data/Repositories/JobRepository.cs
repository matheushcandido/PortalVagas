using Core.Entities;
using Core.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly ConfigureDatabase _context;

        public JobRepository(ConfigureDatabase context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Job>> GetAll()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task<Job> GetById(Guid id)
        {
            return await _context.Jobs.FindAsync(id);
        }

        public async Task Add(Job job)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Job job)
        {
            _context.Entry(job).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job != null)
            {
                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
            }
        }
    }
}
