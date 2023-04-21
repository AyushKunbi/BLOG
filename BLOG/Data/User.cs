using Microsoft.EntityFrameworkCore;
using BLOG.Models;

namespace BLOG.Data
{
    public class User:DbContext
    {
        public User(DbContextOptions<User> options):base(options) {}
        public DbSet<UserModel> Users { get; set; } //Future Update : add unique data
       
    }
}
