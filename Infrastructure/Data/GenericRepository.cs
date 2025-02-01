using Core.Interfaces;
using Core.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class GenericRepository<T>(DataContext context) : IGenericRepository<T> where T : BaseEntity
{
    public void Add(T entity) => context.Set<T>().Add(entity);

    public async Task<bool> ExistsAsync(int id)
        => await context.Set<T>().AnyAsync(x => x.Id == id);

    public async Task<T?> GetByIdAsync(int id)
        => await context.Set<T>().FindAsync(id);

    public async Task<IReadOnlyList<T>> ListAllAsync()
        => await context.Set<T>().ToListAsync();

    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        => await ApplySpecification(spec).ToListAsync();

    public void Remove(T entity)
    {
        if (entity is ISoftDelete softDeleteEntity)
        {
            softDeleteEntity.IsDeleted = true;
            softDeleteEntity.DeletedAt = DateTime.UtcNow;
            context.Set<T>().Update(entity);
        }
        else
        {
            context.Set<T>().Remove(entity);
        }
    }

    public async Task<bool> SaveAllAsync()
        => await context.SaveChangesAsync() > 0;

    public void Update(T entity)
    {
        context.Set<T>().Attach(entity);
        context.Entry(entity).State = EntityState.Modified;
    }

    public async Task<int> CountAsync(ISpecification<T> spec)
        => await ApplySpecificationForCount(spec).CountAsync();

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        => SpecificationEvaluator<T>.GetQuery(context.Set<T>().AsQueryable(), spec);

    private IQueryable<T> ApplySpecificationForCount(ISpecification<T> spec)
        => SpecificationEvaluator<T>.GetQueryForCount(context.Set<T>().AsQueryable(), spec);
}