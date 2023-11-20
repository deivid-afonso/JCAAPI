using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting.Server;

namespace JCAApi.Data
{
    public class ApiDbContextFactory : IDesignTimeDbContextFactory<ApiDbContext>
    {
        public ApiDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();
            optionsBuilder.UseSqlServer("Server=DVD;Database=JCA;User Id=sa;Password=123;TrustServerCertificate=True;");

            return new ApiDbContext(optionsBuilder.Options);
        }
    }

}
