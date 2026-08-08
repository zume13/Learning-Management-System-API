using LMS.Application.Abstractions.Repositories.Base;
using LMS.Domain.Entities.Communication.Discussions;
using LMS.Domain.Entities.Communication.LessonDiscussions;

namespace LMS.Application.Abstractions.Repositories.Communication
{
    public interface IDiscussionRepository : IRepository<DiscussionThread>
    {
        Task<DiscussionThread?> GetByIdWithRepliesAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<DiscussionThread>> GetByContextAsync(Guid contextId, DiscussionContextType contextType, CancellationToken cancellationToken = default);
    }
}