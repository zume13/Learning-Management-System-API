using LMS.Application.Abstractions.Repositories.Communication;
using LMS.Domain.Entities.Communication.GradeConsultations;
using LMS.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Persistence.Repositories.Communication
{
    public class GradeConsultationRepository : Repository<GradeConsultation>, IGradeConsultationRepository
    {
        public GradeConsultationRepository(ApplicationDbContext context): base(context) { }
  
        // Grade consultation request (list of active/past consultations)
        public async Task<List<GradeConsultation>> GetByStudentIdAsync(Guid studentId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.GradeConsultations
                .Where(k => k.StudentId == studentId)
                .ToListAsync(cancellationToken);
        }

        // Teacher-side grade consultation request (list of pending)
        public async Task<List<GradeConsultation>> GetPendingAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.GradeConsultations
                .Where(a => a.Status == GradeConsultationStatus.Pending)
                .ToListAsync(cancellationToken);
        }
    }
}