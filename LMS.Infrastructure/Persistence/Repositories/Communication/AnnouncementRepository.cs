using LMS.Application.Abstractions.Repositories.Communication;
using LMS.Domain.Entities.Communication;
using LMS.Domain.Entities.Communication.GradeConsultations;
using LMS.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Infrastructure.Persistence.Repositories.Communication
{
    public class AnnouncementRepository : Repository<Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(ApplicationDbContext context) : base(context) { }

        // All announcements for a single course
        public async Task<List<Announcement>> GetByCourseIdAsync(Guid courseId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Announcements
                .Where(c => c.CourseId == courseId)
                .OrderByDescending(h => h.CreatedAt)
                .ToListAsync(cancellationToken);
        }

        // Same thing but for pinned
        public async Task<List<Announcement>> GetPinnedByCourseIdAsync(Guid courseId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Announcements
                .Where(e => e.CourseId == courseId && e.Pinned)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync(cancellationToken);
        }
    }
}
