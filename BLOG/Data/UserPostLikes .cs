using Microsoft.EntityFrameworkCore;
using BLOG.Models;

namespace BLOG.Data
{
    public class UserPostLikes : DbContext
    {
        public UserPostLikes(DbContextOptions<UserPostLikes> options) : base(options) { }
         public DbSet<UserPostLike> Likes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPostLike>()
                .HasIndex(upl => new { upl.UserId, upl.PostId })
                .IsUnique();
        }

    }
}
