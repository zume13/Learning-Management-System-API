using SharedKernel.Shared;

namespace LMS.Application.Abstractions.Repositories.Base
{
    public interface IUnitOfWork
    {
        Task<Result> SaveChangesAsync(
            CancellationToken cancellationToken = default);
    }
}
