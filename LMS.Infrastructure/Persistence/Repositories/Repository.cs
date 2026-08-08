using LMS.Application.Abstractions.Repositories.Base;
using LMS.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Infrastructure.Persistence.Repositories
{
    public abstract class Repository<TAggregate> : IRepository<TAggregate> where TAggregate : AggregateRoot
    {
        protected readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }   

        public async Task AddAsync(TAggregate aggregate, CancellationToken cancellationToken)
        {
            await _dbContext.Set<TAggregate>().AddAsync(aggregate, cancellationToken);
        }

        public async Task<TAggregate?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<TAggregate>().FindAsync(new object[] { id }, cancellationToken);
        }

        public void Remove(TAggregate aggregate)
        {
            _dbContext.Set<TAggregate>().Remove(aggregate);
        }

        public void Update(TAggregate aggregate)
        {
            _dbContext.Set<TAggregate>().Update(aggregate);
        }
    }
}
