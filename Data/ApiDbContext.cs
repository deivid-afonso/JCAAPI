using Microsoft.EntityFrameworkCore;

namespace JCAApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
        public DbSet<Models.UserModel> User { get; set; }

       public DbSet<Models.LoginModel> Login { get; set; }
    }
}
