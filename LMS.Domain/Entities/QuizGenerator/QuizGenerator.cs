using LMS.Domain.Entities.QuizGenerator;
using LMS.SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Assessments;

public class QuizGeneratorJob : Entity
{
    private QuizGeneratorJob(
        Guid id,
        Guid teacherId,
        string sourcePdfUrl) : base(id)
    {
        TeacherId = teacherId;
        SourcePdfUrl = sourcePdfUrl;
        Status = QuizGeneratorStatus.Pending;
    }

    public Guid TeacherId { get; }

    public string SourcePdfUrl { get; }

    public string? GeneratedQuestionsJson { get; private set; }

    public QuizGeneratorStatus Status { get; private set; }

    public static ResultT<QuizGeneratorJob> Create(
        Guid teacherId,
        string sourcePdfUrl)
    {
        if (string.IsNullOrWhiteSpace(sourcePdfUrl))
            return GeneralErrors.General.Empty(nameof(sourcePdfUrl));

        return new QuizGeneratorJob(
            Guid.NewGuid(),
            teacherId,
            sourcePdfUrl);
    }

    public void Complete(string generatedQuestionsJson)
    {
        GeneratedQuestionsJson = generatedQuestionsJson;
        Status = QuizGeneratorStatus.Completed;
    }

    public void Fail()
    {
        Status = QuizGeneratorStatus.Failed;
    }
}