using (var context = new BloggingContext())
{
    Console.WriteLine("--- Inserting a new blog ---");
    context.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
    context.SaveChanges();

    Console.WriteLine("--- Retrieve blog with lowest id ---");
    var blog = context.Blogs
        .OrderBy(b => b.Id)
        .First();

    Console.WriteLine("--- Updating the blog and adding a post ---");
    blog.Url = "https://devblogs.microsoft.com/dotnet";
    blog.Posts.Add(
        new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
    context.SaveChanges();

    Console.WriteLine("--- Querying all blogs containing 'dotnet' in their URL ---");
    var query = context.Blogs.Where(b => b.Url.Contains("dotnet"));
    var blogs = query.ToList();
    foreach (Blog b in blogs)
        Console.WriteLine(b);

    Console.WriteLine("--- Deleting the blog ---");
    context.Remove(blog);
    context.SaveChanges();
}