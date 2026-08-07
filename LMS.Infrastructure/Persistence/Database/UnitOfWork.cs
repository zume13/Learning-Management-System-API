using LMS.Application.Abstractions.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Shared;

namespace LMS.Infrastructure.Persistence.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result> SaveChangesAsync(CancellationToken ct = default)
        {
            try
            {
                await _context.SaveChangesAsync(ct);
                return Result.Success();
            }
            catch (DbUpdateException ex)
            {
                return Result.Failure(Error.Failure("DB.UpdateException", $"Db failed to be updated, Error: {ex.Message}"));
            }
            catch (Exception ex)
            {
                return Result.Failure(Error.Failure("Unexpected.Error", $"An unexpected error occurred: {ex.Message}"));
            }
        }
    }
}
