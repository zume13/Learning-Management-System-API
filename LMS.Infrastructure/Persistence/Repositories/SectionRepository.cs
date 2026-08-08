using LMS.Application.Abstractions.Repositories.Records;
using LMS.Domain.Entities.Sections;
using LMS.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Persistence.Repositories
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        public SectionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Section?> GetByNameAsync(string name)
        {
            return await _dbContext.Sections.FirstOrDefaultAsync(s => s.Name == name);
        }
    }
}
