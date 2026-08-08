using LMS.Application.Abstractions.Repositories.Base;
using LMS.Domain.Entities.Notifications;

namespace LMS.Application.Abstractions.Repositories.Communication
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Task<List<Notification>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<List<Notification>> GetUnreadByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<int> CountUnreadAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}
