using LMS.Domain.Entities.Lessons;
using LMS.SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Assignments
{
    public class SubmissionAttachment : Entity
    {
        private SubmissionAttachment(Guid id, Guid assignmentId, string bucketKey, string fileName, string contentType, long sizeBytes) : base(id)
        {
            AssignmentId = assignmentId;
            BucketKey = bucketKey;
            FileName = fileName;
            ContentType = contentType;
            SizeBytes = sizeBytes;
            UploadedAt = DateTime.UtcNow;
        }

        public Guid AssignmentId { get; private set; }
        public string BucketKey { get; private set; }    // e.g. "courses/12/assignments/7/instructions.pdf"
        public string FileName { get; private set; } 
        public string ContentType { get; private set; } 
        public long SizeBytes { get; private set; }
        public FileStatus Status { get; private set; } = FileStatus.Uploading;
        public DateTime UploadedAt { get; private set; }

        public ResultT<SubmissionAttachment> Create(Guid assignmentId, string bucketKey, string fileName, string contentType, long sizeBytes)
        {
            if (string.IsNullOrWhiteSpace(bucketKey))
                return GeneralErrors.General.Empty(nameof(bucketKey));
            if (string.IsNullOrWhiteSpace(fileName))
                return GeneralErrors.General.Empty(nameof(fileName));
            if (string.IsNullOrWhiteSpace(contentType))
                return GeneralErrors.General.Empty(nameof(contentType));
            if (sizeBytes <= 0)
                return AssignmentErrors.Attachment.FileSizeInvalid;
            if (sizeBytes > 10 * 1024 * 1024) // 10 MB lim
                return AssignmentErrors.Attachment.FileSizeExceeded;
          
            return new SubmissionAttachment(Guid.NewGuid(), assignmentId, bucketKey, fileName, contentType, sizeBytes);
        }
    }
}
