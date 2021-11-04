using System;
using System.Linq;
using EFGetStarted.Models;

namespace EFGetStarted
{
    internal class Program
    {
        private static void Main()
        {
            using (var context = new BloggingContext())
            {
                // Note: This sample requires the database to be created before running.
                Console.WriteLine($"Database path: {context.DbPath}.");

                Console.WriteLine("Inserting a new blog");
                context.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                context.SaveChanges();

                Console.WriteLine("Querying for a blog");
                var blog = context.Blogs
                    .OrderBy(b => b.Id)
                    .First();
                Console.WriteLine(blog);

                Console.WriteLine("Updating the blog and adding a post");
                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(
                    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
                context.SaveChanges();

                Console.WriteLine("Querying with LINQ");
                var query = from b in context.Blogs
                            select b;
                query = query.Where(b => b.Url.Contains("dotnet"));
                var blogs = query.ToList();
                foreach (Blog b in blogs)
                    Console.WriteLine(b);

                Console.WriteLine("Delete the blog");
                context.Remove(blog);
                context.SaveChanges();
            }
        }
    }
}