namespace Application.Common;

public class ValidationResult
{
    public bool IsSuccess { get; set; }
    public string Type { get; set; }
    public string Message { get; set; }

    public ValidationResult(bool isSuccess, string type, string message)
    {
        IsSuccess = isSuccess;
        Type = type;
        Message = message;
    }
}