namespace WebAPI.Constants;

public static class ErrorConstants
{
    public static class Quiz
    {
        public const string NameAlreadyExists = "A quiz with this name already exists.";
        public const string AtLeastOneQuestionRequired = "The quiz must contain at least one question.";
    }

    public static class Question
    {
        public const string QuestionAlreadyExists = "A question with this text already exists.";
        public const string QuestionDoesNotExist = "Selected question does not exist in the database.";
    }

    public static class Export
    {
        public const string ExportFormatRequired = "Export format is required.";
        public const string UnsupportedExportFormat = "The provided export format is not supported.";
    }
}
