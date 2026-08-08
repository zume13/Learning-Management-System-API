using LMS.Domain.Entities.Communication;
using LMS.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Infrastructure.Persistence.Repositories.Communication
{
    public class AnnouncementRepository
    {
        private readonly ApplicationDbContext _context;

        public AnnouncementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Announcement aggregate, CancellationToken cancellationToken = default)
        {
            await _context.Announcements.AddAsync(aggregate, cancellationToken);
        }

        public async Task<Announcement> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var announcement = await _context.Announcements.FindAsync(id, cancellationToken);

            if (announcement == null)
                throw new InvalidOperationException("No Announcement??");

            return announcement;
        }

        public void RemoveAsync(Announcement aggregate)
        {
            _context.Announcements.Remove(aggregate);
        }

        public void UpdateAsync(Announcement aggregate)
        {
            _context.Announcements.Update(aggregate);
        }

        // All announcements for a single course
        public async Task<List<Announcement>> GetByCourseIdAsync(Guid courseId, CancellationToken cancellationToken = default)
        {
            return await _context.Announcements
                .Where(c => c.CourseId == courseId)
                .OrderByDescending(h => h.CreatedAt)
                .ToListAsync(cancellationToken);
        }

        // Same thing but for pinned
        public async Task<List<Announcement>> GetPinnedByCourseIdAsync(Guid courseId, CancellationToken cancellationToken = default)
        {
            return await _context.Announcements
                .Where(e => e.CourseId == courseId && e.Pinned)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync(cancellationToken);
        }
    }
}
