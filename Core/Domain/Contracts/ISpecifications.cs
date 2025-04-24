

using System.Linq.Expressions;

namespace Domain.Contracts
{
    public interface ISpecifications<T> where T : class
    {
        Expression<Func<T, bool>> Criteria { get; } 

        List<Expression<Func<T, object>>> IncludeExpressions { get; }
        Expression<Func<T, object>>? OrderBy { get; }
        Expression<Func<T, object>>? OrderByDescending { get; }
        public int Take { get; }
        public int Skip { get; }
        public bool IsPaginated { get; }
    }
}

// where => Criteria Expression <func<T, bool>>
// include => List<Expression<Func<T, object>>>
// select Criteria Expression<Func<T, TResult>>
