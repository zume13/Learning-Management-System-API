using LMS.SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Assignments
{
    public class Submission : Entity
    {
        private Submission(Guid id, Guid assignmentId, Guid studentId, DateTime submittedAt, string? feedback, int? grade) : base(id)
        {
            AssignmentId = assignmentId;
            StudentId = studentId;
            SubmittedAt = submittedAt;
            Feedback = feedback;
            Grade = grade;
            Status = SubmissionStatus.NotSubmitted;
        }
        public Guid AssignmentId { get; private set; }
        public Guid StudentId { get; private set; }
        public DateTime SubmittedAt { get; private set; }
        public string? Feedback { get; private set; }
        public int? Grade { get; private set; }
        public SubmissionStatus Status { get; private set; }

        private readonly List<SubmissionAttachment> _Attachments = new();
        public IReadOnlyCollection<SubmissionAttachment> Attachments => _Attachments;

        public static ResultT<Submission> Create(Guid assignmentId, Guid studentId, string? feedback, int? grade)
        {
            if (grade.HasValue && (grade < 0))
                return AssignmentErrors.Submission.InvalidGrade;
            return new Submission(Guid.NewGuid(), assignmentId, studentId, DateTime.UtcNow, feedback, grade);
        }
    }
}
