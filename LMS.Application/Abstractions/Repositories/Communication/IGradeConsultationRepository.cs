using LMS.Application.Abstractions.Repositories.Base;
using LMS.Domain.Entities.Grades;
using LMS.Domain.Entities.Notifications;

namespace LMS.Application.Abstractions.Repositories.Communication
{
    public interface IGradeConsultationRepository : IRepository<GradeConsultation>
    {
    }
}
