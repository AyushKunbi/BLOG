namespace BLOG.Models
{
    public class AddUT
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Status { get; set; }
        public string StatusMessage { get; set; } = string.Empty;
    }
}
