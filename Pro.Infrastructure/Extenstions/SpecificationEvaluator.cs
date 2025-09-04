using Pro.Domain.Interfaces.Specifications;
using Pro.Domain.Models;

namespace Pro.Infrastructure.Extenstions
{
    public static class SpecificationEvaluator
    {

        public static IQueryable<T> EvaluateQuery<T>(this IQueryable<T> queryable, IBaseSpecification<T> baseSpecification) where T : BaseEntity
        {

            if (baseSpecification == null || baseSpecification.Critirea == null)
            {
                return queryable;
            }

            if (baseSpecification.OrderBy != null)
                queryable.OrderBy(baseSpecification.OrderBy);


            return queryable.Where(baseSpecification.Critirea);

        }

        public static IQueryable<TResult> EvaluateQuery<T, TResult>
        (
            this IQueryable<T> queryable,
            IProjectionSpecification<T, TResult> projectionSpecification
        )
            where T : BaseEntity
            where TResult : class
        {

            return queryable
                .EvaluateQuery<T>(projectionSpecification)
                .Select(projectionSpecification.Projection
                ?? throw new ArgumentNullException(nameof(projectionSpecification.Projection),
                "Projection cannot be null."));

        }

    }
}
