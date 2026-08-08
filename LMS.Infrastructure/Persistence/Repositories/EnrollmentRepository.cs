using LMS.Application.Abstractions.Repositories.Records;
using LMS.Domain.Entities.Enrollments;
using LMS.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Infrastructure.Persistence.Repositories
{
    internal class EnrollmentRepository : IEnrollmentRepository
    {
        public Task AddAsync(Enrollment aggregate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Enrollment> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task GetBySectionIdAsync(Guid sectionId)
        {
            throw new NotImplementedException();
        }

        public void RemoveAsync(Enrollment aggregate)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(Enrollment aggregate)
        {
            throw new NotImplementedException();
        }
    }
}
