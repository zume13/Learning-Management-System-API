using LMS.Application.Abstractions.Repositories.Identity;
using LMS.Domain.Entities.Identity.Users;
using LMS.Domain.ValueObjects;
using LMS.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Infrastructure.Persistence.Repositories
{
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(
            string email,
            CancellationToken cancellationToken = default)
        {
            return await _context.Users
                .FirstOrDefaultAsync(
                    user => user.Email.value == email,
                    cancellationToken);
        }

        public async Task<bool> EmailExistsAsync(
            string email,
            CancellationToken cancellationToken = default)
        {
            return await _context.Users
                .AnyAsync(
                    user => user.Email.value == email,
                    cancellationToken);
        }
    }
}
