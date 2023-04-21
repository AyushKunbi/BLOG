namespace BLOG.Models
{
    public class ContentModel
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int LikeCount { get; set; }
        public int DisLikeCount { get; set; }
        public Guid KeyID1 { get; set; }
        public Guid KeyID2 { get; set; }
    }
}
