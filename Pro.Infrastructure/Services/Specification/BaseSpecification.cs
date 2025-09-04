using System.Linq.Expressions;
using Pro.Domain.Interfaces.Specifications;
using Pro.Domain.Models;

namespace Pro.Infrastructure.Services.Specification
{
    public class BaseSpecification<T> : IBaseSpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>>? Critirea { get; set; }
        public Expression<Func<T, object>>? OrderBy { get; set; }

        public int Take { get; set; }
        public int Skip { get; set; }

        protected void AddCritirea(Expression<Func<T, bool>> expression)
        {
            Critirea = expression;
        }

        public void AddPaging(int pageSize, int pageNumber)
        {
            Take = pageSize;
            Skip = (pageNumber - 1) * pageSize;
        }

        public void AddSortBy(Expression<Func<T, object>> expression)
        {
            OrderBy = expression;
        }



    }
}
