
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Exams
{
    public static class ExamErrors
    {
        public static class General 
        {
            public static Error Empty(string emptyProperty) => Error.Failure($"{emptyProperty}.Empty", $"The property {emptyProperty} is empty");
        }

        public static class Exam
        {
            public static Error InvalidTimeLimit => Error.Failure($"Limit.Invalid", $"The time limit cannot be less than zero");
        }
    }
}
