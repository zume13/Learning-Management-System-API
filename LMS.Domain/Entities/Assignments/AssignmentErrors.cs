using SharedKernel.Shared;

namespace LMS.Domain.Entities.Assignments
{
    public static class AssignmentErrors
    {
        public static class General
        {
            public static Error Empty(string propertyName) => Error.Failure($"{propertyName}.Empty", $"{propertyName} cannot be empty.");
        }   
        public static class Assignment 
        {
            public static Error InvalidDueDate => Error.Failure("Assignment.InvalidDueDate", "Assignment due date cannot be in the past.");
        }
        public static class Attachment
        {
            public static Error InvalidFileType => Error.Failure("Attachment.InvalidFileType", "Attachment file type is not supported.");
            public static Error FileSizeExceeded => Error.Failure("Attachment.FileSizeExceeded", "Attachment file size exceeds the allowed limit.");
            public static Error FileSizeInvalid => Error.Failure("Attachment.FileSizeInvalid", "Attachment file size is invalid.");
        }
        public static class Submission
        {
            public static Error AlreadySubmitted => Error.Failure("Submission.AlreadySubmitted", "The assignment has already been submitted.");
            public static Error NotSubmitted => Error.Failure("Submission.NotSubmitted", "The assignment has not been submitted yet.");
            public static Error SubmissionDeadlinePassed => Error.Failure("Submission.DeadlinePassed", "The submission deadline for this assignment has passed.");
            public static Error InvalidGrade => Error.Failure("Grade.Invalid", "The passed grade was invalid");
        }
    }
}
