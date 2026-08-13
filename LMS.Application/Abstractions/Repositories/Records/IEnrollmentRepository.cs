using LMS.Application.Abstractions.Repositories.Base;
using LMS.Domain.Entities.Enrollments;

namespace LMS.Application.Abstractions.Repositories.Records
{
    public interface IEnrollmentRepository : IRepository<Enrollment>
    {
        Task<IReadOnlyList<Enrollment>> GetBySectionIdAsync(
            Guid sectionId,
            CancellationToken cancellationToken = default);
    }
}
