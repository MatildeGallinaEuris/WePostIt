using Microsoft.EntityFrameworkCore;
using WePostIt.API.Domain;

namespace WePostIt.API.Data
{
    public class WePostIdDbContext : DbContext
    {
        public DbSet<Message> Messages { get; set; } = null!;

        public WePostIdDbContext(DbContextOptions options)
            : base(options) 
        { }
    }
}
