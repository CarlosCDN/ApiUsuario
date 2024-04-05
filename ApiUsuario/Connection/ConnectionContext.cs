using Microsoft.EntityFrameworkCore;
using ApiUsuario.Model;
using Microsoft.AspNetCore.Connections;

namespace ApiUsuario.Connection
{
    public class ConnectionContext : DbContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=loja_virtual;User=root;Password=Jussara/1405;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        }

    }
}
