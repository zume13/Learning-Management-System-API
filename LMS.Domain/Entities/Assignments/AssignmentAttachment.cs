using LMS.Domain.Entities.Lessons;
using LMS.SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Assignments
{
    public class AssignmentAttachment : Entity
    {
        private AssignmentAttachment(Guid id, Guid assignmentId, string bucketKey, string fileName, string contentType, long sizeBytes) : base(id)
        {
            AssignmentId = assignmentId;
            BucketKey = bucketKey;
            FileName = fileName;
            ContentType = contentType;
            SizeBytes = sizeBytes;
        }
        public Guid AssignmentId { get; private set; }
        public Assignment Assignment { get; private set; } = null!;
        public string BucketKey { get; private set; }   // e.g. "assignments/{assignmentId}/instructions.pdf"
        public string FileName { get; private set; } 
        public string ContentType { get; private set; }
        public long SizeBytes { get; private set; }
        public FileStatus Status { get; private set; } = FileStatus.Uploading;
        public DateTime UploadedAt { get; private set; }

        public ResultT<AssignmentAttachment> Create(Guid assigmentId, string bucketKey, string fileName, string contentType, long sizeBytes )
        {
            if (string.IsNullOrWhiteSpace(bucketKey))
                return AssignmentErrors.General.Empty(nameof(bucketKey));
            if (string.IsNullOrWhiteSpace(fileName))
                return AssignmentErrors.General.Empty(nameof(fileName));
            if (string.IsNullOrWhiteSpace(contentType))
                return AssignmentErrors.General.Empty(nameof(contentType));
            if (sizeBytes <= 0)
                return AssignmentErrors.Attachment.FileSizeInvalid;
            if (sizeBytes > 10 * 1024 * 1024) // 10 MB limit
                return AssignmentErrors.Attachment.FileSizeExceeded;
            UploadedAt = DateTime.UtcNow;
            Status = FileStatus.Uploading;
            return new AssignmentAttachment(Guid.NewGuid(), assigmentId, bucketKey, fileName, contentType, sizeBytes);
        }
    }
}
