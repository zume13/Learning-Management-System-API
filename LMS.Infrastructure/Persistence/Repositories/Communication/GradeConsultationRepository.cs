using LMS.Application.Abstractions.Repositories.Communication;
using LMS.Domain.Entities.Communication.GradeConsultations;
using LMS.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Infrastructure.Persistence.Repositories.Communication
{
    public class GradeConsultationRepository : IGradeConsultationRepository
    {
        private readonly ApplicationDbContext _context;

        public GradeConsultationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(GradeConsultation aggregate, CancellationToken cancellationToken = default)
        {
            await _context.GradeConsultations.AddAsync(aggregate, cancellationToken);
        }


        public async Task<GradeConsultation?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var consultation = await _context.GradeConsultations.FindAsync(id, cancellationToken);

            if (consultation == null)
                throw new InvalidOperationException("Grade consultation no bueno.");

            return consultation;
        }

        public void RemoveAsync(GradeConsultation aggregate)
        {
            _context.GradeConsultations.Remove(aggregate);
        }

        public void UpdateAsync(GradeConsultation aggregate)
        {
            _context.GradeConsultations.Update(aggregate);
        }

        // Grade consultation request (list of active/past consultations)
        public async Task<List<GradeConsultation>> GetByStudentIdAsync(Guid studentId, CancellationToken cancellationToken = default)
        {
            return await _context.GradeConsultations
                .Where(g => g.StudentId == studentId)
                .ToListAsync(cancellationToken);
        }

        // Teacher-side grade consultation request (list of pending)
        public async Task<List<GradeConsultation>> GetPendingAsync(CancellationToken cancellationToken = default)
        {
            return await _context.GradeConsultations
                .Where(g => g.Status == GradeConsultationStatus.Pending)
                .ToListAsync(cancellationToken);
        }
    }
}