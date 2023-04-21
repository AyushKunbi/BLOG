using Microsoft.EntityFrameworkCore;
using BLOG.Models;

namespace BLOG.Data
{
    public class Content:DbContext
    {
        public Content(DbContextOptions<Content>options):base(options) { }
        public DbSet<ContentModel>Contents { get; set; }
       


    }
}
