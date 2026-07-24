
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Exams
{
    public static class ExamErrors
    {
        public static class Exam
        {
            public static Error InvalidTimeLimit => Error.Failure($"Limit.Invalid", $"The time limit cannot be less than zero");
        }

        public static class Question
        {
            public static Error InvalidPoints => Error.Failure("Points.Invalid", "Points cannot be less than or equal zero");
        }

        public static class Attempt
        {
            public static Error AlreadySubmitted => Error.Failure("Attempt.AlreadySubmitted", "This exam attempt was already submitted");
        }
    }
}
