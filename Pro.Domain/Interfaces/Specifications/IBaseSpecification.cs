using System.Linq.Expressions;
using Pro.Domain.Models;

namespace Pro.Domain.Interfaces.Specifications
{
    public interface IBaseSpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>>? Critirea { get; protected set; }

        public Expression<Func<T, object>>? OrderBy { get; protected set; }

        public int Take { get; set; }
        public int Skip { get; set; }


    }
}
