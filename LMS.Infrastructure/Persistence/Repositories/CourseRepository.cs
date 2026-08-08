using LMS.Application.Abstractions.Repositories.Base;
using LMS.Application.Abstractions.Repositories.Records;
using LMS.Domain.Entities.Courses;
using LMS.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Persistence.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context; 

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }   

        public async Task AddAsync(Course aggregate, CancellationToken cancellationToken = default)
        {
            await _context.Courses.AddAsync(aggregate, cancellationToken);
        }

        public async Task<Course> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var course = await _context.Courses.FindAsync(id, cancellationToken);

            if (course == null)
                throw new InvalidOperationException("Course not found");

            return course;
        }

        public async Task<Course?> GetByNameAsync(string name)
        {
            return await _context.Courses.FirstOrDefaultAsync(c => c.CourseName == name);
        }

        public void RemoveAsync(Course aggregate)
        {
            _context.Courses.Remove(aggregate);
        }

        public void UpdateAsync(Course aggregate)
        {
            _context.Courses.Update(aggregate);
        }
    }
}
