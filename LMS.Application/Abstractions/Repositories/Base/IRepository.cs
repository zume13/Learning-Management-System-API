using SharedKernel.Primitives;

namespace LMS.Application.Abstractions.Repositories.Base
{
    public interface IRepository<TAggregate> where TAggregate : AggregateRoot 
    {
        Task<TAggregate> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task AddAsync(TAggregate aggregate, CancellationToken cancellationToken = default);

        void UpdateAsync(TAggregate aggregate);

        void RemoveAsync(TAggregate aggregate);
    }
}
