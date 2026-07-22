
using LMS.SharedKernel.Primitives;

namespace LMS.Domain.Entities.Exams
{
    public class ExamQuestion : Entity
    {
        private ExamQuestion(Guid id) : base(id)
        {

        }

        public Guid ExamId { get; private set; }
        public QuestionType Type { get; private set; }
        public string Text { get; private set; }
        public string? OptionsJson { get; private set; } // serialized options for MC/matching
        public string? CorrectAnswer { get; private set; }
        public double Points { get; private set; }

        public ICollection<ExamAnswer> Answers { get; set; } = new List<ExamAnswer>();
    }
}
