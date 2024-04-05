using Microsoft.EntityFrameworkCore;
using ApiUsuario.Model;

namespace ApiUsuario.Connection
{
    public class ConnectionContext : DbContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
            "Server=localhost;" +
            "Port=5432;" +
            "Database=LojaVirtual;" +
            "User id=postgres;" +
            "Password=jUSSARA/1405;");

        }

    }
}
