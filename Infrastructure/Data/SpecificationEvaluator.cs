using Core.Interfaces;
using Core.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class SpecificationEvaluator<T> where T : BaseEntity
{
    public static IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> spec)
    {
        query = HandleCriteria(query, spec);
        query = HandleIncludes(query, spec);
        query = HandleOrdering(query, spec);
        query = HandleDistinct(query, spec);
        query = HandlePaging(query, spec);
        return query;
    }

    public static IQueryable<T> GetQueryForCount(IQueryable<T> query, ISpecification<T> spec)
    {
        query = HandleCriteria(query, spec);
        query = HandleIncludes(query, spec);
        query = HandleDistinct(query, spec);
        return query;
    }

    public static IQueryable<TResult> GetQuery<TResult>(IQueryable<T> query, ISpecification<T, TResult> spec)
    {
        if (spec.Select == null)
            throw new InvalidOperationException("Select expression is required for projection");

        var baseQuery = GetQuery(query, (ISpecification<T>)spec);
        var projectedQuery = baseQuery.Select(spec.Select);

        if (spec.IsDistinct)
            projectedQuery = projectedQuery.Distinct();

        return projectedQuery;
    }

    // Existing private handlers below...
    private static IQueryable<T> HandleCriteria(IQueryable<T> query, ISpecification<T> spec)
        => spec.Criteria != null ? query.Where(spec.Criteria) : query;

    private static IQueryable<T> HandleIncludes(IQueryable<T> query, ISpecification<T> spec)
    {
        query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
        query = spec.IncludeStrings.Aggregate(query,
            (current, include) => current.Include(include));
        return query;
    }

    private static IQueryable<T> HandleOrdering(IQueryable<T> query, ISpecification<T> spec)
    {
        if (spec.OrderBy != null) return query.OrderBy(spec.OrderBy);
        if (spec.OrderByDescending != null) return query.OrderByDescending(spec.OrderByDescending);
        return query;
    }

    private static IQueryable<T> HandleDistinct(IQueryable<T> query, ISpecification<T> spec)
        => spec.IsDistinct ? query.Distinct() : query;

    private static IQueryable<T> HandlePaging(IQueryable<T> query, ISpecification<T> spec)
        => spec.IsPagingEnabled ? query.Skip(spec.Skip).Take(spec.Take) : query;
}