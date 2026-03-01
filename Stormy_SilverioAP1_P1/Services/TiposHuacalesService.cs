using Microsoft.EntityFrameworkCore;
using Stormy_SilverioAP1_P1.DAL;
using Stormy_SilverioAP1_P1.Models;
using System.Linq.Expressions;
namespace Stormy_SilverioAP1_P1.Services;
public class TiposHuacalesService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(TiposHuacales tipo)
    {
        if (!await Existe(tipo.TipoId))
            return await Insertar(tipo);
        else
            return await Modificar(tipo);
    }
    private async Task<bool> Existe(int tipoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposHuacales.AnyAsync(t => t.TipoId == tipoId);
    }
    public async Task<bool> ExisteDuplicado(TiposHuacales tipo)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposHuacales.AnyAsync(t => t.Descripcion == tipo.Descripcion && t.TipoId != tipo.TipoId);
    }
    private async Task<bool> Insertar(TiposHuacales tipo)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.TiposHuacales.Add(tipo);
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(TiposHuacales tipo)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(tipo);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<TiposHuacales?> Buscar(int tipoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposHuacales.FirstOrDefaultAsync(t => t.TipoId == tipoId);
    }
    public async Task<bool> Eliminar(int tipoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposHuacales.AsNoTracking().Where(t => t.TipoId == tipoId).ExecuteDeleteAsync() > 0;
    }
    public async Task<List<TiposHuacales>> Listar(Expression<Func<TiposHuacales, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposHuacales.Where(criterio).AsNoTracking().ToListAsync();
    }
}