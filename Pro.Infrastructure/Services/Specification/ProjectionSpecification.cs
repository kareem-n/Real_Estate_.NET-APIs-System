using System.Linq.Expressions;
using Pro.Domain.Interfaces.Specifications;
using Pro.Domain.Models;

namespace Pro.Infrastructure.Services.Specification
{
    public class ProjectionSpecification<T, TResult> : BaseSpecification<T>, IProjectionSpecification<T, TResult>
        where T : BaseEntity
   where TResult : class
    {
        public Expression<Func<T, TResult>> Projection { get; set; } = default!;


        protected void AddProjection(Expression<Func<T, TResult>> expression)
        {
            Projection = expression ?? throw new ArgumentNullException(nameof(expression), "Projection expression cannot be null.");
        }
    }
}
