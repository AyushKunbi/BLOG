namespace BLOG.Models
{
    public class AddComments
    {
        public Guid ID { get; set; }
        public string UComment { get; set; }
        public string Uname { get; set; }
        public Guid BlogPostId { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
    }
}
