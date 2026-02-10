using Microsoft.EntityFrameworkCore;
using Stormy_SilverioAP1_P1.Models;
namespace Stormy_SilverioAP1_P1.DAL;
public class Contexto:DbContext
{
    public Contexto(DbContextOptions<Contexto> options): base(options) { }

    public DbSet<EntradasHuacales> EntradasHuacales { get; set; }
}