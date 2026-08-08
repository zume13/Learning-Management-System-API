using LMS.Application.Abstractions.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Shared;

namespace LMS.Infrastructure.Persistence.Database;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        try
        {
            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
        catch (DbUpdateException)
        {
            return Result.Failure(
                Error.Failure(
                    "Database.UpdateFailed",
                    "The database update failed."));
        }
        catch (Exception)
        {
            return Result.Failure(
                Error.Failure(
                    "Database.UnexpectedError",
                    "An unexpected database error occurred."));
        }
    }
}