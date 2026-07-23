using LMS.SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Exams;

public class ExamAttempt : Entity
{
    private ExamAttempt(
        Guid id,
        Guid examId,
        Guid userId,
        DateTime startedAt) : base(id)
    {
        ExamId = examId;
        UserId = userId;
        StartedAt = startedAt;
        Status = ExamAttemptStatus.InProgress;
    }

    public Guid ExamId { get; private set; }
    public Guid UserId { get; private set; }

    public DateTime StartedAt { get; private set; }
    public DateTime? SubmittedAt { get; private set; }

    public double? Score { get; private set; }

    public ExamAttemptStatus Status { get; private set; }

    private readonly List<ExamAnswer> _answers = new();
    public IReadOnlyCollection<ExamAnswer> Answers => _answers;

    public static ResultT<ExamAttempt> Create(Guid examId, Guid userId)
    {
        return new ExamAttempt(
            Guid.NewGuid(),
            examId,
            userId,
            DateTime.UtcNow);
    }

    public Result Submit(double score)
    {
        if (Status == ExamAttemptStatus.Submitted)
            return ExamErrors.Attempt.AlreadySubmitted;

        Score = score;
        SubmittedAt = DateTime.UtcNow;
        Status = ExamAttemptStatus.Submitted;

        return Result.Success();
    }
}