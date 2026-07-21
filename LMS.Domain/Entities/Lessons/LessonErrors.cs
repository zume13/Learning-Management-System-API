
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Lessons
{
    public static class LessonErrors
    {
        public static class Lesson 
        {
            
        }
        public static class LessonFile 
        {
            public static Error EmptyLessonId = Error.Failure("LessonFile.EmptyLessonId", "Lesson ID cannot be empty.");
            public static Error EmptyBucketKey = Error.Failure("LessonFile.EmptyBucketKey", "Bucket key cannot be empty.");
            public static Error EmptyFileName = Error.Failure("LessonFile.EmptyFileName", "File name cannot be empty.");
            public static Error EmptyContentType = Error.Failure("LessonFile.EmptyContentType", "Content type cannot be empty.");
            public static Error InvalidSize = Error.Failure("LessonFile.InvalidSize", "File size cannot be negative.");
        }
        public static class VideoLesson 
        {
            public static Error EmptyLessonId = Error.Failure("VideoLesson.EmptyLessonId", "Lesson ID cannot be empty.");
            public static Error EmptyBucketKey = Error.Failure("VideoLesson.EmptyBucketKey", "Bucket key cannot be empty.");
            public static Error InvalidDuration = Error.Failure("VideoLesson.InvalidDuration", "Duration must be a positive number.");
        }
    }
}
