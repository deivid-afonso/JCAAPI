using Microsoft.EntityFrameworkCore;

namespace SimpressAPI.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<Models.tblProduto> Produtos { get; set; }

        public DbSet<Models.tblCategoriaProduto> Categorias { get; set; }
    }
}
