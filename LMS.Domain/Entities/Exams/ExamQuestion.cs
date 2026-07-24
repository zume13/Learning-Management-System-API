using LMS.SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Exams;

public class ExamQuestion : Entity
{
    private ExamQuestion(
        Guid id,
        Guid examId,
        QuestionType type,
        string text,
        string? optionsJson,
        string? correctAnswer,
        double points) : base(id)
    {
        ExamId = examId;
        Type = type;
        Text = text;
        OptionsJson = optionsJson;
        CorrectAnswer = correctAnswer;
        Points = points;
    }

    public Guid ExamId { get; private set; }
    public QuestionType Type { get; private set; }
    public string Text { get; private set; }
    public string? OptionsJson { get; private set; }
    public string? CorrectAnswer { get; private set; }
    public double Points { get; private set; }

    private readonly List<ExamAnswer> _answers = new();
    public IReadOnlyCollection<ExamAnswer> Answers => _answers;

    public static ResultT<ExamQuestion> Create(
        Guid examId,
        QuestionType type,
        string text,
        double points,
        string? optionsJson = null,
        string? correctAnswer = null)
    {
        if (string.IsNullOrWhiteSpace(text))
            return GeneralErrors.General.Empty(nameof(text));

        if (points <= 0)
            return ExamErrors.Question.InvalidPoints;

        return new ExamQuestion(
            Guid.NewGuid(),
            examId,
            type,
            text,
            optionsJson,
            correctAnswer,
            points);
    }
}