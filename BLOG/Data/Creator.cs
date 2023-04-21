using Microsoft.EntityFrameworkCore;
using BLOG.Models;

namespace BLOG.Data
{
    public class Creator:DbContext
    {
        public Creator(DbContextOptions<Creator> options):base(options) { }
        public DbSet<CreatorModel> Creators { get; set; }
    }
}
