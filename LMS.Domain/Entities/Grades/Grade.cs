using LMS.Domain.Entities.Communication.GradeConsultations;
using SharedKernel.Primitives;
using SharedKernel.Shared;
using System.Net.NetworkInformation;

namespace LMS.Domain.Entities.Grades;

public class Grade : AggregateRoot
{
    private Grade(
        Guid id,
        Guid userId,
        Guid courseId,
        GradeSourceType sourceType,
        Guid sourceId,
        double score) : base(id)
    {
        UserId = userId;
        CourseId = courseId;
        SourceType = sourceType;
        SourceId = sourceId;
        Score = score;
    }

    public Guid UserId { get; private set; }

    public Guid CourseId { get; private set; }

    public GradeSourceType SourceType { get; private set; }

    public Guid SourceId { get; private set; }

    public double Score { get; private set; }

    public bool Released { get; private set; }

    public bool Locked { get; private set; }

    private readonly List<GradeConsultation> _consultations = new();
    public IReadOnlyCollection<GradeConsultation> Consultations => _consultations;

    public static ResultT<Grade> Create(
        Guid userId,
        Guid courseId,
        GradeSourceType sourceType,
        Guid sourceId,
        double score)
    {
        if (score < 0)
            return GradeErrors.Grade.InvalidScore;

        return new Grade(
            Guid.NewGuid(),
            userId,
            courseId,
            sourceType,
            sourceId,
            score);
    }

    public Result Release()
    {
        if (Locked)
            return GradeErrors.Grade.Locked;

        return Result.Success();
    }

    public void Lock() => Locked = true;

    public bool IsReleased()
        => Released == true;
}