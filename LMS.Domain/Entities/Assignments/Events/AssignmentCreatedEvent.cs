using SharedKernel.DomainEvent;

namespace LMS.Domain.Entities.Assignments.Events
{
    public record AssignmentCreatedEvent : IDomainEvent
    {
        public string DomainEventName => DomainEventsNames.AssignmentEventNames.AssignmentCreated;
    }
}
