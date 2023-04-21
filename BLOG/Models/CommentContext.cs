using Microsoft.EntityFrameworkCore;

namespace BLOG.Models
{
    public class CommentContext
    {
        public Guid ID { get; set; }
        public string Comments { get; set; }
        public string Uname { get; set; }
        public Guid BlogPostId { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
    }
}
