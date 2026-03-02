using Microsoft.EntityFrameworkCore;
using Stormy_SilverioAP1_P1.DAL;
using Stormy_SilverioAP1_P1.Models;
using System.Linq.Expressions;
namespace Stormy_SilverioAP1_P1.Services;

public class EntradasHuacalesService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(EntradasHuacales huacal)
    {
        if (!await Existe(huacal.EntradaId))
            return await Insertar(huacal);
        else
            return await Modificar(huacal);
    }
    private async Task<bool> Existe(int entradaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.AnyAsync(e => e.EntradaId == entradaId);
    }
    public async Task<bool> ExisteDupliaco(EntradasHuacales entradas)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.AnyAsync(e => e.Nombre.ToLower() == entradas.Nombre.ToLower() && e.EntradaId != entradas.EntradaId);
    }
    private async Task<bool> Insertar(EntradasHuacales huacal)
    {
        await using var context = await DbFactory.CreateDbContextAsync();
        foreach (var det in huacal.ListaHuacales)
        {
            var tipo = await context.TiposHuacales.FindAsync(det.TipoId);
            if (tipo != null)
                tipo.Existencia += det.Cantidad;
            det.TiposHuacales = null;
        }

        context.EntradasHuacales.Add(huacal);
        return await context.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(EntradasHuacales entrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var entradaAnterior = await contexto.EntradasHuacales
            .Include(e => e.ListaHuacales)
            .FirstOrDefaultAsync(e => e.EntradaId == entrada.EntradaId);

        if (entradaAnterior == null) return false;

        foreach (var detalleAnt in entradaAnterior.ListaHuacales)
        {
            var tipo = await contexto.TiposHuacales.FindAsync(detalleAnt.TipoId);
            if (tipo != null)
                tipo.Existencia -= detalleAnt.Cantidad;
        }
        contexto.Set<DetallesHuacales>().RemoveRange(entradaAnterior.ListaHuacales);
        var nuevaListaDetalles = new List<DetallesHuacales>();
        foreach (var det in entrada.ListaHuacales)
        {
            var tipo = await contexto.TiposHuacales.FindAsync(det.TipoId);
            if (tipo != null)
                tipo.Existencia += det.Cantidad;
            nuevaListaDetalles.Add(
             new DetallesHuacales
             {
                 EntradaId = entradaAnterior.EntradaId,
                 TipoId = det.TipoId,
                 Cantidad = det.Cantidad,
                 Precio = det.Precio
             }
            );

        }
        contexto.Entry(entradaAnterior).CurrentValues.SetValues(entrada);
        entradaAnterior.ListaHuacales = nuevaListaDetalles;
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<EntradasHuacales?> Buscar(int huacalId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.Include(h => h.ListaHuacales).ThenInclude(d => d.TiposHuacales).FirstOrDefaultAsync(h => h.EntradaId == huacalId);
    }
    public async Task<bool> Eliminar(int entradaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var entrada = await contexto.EntradasHuacales.Include(h => h.ListaHuacales).FirstOrDefaultAsync(h => h.EntradaId == entradaId);
        foreach (var detalles in entrada.ListaHuacales)
        {
            var tipo = await contexto.TiposHuacales.FindAsync(detalles.TipoId);
            if (tipo != null)
            {
                tipo.Existencia -= detalles.Cantidad;
            }
        }
        contexto.Remove(entrada);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<List<EntradasHuacales>> Listar(Expression<Func<EntradasHuacales, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.Include(e => e.ListaHuacales).Where(criterio).AsNoTracking().ToListAsync();
    }
}