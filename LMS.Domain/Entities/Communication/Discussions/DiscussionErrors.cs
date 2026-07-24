
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Communication.LessonDiscussions
{
    public static class DiscussionErrors
    {
        public static class Thread 
        {
            public static Error Locked => Error.Failure("Thread.Locked", "This thread is already locked");
        }

    }
}
