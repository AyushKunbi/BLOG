using Microsoft.EntityFrameworkCore;
using BLOG.Models;

namespace BLOG.Data
{
    public class Comments:DbContext
    {
        public Comments(DbContextOptions<Comments> options) : base(options) { }
        public DbSet<UComments> Comment { get; set; }

    }
}
