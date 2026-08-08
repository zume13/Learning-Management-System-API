using LMS.Application.Abstractions.Repositories.Records;
using LMS.Domain.Entities.Enrollments;
using LMS.Infrastructure.Persistence.Database;

namespace LMS.Infrastructure.Persistence.Repositories
{
    internal class EnrollmentRepository : Repository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
 