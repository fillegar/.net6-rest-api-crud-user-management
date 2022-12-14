using Microsoft.EntityFrameworkCore;
using User.Core.Model;

namespace User.Repository
{
    public class UserInfoDbContext : DbContext
    {
        static UserInfoDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        public DbSet<UserInfo> UserInfos { get; set; }

        public UserInfoDbContext(DbContextOptions<UserInfoDbContext> options)
            : base(options)
        {
        }
    }
}
