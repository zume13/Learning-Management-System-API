using LMS.Application.Abstractions.Repositories.Communication;
using LMS.Domain.Entities.Notifications;
using LMS.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Infrastructure.Persistence.Repositories.Communication
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;

        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Notification aggregate, CancellationToken cancellationToken = default)
        {
            await _context.Notifications.AddAsync(aggregate, cancellationToken);
        }

        public async Task<Notification> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var notification = await _context.Notifications.FindAsync(new object[] { id }, cancellationToken);

            if (notification == null)
                throw new InvalidOperationException("Notification not found");

            return notification;
        }

        public void RemoveAsync(Notification aggregate)
        {
            _context.Notifications.Remove(aggregate);
        }

        public void UpdateAsync(Notification aggregate)
        {
            _context.Notifications.Update(aggregate);
        }

        // Full notif history
        public async Task<List<Notification>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _context.Notifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync(cancellationToken);
        }

        // Unread
        public async Task<List<Notification>> GetUnreadByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _context.Notifications
                .Where(n => n.UserId == userId && !n.Read)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync(cancellationToken);
        }

        // Hit that bell icon
        public async Task<int> CountUnreadAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _context.Notifications
                .CountAsync(n => n.UserId == userId && !n.Read, cancellationToken);
        }
    }
}