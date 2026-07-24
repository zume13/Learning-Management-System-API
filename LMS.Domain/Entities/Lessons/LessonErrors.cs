
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Lessons
{
    public static class LessonErrors
    {
        public static class Lesson 
        {
            public static Error FileAlreadyAttached => Error.Failure("File.AlreadyAttached", "This file is already attached");
            public static Error FileNotFound => Error.Failure("File.NotFound", "This file was not found");
            public static Error VideoAlreadyAttached => Error.Failure("Video.AlreadyAttached", "This video is already attached");
            public static Error VideoNotFound => Error.Failure("Video.NotFound", "This video was not found");
        }
        public static class LessonFile 
        {
            public static Error EmptyContentType = Error.Failure("LessonFile.EmptyContentType", "Content type cannot be empty.");
            public static Error InvalidSize = Error.Failure("LessonFile.InvalidSize", "File size cannot be negative.");
        }
        public static class VideoLesson 
        {
            public static Error InvalidDuration = Error.Failure("VideoLesson.InvalidDuration", "Duration must be a positive number.");
        }
    }
}
