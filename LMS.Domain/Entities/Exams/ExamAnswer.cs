using LMS.SharedKernel.Primitives;

namespace LMS.Domain.Entities.Exams
{
    public class ExamAnswer : Entity
    {
        private ExamAnswer(Guid id) : base(id) 
        { 
        }
        public Guid AttemptId { get; private set; }
        public Guid QuestionId { get; private set; }
        public string? AnswerValue { get; private set; }
        public bool? IsCorrect { get; private set; }
        public double? PointsAwarded { get; private set; }
    }
}
