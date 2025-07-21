namespace WebAPI.Core.Validation;

public static class ValidationMessages
{
    public static string MaxLength(string fieldName, int length) => $"{fieldName} must not exceed {length} characters.";

    public static string Required(string fieldName) => $"{fieldName} is required.";
}
