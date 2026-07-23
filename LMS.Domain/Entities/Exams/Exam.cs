using SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Exams
{
    public class Exam : AggregateRoot
    {
        private Exam(Guid id, Guid courseId, string title, int timeLimitInMinutes, bool randomizedQuestions, bool autoGrade, bool published) : base(id)
        {
            CourseId = courseId;
            Title = title;
            TimeLimitMinutes = timeLimitInMinutes;
            RandomizeQuestions = randomizedQuestions;
            AutoGrade = autoGrade;
            Published = published;
        }
        public Guid CourseId { get; private set; }
        public string Title { get; private set; }
        public int? TimeLimitMinutes { get; private set; }
        public bool RandomizeQuestions { get; private set; }
        public bool AutoGrade { get; private set; }
        public bool Published { get; private set; }

        private readonly List<ExamQuestion> _Questions = new();
        public IReadOnlyCollection<ExamQuestion> Questions => _Questions;
        private readonly List<ExamAttempt> _Attempts = new();
        public IReadOnlyCollection<ExamAttempt> Attempts => _Attempts;

        public ResultT<Exam> Create(Guid course, string title, int timeLimitInMinutes, bool randomizedQuestions = true, bool autoGrade = true, bool published = true)
        {
            if(string.IsNullOrEmpty(title))
                return ExamErrors.General.Empty(nameof(title));

            if (timeLimitInMinutes <= 0)
                return ExamErrors.Exam.InvalidTimeLimit;

            return new Exam(Guid.NewGuid(), course, title, timeLimitInMinutes, randomizedQuestions, autoGrade, published);
        }

    }
}
