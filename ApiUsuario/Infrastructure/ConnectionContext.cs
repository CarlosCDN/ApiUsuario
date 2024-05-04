using ApiUsuario.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ApiUsuario.Infrastructure;

public class ConnectionContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<AuthToken> AuthTokens {  get; set; }
    public DbSet<AccessHistory> AccessHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<User>().HasKey(u => u.UsuarioId);
        modelBuilder.Entity<User>().ToTable("usuario");
        modelBuilder.Entity<AuthToken>().ToTable("auth_tokens");
        // modelBuilder.Entity<AccessHistory>().ToTable("Histories");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=loja_virtual;User=root;Password=Jussara/1405;";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

    }

}
