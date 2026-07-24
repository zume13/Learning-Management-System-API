using LMS.SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Lessons
{
    public class VideoLesson : Entity
    {
        private VideoLesson(Guid id, Guid lessonId, string bucketKey, int durationSeconds) : base(id)
        {
            LessonId = lessonId;
            BucketKey = bucketKey;
            DurationSeconds = durationSeconds;
        }
        public Guid LessonId { get; private set; }
        public string BucketKey { get; private set; } // raw video object in R2
        public string? ThumbnailKey { get; private set; }   // generated thumbnail, if you build that
        public int DurationSeconds { get; private set; } // extracted during processing, not known at upload
        public FileStatus Status { get; private set; } = FileStatus.Uploading;

        private readonly List<Guid> _VideoProgressIds = new();
        public IReadOnlyCollection<Guid> VideoProgress => _VideoProgressIds;

        public ResultT<VideoLesson> Create(Guid lessonId, string bucketKey, int durationSeconds)
        {
            if (lessonId == Guid.Empty)
                return GeneralErrors.General.Empty(nameof(lessonId));

            if (string.IsNullOrWhiteSpace(bucketKey))
                return GeneralErrors.General.Empty(nameof(bucketKey));

            if (durationSeconds <= 0)
                return LessonErrors.VideoLesson.InvalidDuration;

            return new VideoLesson(Guid.NewGuid(), lessonId, bucketKey, durationSeconds);
        }   
    }
}
