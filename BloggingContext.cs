using Microsoft.EntityFrameworkCore;
using EFGetStarted.Models;

namespace EFGetStarted
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public string DbPath { get; private set; }

        public BloggingContext()
        {
            DbPath = "EFGetStarted.db";
        }

        // The following configures EF to create a SQLite database file locally
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}