using LMS.Application.Abstractions.Repositories.Communication;
using LMS.Domain.Entities.Communication.GradeConsultations;
using LMS.Domain.Entities.Notifications;
using LMS.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Infrastructure.Persistence.Repositories.Communication
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext context) : base(context) { }

        // Full notif history
        public async Task<List<Notification>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Notifications
                .Where(s => s.UserId == userId)
                .OrderByDescending(e => e.CreatedAt)
                .ToListAsync(cancellationToken);
        }

        // Unread
        public async Task<List<Notification>> GetUnreadByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Notifications
                .Where(i => i.UserId == userId && !i.Read)
                .OrderByDescending(z => z.CreatedAt)
                .ToListAsync(cancellationToken);
        }

        // Hit that bell icon
        public async Task<int> CountUnreadAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Notifications
                .CountAsync(e => e.UserId == userId && !e.Read, cancellationToken);
        }
    }
}