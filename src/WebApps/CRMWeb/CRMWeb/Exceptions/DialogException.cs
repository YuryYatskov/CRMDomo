namespace CRMWeb.Exceptions;

public class DialogException : Exception
{
    public bool IsDialog { get; set; } = false;

    public DialogException(
        string? message,
        Exception? innerException,
        bool isDialog) : base(message, innerException) => IsDialog = isDialog;
}
