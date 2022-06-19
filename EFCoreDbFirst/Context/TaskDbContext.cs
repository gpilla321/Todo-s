using System;
using EFCoreDbFirst.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDbFirst.Context
{
	public class TaskDbContext : DbContext
	{
		public TaskDbContext(DbContextOptions<TaskDbContext> ctx) : base(ctx){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=/Users/gpilla/test.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Title).IsRequired().HasMaxLength(30);
                entity.Property(t => t.Description).HasMaxLength(100);
                entity.Property(t => t.Active).IsRequired().HasDefaultValue(true);
            });
        }

        public DbSet<TaskItem> TaskItem { get; set; }
    }
}

