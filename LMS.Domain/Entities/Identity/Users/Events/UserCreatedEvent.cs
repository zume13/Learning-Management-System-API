using SharedKernel.DomainEvent;

namespace LMS.Domain.Entities.Identity.Users.Events
{
    public record UserCreatedEvent(Guid userId) : IDomainEvent
    {
        public string DomainEventName => DomainEventsNames.UserEventNames.UserCreated;
    }
}
