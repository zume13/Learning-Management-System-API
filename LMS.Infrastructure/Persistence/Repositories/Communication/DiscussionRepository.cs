using LMS.Application.Abstractions.Repositories.Base;
using LMS.Application.Abstractions.Repositories.Communication;
using LMS.Domain.Entities.Communication.Discussions;
using LMS.Domain.Entities.Communication.LessonDiscussions;
using LMS.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

namespace LMS.Infrastructure.Persistence.Repositories.Communication
{
    public class DiscussionRepository : IDiscussionRepository
    {
        private readonly ApplicationDbContext _context;

        public DiscussionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DiscussionThread aggregate, CancellationToken cancellationToken = default)
        {
            await _context.DiscussionThreads.AddAsync(aggregate, cancellationToken);
        }

        public async Task<DiscussionThread?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var thread = await _context.DiscussionThreads.FindAsync( id, cancellationToken);

            if (thread == null)
                throw new InvalidOperationException("Discussion thread be gone.");

            return thread;
        }

        public void RemoveAsync(DiscussionThread aggregate)
        {
            _context.DiscussionThreads.Remove(aggregate);
        }

        public void UpdateAsync(DiscussionThread aggregate)
        {
            _context.DiscussionThreads.Update(aggregate);
        }

        public async Task<DiscussionThread?> GetByIdWithRepliesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.DiscussionThreads
                .Include(c => c.Replies)
                .FirstOrDefaultAsync(y => y.Id == id, cancellationToken);
        }

        public async Task<List<DiscussionThread>> GetByContextAsync(Guid contextId, DiscussionContextType contextType, CancellationToken cancellationToken = default)
        {
            return await _context.DiscussionThreads
                .Where(a => a.ContextId == contextId && a.ContextType == contextType)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync(cancellationToken);
        }
    }
}