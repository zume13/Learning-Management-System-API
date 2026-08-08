using LMS.Application.Abstractions.Repositories.Base;
using LMS.Domain.Entities.Communication;

namespace LMS.Application.Abstractions.Repositories.Communication
{
    public interface IAnnouncementRepository : IRepository<Announcement>
    {
        Task<List<Announcement>> GetByCourseIdAsync(Guid courseId, CancellationToken cancellationToken = default);
        Task<List<Announcement>> GetPinnedByCourseIdAsync(Guid courseId, CancellationToken cancellation = default);
    }
}
