
using SharedKernel.DomainEvent;

namespace LMS.Domain.Entities.Courses.Events
{
    public record CourseArchivedEvent : IDomainEvent
    {
        public string DomainEventName => DomainEventsNames.CourseEventNames.CourseArchived;
    }
}
