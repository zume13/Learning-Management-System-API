using LMS.Application.Abstractions.Repositories.Base;
using LMS.Application.Abstractions.Repositories.Records;
using LMS.Domain.Entities.Courses;
using LMS.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Persistence.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) : base(context) {}   

        public async Task<Course?> GetByNameAsync(string name)
        {
            return await _dbContext.Courses.FirstOrDefaultAsync(c => c.CourseName == name);
        }
    }
}
