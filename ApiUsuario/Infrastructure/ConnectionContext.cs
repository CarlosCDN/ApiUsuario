using ApiUsuario.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiUsuario.Infrastructure;

public class ConnectionContext : DbContext
{
    public DbSet<User> User { get; set; }

    public DbSet<User> Token {  get; set; }

    public DbSet<User> LogAcess { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=loja_virtual;User=root;Password=Jussara/1405;";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

    }

}
