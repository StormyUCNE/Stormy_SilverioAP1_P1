using Microsoft.EntityFrameworkCore;
using Stormy_SilverioAP1_P1.DAL;
using Stormy_SilverioAP1_P1.Models;
using System.Linq.Expressions;
namespace Stormy_SilverioAP1_P1.Services;
public class TiposHuacalesService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<List<TiposHuacales>> Listar(Expression<Func<TiposHuacales, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposHuacales.Where(criterio).AsNoTracking().ToListAsync();
    }
}