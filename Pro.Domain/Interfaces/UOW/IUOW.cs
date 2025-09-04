using Pro.Domain.Interfaces.Repos;
using Pro.Domain.Models;

namespace Pro.Domain.Interfaces.UOW
{
    public interface IUOW : IAsyncDisposable
    {
        IBaseRepo<TRepo> GetRepo<TRepo>() where TRepo : BaseEntity;
        Task<int> SaveAsync();

    }
}
