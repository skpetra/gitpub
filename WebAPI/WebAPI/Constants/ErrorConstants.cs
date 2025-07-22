namespace WebAPI.Constants;

public static class ErrorConstants
{
    public static class Quiz
    {
        public const string NameAlreadyExists = "A quiz with this name already exists.";
        public const string SelectedQuestionsDoNotExist = "Some of the selected existing questions do not exist in the database.";
    }

    public static class Export
    {
        public const string ExportFormatRequired = "Export format is required.";
        public const string UnsupportedExportFormat = "The provided export format is not supported.";
    }
}
