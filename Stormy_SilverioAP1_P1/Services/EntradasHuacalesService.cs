using Microsoft.EntityFrameworkCore;
using Stormy_SilverioAP1_P1.DAL;
using Stormy_SilverioAP1_P1.Models;
using System.Linq.Expressions;
namespace Stormy_SilverioAP1_P1.Services;

public class EntradasHuacalesService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(EntradasHuacales huacal)
    {
        if (!await Existe(huacal.IdEntrada))
            return await Insertar(huacal);
        else
            return await Modificar(huacal);
    }

    private async Task<bool> Existe(int huacalId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.AnyAsync(h => h.IdEntrada == huacalId);
    }

    private async Task<bool> Insertar(EntradasHuacales huacal)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.EntradasHuacales.Add(huacal);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(EntradasHuacales huacal)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(huacal);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<EntradasHuacales?> Buscar(int huacalId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.FirstOrDefaultAsync(h => h.IdEntrada == huacalId);
    }

    public async Task<bool> Eliminar(int huacalId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.AsNoTracking().Where(h => h.IdEntrada == huacalId).ExecuteDeleteAsync() > 0;
    }

    public async Task<List<EntradasHuacales>> Listar(Expression<Func<EntradasHuacales, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.Where(criterio).AsNoTracking().ToListAsync();
    }
}