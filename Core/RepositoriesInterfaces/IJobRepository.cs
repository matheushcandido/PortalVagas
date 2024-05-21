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
        Task<IEnumerable<Job>> GetAll();
        Task<Job> GetById(Guid id);
        Task Add(Job job);
        Task Update(Job job);
        Task Delete(Guid id);
    }
}
