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
        string message)
        : base(id)
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
            return GeneralErrors.General.Empty(nameof(message));

        return new GradeConsultation(
            Guid.NewGuid(),
            gradeId,
            studentId,
            message);
    }

    public Result Respond(string response)
    {
        if (Status != GradeConsultationStatus.Pending)
            return GradeConsultationErrors.AlreadyResponded;

        if (string.IsNullOrWhiteSpace(response))
            return GeneralErrors.General.Empty(nameof(response));

        Response = response;
        Status = GradeConsultationStatus.Responded;

        return Result.Success();
    }

    public Result UpdateMessage(string message)
    {
        if (Status != GradeConsultationStatus.Pending)
            return GradeConsultationErrors.CannotModify;

        if (string.IsNullOrWhiteSpace(message))
            return GeneralErrors.General.Empty(nameof(message));

        Message = message;

        return Result.Success();
    }

    public Result Close()
    {
        if (Status == GradeConsultationStatus.Closed)
            return GradeConsultationErrors.AlreadyClosed;

        Status = GradeConsultationStatus.Closed;

        return Result.Success();
    }
}