using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ConfigureDatabase : DbContext
    {
        public ConfigureDatabase(DbContextOptions<ConfigureDatabase> options) : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }
    }
}
