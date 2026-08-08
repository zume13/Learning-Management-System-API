using LMS.Application.Abstractions.Repositories.Base;
using LMS.Domain.Entities.Communication.GradeConsultations;
using LMS.Domain.Entities.Notifications;

namespace LMS.Application.Abstractions.Repositories.Communication
{
    public interface IGradeConsultationRepository : IRepository<GradeConsultation>
    {
        Task<List<GradeConsultation>> GetByStudentIdAsync(Guid studentId, CancellationToken cancellationToken = default);
        Task<List<GradeConsultation>> GetPendingAsync(CancellationToken cancellationToken = default);
    }
}
