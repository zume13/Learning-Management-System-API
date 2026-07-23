using LMS.Domain.Entities.Communication.GradeConsultations;
using LMS.SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Grades;

public class GradeConsultation : Entity
{
    private GradeConsultation(
        Guid id,
        Guid gradeId,
        Guid studentId,
        string message) : base(id)
    {
        GradeId = gradeId;
        StudentId = studentId;
        Message = message;
        Status = GradeConsultationStatus.Pending;
    }

    public Guid GradeId { get; private set; }

    public Guid StudentId { get; private set; }

    public string Message { get; private set; }

    public GradeConsultationStatus Status { get; private set; }

    public string? Response { get; private set; }

    public static ResultT<GradeConsultation> Create(
        Guid gradeId,
        Guid studentId,
        string message)
    {
        if (string.IsNullOrWhiteSpace(message))
            return GradeConsultationErrors.General.Empty(nameof(message));

        return new GradeConsultation(
            Guid.NewGuid(),
            gradeId,
            studentId,
            message);
    }

    public void Respond(string response)
    {
        Response = response;
        Status = GradeConsultationStatus.Responded;
    }
}