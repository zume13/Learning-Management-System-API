using SharedKernel.Primitives;

namespace LMS.Domain.Entities.Lessons
{
    public class Lesson : AggregateRoot
    {
        private Lesson(Guid id, Guid courseId, string title, string description, DateTime? releaseDate, LessonType type) : base(id)
        {
            CourseId = courseId;
            Title = title;
            Description = description;
            ReleaseDate = releaseDate;
            Type = type;
        }
        public Guid CourseId { get; private set; }
        public string Title { get; private set; } 
        public string Description { get; private set; }
        public DateTime? ReleaseDate { get; private set; }
        public LessonType Type { get; private set; }

        private readonly List<Guid> _FileIds = new();
        public IReadOnlyCollection<Guid> Files => _FileIds;

        private readonly List<Guid> _VideoIds = new();
        public IReadOnlyCollection<Guid> Videos => _VideoIds;
    }
}
