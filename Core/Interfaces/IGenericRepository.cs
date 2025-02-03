// Core/Interfaces/IGenericRepository.cs
using Core.Interfaces;
using Core.Shared.Entities;

public interface IGenericRepository<T> where T : BaseEntity
{
    // Existing methods...
    Task<int> CountAsync(ISpecification<T> spec);
    Task<int> CountAsync();
    Task<T?> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    Task<bool> SaveAllAsync();
    Task<bool> ExistsAsync(int id);
}