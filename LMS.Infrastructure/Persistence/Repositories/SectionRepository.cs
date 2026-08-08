using LMS.Application.Abstractions.Repositories.Records;
using LMS.Domain.Entities.Sections;

namespace LMS.Infrastructure.Persistence.Repositories
{
    public class SectionRepository : ISectionRepository
    {
        public Task AddAsync(Section aggregate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Section> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void RemoveAsync(Section aggregate)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(Section aggregate)
        {
            throw new NotImplementedException();
        }
    }
}
