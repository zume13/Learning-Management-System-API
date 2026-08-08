using LMS.Application.Abstractions.Repositories.Records;
using LMS.Domain.Entities.Sections;
using LMS.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Persistence.Repositories
{
    public class SectionRepository : ISectionRepository
    {
        private readonly ApplicationDbContext _context;

        public SectionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task AddAsync(Section aggregate, CancellationToken cancellationToken = default)
        {
            await _context.Sections.AddAsync(aggregate, cancellationToken);
        }

        public async Task<Section?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var section = await _context.Sections.FindAsync(id, cancellationToken);

            if (section == null)
                throw new InvalidOperationException("Section not found");

            return section;
        }

        public async Task<Section?> GetByNameAsync(string name)
        {
            return await _context.Sections.FirstOrDefaultAsync(s => s.Name == name);
        }

        public void RemoveAsync(Section aggregate)
        {
            _context.Sections.Remove(aggregate);
        }

        public void UpdateAsync(Section aggregate)
        {
            _context.Sections.Update(aggregate);
        }
    }
}
