using Microsoft.EntityFrameworkCore;
using Stormy_SilverioAP1_P1.Models;
namespace Stormy_SilverioAP1_P1.DAL;
public class Contexto:DbContext
{
    public Contexto(DbContextOptions<Contexto> options): base(options) { }

    public DbSet<EntradasHuacales> EntradasHuacales { get; set; }
    public DbSet<DetallesHuacales> DetallesHuacales { get; set; }
    public DbSet<TiposHuacales> TiposHuacales { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TiposHuacales>().HasData(new List<TiposHuacales>
        {
            new TiposHuacales(){TipoId=1, Descripcion="Rojo", Existencia = 0},
            new TiposHuacales(){TipoId=2, Descripcion="Verde", Existencia = 0},
            new TiposHuacales(){TipoId=3, Descripcion="Azul", Existencia = 0}
        });
    }
}