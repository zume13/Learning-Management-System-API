
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Communication.LessonDiscussions
{
    public static class DiscussionErrors
    {
        public static class Thread 
        {
            public static Error Locked => Error.Failure("Thread.Locked", "This thread is already locked");
            public static Error ReplyNotFound => Error.Failure("Reply.NotFound", "Reply was not found");
        }

    }
}
