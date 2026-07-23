using SharedKernel.Shared;


namespace LMS.Domain.Entities.Communication.GradeConsultations
{
    public static class GradeConsultationErrors
    {
        public static class General 
        {
            public static Error Empty(string emptyProperty) => Error.Failure($"{emptyProperty}.Empty", $"The {emptyProperty} is empty");
        }

    }
}
