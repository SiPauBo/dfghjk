using System.Linq.Expressions;
using Blazor_EFL_VIEW.Data;

namespace Blazor_EFL_VIEW.Classes;

using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public TEntity Create(TEntity t) => _context.Set<TEntity>().Add(t).Entity;

    public List<TEntity> CreateRange(List<TEntity> list)
    {
        _context.Set<TEntity>().AddRange(list);
        return list;
    }

    public void Updata(TEntity t) => _context.Set<TEntity>().Update(t);

    public void UpdateRange(List<TEntity> list) => _context.Set<TEntity>().UpdateRange(list);

    public TEntity? Read(int id) => _context.Set<TEntity>().Find(id);

    public List<TEntity> Read(Expression<Func<TEntity, bool>> filter) =>
        _context.Set<TEntity>().Where(filter).ToList();

    public List<TEntity> Read(int start, int count) =>
        _context.Set<TEntity>().Skip(start).Take(count).ToList();

    public List<TEntity> ReadAll() => _context.Set<TEntity>().ToList();

    public void Delete(TEntity t) => _context.Set<TEntity>().Remove(t);
}
