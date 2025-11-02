using ComplicadaMente.Components.Models;
namespace ComplicadaMente.Components.Data;

// File: Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Puzzle> Puzzle { get; set; }
    public DbSet<Cliente> Cliente { get; set;}
    public DbSet<Encomenda> Encomenda { get; set;}
    public DbSet<EncomendaPuzzle> EncomendaPuzzle { get; set;}
    public DbSet<Funcionario> Funcionario { get; set;}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Puzzle>(entity =>
        {
            entity.Property(e => e.Preco).HasColumnType("decimal(18,2)");
        });
        
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.Property(e => e.Email).IsRequired();
        }); 
      modelBuilder.Entity<EncomendaPuzzle>(entity =>
        {
            entity.HasKey(s => new { s.ID_Encomenda, s.ID_Puzzle });
        });

    }
}



