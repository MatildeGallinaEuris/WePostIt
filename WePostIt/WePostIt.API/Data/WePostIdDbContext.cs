using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Abstractions;
using WePostIt.API.Domain;

namespace WePostIt.API.Data
{
    public class WePostIdDbContext : DbContext
    {
        public DbSet<Message> Messages { get; set; } = null!;

        public WePostIdDbContext(DbContextOptions options)
            : base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var messages = modelBuilder.Entity<Message>();
            messages.Property(message => message.CreationTime).IsRequired()
                .HasDefaultValueSql("getdate()")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }
    }
}
