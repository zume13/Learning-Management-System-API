
using SharedKernel.Primitives;

namespace LMS.Domain.Entities.Assignments
{
    public class Assignment : AggregateRoot
    {
        private Assignment(Guid id) : base(id)
        {
        public Guid CourseId { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public DateTime DueDate { get; private set; }
        public bool AllowLate { get; private set; }
        public Guid CreatedById { get; private set; }

        public ICollection<AssignmentAttachment> Attachments { get; set; } = new List<AssignmentAttachment>();
        public ICollection<Submission> Submissions { get; set; } = new List<Submission>();
    }
    }
}
