using Microsoft.EntityFrameworkCore;
using UserAPI.Model;

namespace UserAPI.Context
{
    public class UserDbContext:DbContext
    {
        public UserDbContext()
        {

        }
        public UserDbContext(DbContextOptions<UserDbContext> Context) : base(Context)
        {

        }
        public DbSet<User> UserList { get; set; }
    }
}
