using SharedKernel.Shared;

public static class GradeConsultationErrors
{
    public static readonly Error AlreadyResponded =
        Error.Conflict(
            "GradeConsultation.AlreadyResponded",
            "The consultation has already been responded to.");

    public static readonly Error CannotModify =
        Error.Conflict(
            "GradeConsultation.CannotModify",
            "Only pending consultations can be modified.");

    public static readonly Error NotResponded =
        Error.Conflict(
            "GradeConsultation.NotResponded",
            "The consultation has not been responded to.");

    public static readonly Error AlreadyClosed =
        Error.Conflict(
            "GradeConsultation.AlreadyClosed",
            "The consultation is already closed.");
}