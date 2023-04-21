namespace BLOG.Models
{
    public class UserPostLike
    {
        public Guid ID { get; set; }
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
    }
}
