using Locadora.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Data
{
  public class AppDbContext : DbContext
  {

    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    { }

    public DbSet<Locacao> Locacoes { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Filme> Filmes { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //  => optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
  }
}
