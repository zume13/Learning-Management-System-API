using SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Application.Abstractions.Repositories
{
    public interface IRepository<TAggregate> where TAggregate : AggregateRoot 
    {
        Task<ResultT<TAggregate>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Result> AddAsync(TAggregate aggregate, CancellationToken cancellationToken = default);

        Task<Result> UpdateAsync(TAggregate aggregate, CancellationToken cancellationToken = default);

        Task<Result> RemoveAsync(TAggregate aggregate, CancellationToken cancellationToken = default);
    }
}
