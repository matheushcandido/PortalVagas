using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RepositoriesInterfaces
{
    public interface IJobRepository
    {
        public Task<IEnumerable<Job>> GetAll();
        public Task<Job> GetById(Guid id);
        public Task Add(Job job);
        public Task<Job> Update(Job job);
        public Task Delete(Guid id);
    }
}
