using System.Linq.Expressions;

namespace Core.Interfaces;

public interface ISpecification<T>
{
    // Filtering
    Expression<Func<T, bool>>? Criteria { get; }

    // Includes (eager loading)
    List<Expression<Func<T, object>>> Includes { get; }
    List<string> IncludeStrings { get; }  // Add for string-based includes

    // Ordering
    Expression<Func<T, object>>? OrderBy { get; }
    Expression<Func<T, object>>? OrderByDescending { get; }

    // Distinct
    bool IsDistinct { get; }

    // Pagination
    int Take { get; }
    int Skip { get; }
    bool IsPagingEnabled { get; }
}

public interface ISpecification<T, TResult> : ISpecification<T>
{
    Expression<Func<T, TResult>>? Select { get; }
}
