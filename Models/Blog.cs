public class Blog
{
    public int Id { get; set; }
    public string Url { get; set; }
    public List<Post> Posts { get; } = new List<Post>();

    public override string ToString()
    {
        return $"Id: {Id} Url: {Url}";
    }
}