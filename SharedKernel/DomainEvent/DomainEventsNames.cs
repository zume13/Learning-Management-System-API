
namespace SharedKernel.DomainEvent
{
    public static class DomainEventsNames
    {
        public static class UserEventNames 
        { 
            public const string UserCreated = "UserCreated"; 
        }

        public static class CommunicationEventNames
        {
            public const string AnnouncementCreated = "AnnouncementCreated";
            public const string GradeConsultationStarted = "GradeConsultationStarted";
        }

        public static class CourseEventNames
        {
            public const string LessonUploaded = "LessonUploaded";
            public const string VideoUploaded = "VideoUploaded";
        }
    }
}
