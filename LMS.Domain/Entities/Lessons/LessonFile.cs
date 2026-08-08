using LMS.SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Lessons
{
    public class LessonFile : Entity
    {
        private LessonFile(Guid id, Guid lessonId, string bucketKey, string fileName, string contentType, long sizeBytes, DateTime uploadedAt) : base(id)
        {
            LessonId = lessonId;
            BucketKey = bucketKey;
            FileName = fileName;
            ContentType = contentType;
            SizeBytes = sizeBytes;
            UploadedAt = uploadedAt;
        }

        public Guid LessonId { get; private set; }
        public string BucketKey { get; private set; } // e.g. "courses/12/lessons/45/slides.pdf"
        public string FileName { get; private set; } // original filename, for display/download
        public string ContentType { get; private set; } // MIME type
        public long SizeBytes { get; private set; }
        public FileStatus Status { get; private set; } = FileStatus.Uploading;
        public DateTime UploadedAt { get; private set; }

        public ResultT<LessonFile> Create(Guid lessonId, string bucketKey, string fileName, string contentType, long sizeBytes, DateTime uploadedAt)
        {
            if(lessonId == Guid.Empty)
                return GeneralErrors.General.Empty(nameof(lessonId));
           
            if(string.IsNullOrWhiteSpace(bucketKey))
                return GeneralErrors.General.Empty(nameof(bucketKey));  

            if(string.IsNullOrWhiteSpace(fileName))
                return GeneralErrors.General.Empty(nameof(fileName));

            if(string.IsNullOrWhiteSpace(contentType))
                return LessonErrors.LessonFile.EmptyContentType;

            if(sizeBytes < 0)
                return LessonErrors.LessonFile.InvalidSize;

            return new LessonFile(Guid.NewGuid(), lessonId, bucketKey, fileName, contentType, sizeBytes, uploadedAt);
        }
    }
}
