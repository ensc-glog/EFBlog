using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; } = null!;
    public DbSet<RssBlog> RssBlogs { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;

    public string DbPath { get; private set; }

    public BloggingContext()
    {
        // Path to SQLite database file
        DbPath = "EFBlog.db";
    }

    // The following configures EF to create a SQLite database file locally
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Use SQLite as database
        options.UseSqlite($"Data Source={DbPath}");
        // Optional: log SQL queries to console
        options.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
    }
}
