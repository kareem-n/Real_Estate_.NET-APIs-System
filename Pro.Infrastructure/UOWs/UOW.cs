using Pro.Domain.Interfaces.Repos;
using Pro.Domain.Interfaces.UOW;
using Pro.Domain.Models;
using Pro.Infrastructure.Data;
using Pro.Infrastructure.Repos;

namespace Pro.Infrastructure.UOWs
{
    public class UOW : IUOW
    {
        private readonly AppDbContext _dbContext;

        private readonly Dictionary<Type, object> BaseRepos = [];

        public UOW(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IBaseRepo<TRepo> GetRepo<TRepo>() where TRepo : BaseEntity
        {
            var type = typeof(TRepo);
            if (!BaseRepos.ContainsKey(type))
            {
                BaseRepos[type] = new BaseRepo<TRepo>(_dbContext);
            }

            return (IBaseRepo<TRepo>)BaseRepos[type];

        }


        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public Task<int> SaveAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
