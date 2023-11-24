namespace Application.Common;

public class CommandResult
{
    public bool IsSuccess { get; set; }
    public string Key { get; private set; }
    public string Message { get; set; }

    public CommandResult(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Key = isSuccess ? "successMessage" : "errorMessage";
        Message = message;
    }
}