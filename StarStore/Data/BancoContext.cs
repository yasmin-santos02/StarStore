using Microsoft.EntityFrameworkCore;
using StarStore.Models;

namespace StarStore.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }

        public DbSet<LoginModel> Usuarios { get; set; }
    }
}
