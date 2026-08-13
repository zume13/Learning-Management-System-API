using LMS.Application.Abstractions.Repositories.Records;
using LMS.Domain.Entities.Enrollments;
using LMS.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Persistence.Repositories
{
    internal class EnrollmentRepository : Repository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<Enrollment>> GetBySectionIdAsync(
            Guid sectionId,
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.Enrollments
                .Where(e => e.SectionId == sectionId)
                .ToListAsync(cancellationToken);
        }
    }
}
 