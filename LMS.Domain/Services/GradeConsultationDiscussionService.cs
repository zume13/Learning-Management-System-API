using LMS.Domain.Entities.Grades;
using SharedKernel.Shared;

namespace LMS.Domain.Services;

public sealed class GradeConsultationService
{
    public ResultT<GradeConsultation> CreateConsultation(
        Grade grade,
        Guid studentId,
        string message)
    {
        if (!grade.IsReleased())
            return GradeErrors.NotReleased;

        return GradeConsultation.Create(
            grade.Id,
            studentId,
            message);
    }

    public Result Respond(
        GradeConsultation consultation,
        string response)
    {
        return consultation.Respond(response);
    }

    public Result Close(
        GradeConsultation consultation)
    {
        return consultation.Close();
    }
}