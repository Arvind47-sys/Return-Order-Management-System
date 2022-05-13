using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<ProcessResponse> ProcessResponses { get; set; }
        public DbSet<ProcessRequest> ProcessRequest { get; set; }
    }
}