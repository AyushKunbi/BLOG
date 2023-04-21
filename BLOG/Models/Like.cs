namespace BLOG.Models
{
    public class Like
    {
        public int Id { get; set; }
        public Guid BlogPostId { get; set; }
        public string UserId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
