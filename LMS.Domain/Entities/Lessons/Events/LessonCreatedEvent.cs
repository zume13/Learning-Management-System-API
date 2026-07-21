using SharedKernel.DomainEvent;

namespace LMS.Domain.Entities.Lessons.Events
{
    public class LessonCreatedEvent : IDomainEvent
    {
        public string DomainEventName => "LessonCreated";
    }
}
