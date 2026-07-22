using SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Assignments
{
    public class Assignment : AggregateRoot
    {
        private Assignment(Guid id, Guid courseId, string title, string? description, DateTime dueDate, bool allowLate, Guid createdById) : base(id)
        {
            CourseId = courseId;
            Title = title;
            DueDate = dueDate;
            CreatedById = createdById;
            Description = description;
            AllowLate = allowLate;
        }
        public Guid CourseId { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public DateTime DueDate { get; private set; }
        public bool AllowLate { get; private set; }
        public Guid CreatedById { get; private set; }

        private readonly List<AssignmentAttachment> _Attachments = new();
        public IReadOnlyCollection<AssignmentAttachment> Attachments => _Attachments;

        private readonly List<Submission> _Submissions = new();
        public IReadOnlyCollection<Submission> Submissions => _Submissions;

        public ResultT<Assignment> Create(Guid courseId, string title, string? description, DateTime dueDate, Guid createdById, bool allowLate = false)
        {
            if (string.IsNullOrWhiteSpace(title))
                return AssignmentErrors.General.Empty(nameof(title));

            if(string.IsNullOrWhiteSpace(description))
                return AssignmentErrors.General.Empty(nameof(description));

            if(dueDate < DateTime.UtcNow)
                return AssignmentErrors.Assignment.InvalidDueDate;

            return new Assignment(Guid.NewGuid(), courseId, title, description, dueDate, allowLate, createdById);
        }
    }
    
}
