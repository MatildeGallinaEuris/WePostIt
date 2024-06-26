﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WePostIt.API.Domain;

namespace WePostIt.API.Data
{
    public class WePostIdDbContext(DbContextOptions options) 
        : DbContext(options)
    {
        public DbSet<Message> Messages { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var messages = modelBuilder.Entity<Message>();
            messages.Property(message => message.CreationTime)
                .IsRequired()
                .HasDefaultValueSql("getdate()")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            var authors = modelBuilder.Entity<Author>();
            authors.Property(a => a.CreationTime).IsRequired()
                .HasDefaultValueSql("getdate()")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }
    }
}
