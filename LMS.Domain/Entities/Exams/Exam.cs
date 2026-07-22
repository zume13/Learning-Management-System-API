
using SharedKernel.Primitives;

namespace LMS.Domain.Entities.Exams
{
    public class Exam : AggregateRoot
    {
        private Exam(Guid id) : base(id) 
        { 

        }
        public Guid CourseId { get; private set; }
        public string Title { get; private set; } 
        public int? TimeLimitMinutes { get; private set; }
        public bool RandomizeQuestions { get; private set; }
        public bool AutoGrade { get; private set; }
        public bool Published { get; private set; }

        public ICollection<ExamQuestion> Questions { get; set; } = new List<ExamQuestion>();
        public ICollection<ExamAttempt> Attempts { get; set; } = new List<ExamAttempt>();
    }
}
