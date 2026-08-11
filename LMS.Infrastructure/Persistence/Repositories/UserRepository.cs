using LMS.Application.Abstractions.Repositories.Identity;
using LMS.Domain.Entities.Identity.Users;
using LMS.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Persistence.Repositories;

public sealed class UserRepository : Repository<User>, IUserRepository
{

    public UserRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<User?> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(
                user => user.Email.value == email,
                cancellationToken);
    }

    public async Task<bool> EmailExistsAsync(
        string email,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users
            .AnyAsync(
                user => user.Email.value == email,
                cancellationToken);
    }
}