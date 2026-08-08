using LMS.Application.Abstractions.Repositories.Base;
using LMS.Application.Abstractions.Repositories.Communication;
using LMS.Domain.Entities.Communication.Discussions;
using LMS.Domain.Entities.Communication.GradeConsultations;
using LMS.Domain.Entities.Communication.LessonDiscussions;
using LMS.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

namespace LMS.Infrastructure.Persistence.Repositories.Communication
{
    public class DisccusionRepository : Repository<DiscussionThread>, IDiscussionRepository
    {
        public DisccusionRepository(ApplicationDbContext context) : base(context) { }

        public async Task<DiscussionThread?> GetByIdWithRepliesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.DiscussionThreads
                .Include(c => c.Replies)
                .FirstOrDefaultAsync(y => y.Id == id, cancellationToken);
        }

        public async Task<List<DiscussionThread>> GetByContextAsync(Guid contextId, DiscussionContextType contextType, CancellationToken cancellationToken = default)
        {
            return await _dbContext.DiscussionThreads
                .Where(a => a.ContextId == contextId && a.ContextType == contextType)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync(cancellationToken);
        }
    }
}