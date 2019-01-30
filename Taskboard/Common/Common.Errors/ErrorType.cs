namespace Common.Errors
{
    public enum ErrorType: short
    {
        InternalServerError = 1,
        UserAlreadyExists = 15,
        AccessDenied = 33,
        RequestTimeout = 52,
        ItemNotFound = 57,
        InvalidUsername = 65,
        WrongPassword = 66
    }
}