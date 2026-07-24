using LMS.Domain.Entities.Communication.Notifications;
using LMS.SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Notifications;

public class Notification : Entity
{
    private Notification(
        Guid id,
        Guid userId,
        NotificationType type,
        string message) : base(id)
    {
        UserId = userId;
        Type = type;
        Message = message;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid UserId { get; }

    public NotificationType Type { get; }

    public string Message { get; }

    public bool Read { get; private set; }

    public DateTime CreatedAt { get; }

    public static ResultT<Notification> Create(
        Guid userId,
        NotificationType type,
        string message)
    {
        if (string.IsNullOrWhiteSpace(message))
            return GeneralErrors.General.Empty(nameof(message));

        return new Notification(
            Guid.NewGuid(),
            userId,
            type,
            message);
    }

    public void MarkAsRead()
    {
        Read = true;
    }
}