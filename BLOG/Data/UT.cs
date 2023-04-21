using Microsoft.EntityFrameworkCore;
using BLOG.Models;

namespace BLOG.Data
{
    public class UT:DbContext
    {
        public UT(DbContextOptions<UT>options):base (options) { }
        public DbSet<UserThoughts> UThought { get; set; }
    }
}
