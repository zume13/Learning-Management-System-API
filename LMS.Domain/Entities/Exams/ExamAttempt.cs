using LMS.SharedKernel.Primitives;

namespace LMS.Domain.Entities.Exams
{
    public class ExamAttempt : Entity
    {
        private ExamAttempt(Guid id) : base(id)
        {

        }

        public Guid ExamId { get; private set; }
        public int UserId { get; private set; }
        public DateTime StartedAt { get; private set; }
        public DateTime? SubmittedAt { get; private set; }
        public double? Score { get; private set; }
        public ExamAttemptStatus Status { get; set; } = ExamAttemptStatus.InProgress;

        public ICollection<ExamAnswer> Answers { get; set; } = new List<ExamAnswer>();
    }
}
