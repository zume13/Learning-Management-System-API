using SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Enrollments
{
    public class Enrollment : AggregateRoot
    {
        private Enrollment(Guid id, Guid studentId, Guid courseId, Guid sectionId) : base(id)
        {
            StudentId = studentId;
            CourseId = courseId;
            SectionId = sectionId;
            Status = EnrollmentStatus.Active;
            EnrolledAt = DateTime.UtcNow;
        }

        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public Guid SectionId { get; set; }
        public EnrollmentStatus Status { get; set; }
        public DateTime EnrolledAt { get; set; }

        public ResultT<Enrollment> Create(Guid studentId, Guid courseId, Guid sectionId)
        {
            if (studentId == Guid.Empty)
                return EnrollmentErrors.Enrollment.InvalidStudent;
            if (courseId == Guid.Empty)
                return EnrollmentErrors.Enrollment.InvalidCourse;
            if (sectionId == Guid.Empty)
                return EnrollmentErrors.Enrollment.InvalidSection;

            return new Enrollment(Guid.NewGuid(), studentId, courseId, sectionId); ;
        }
    }
}
