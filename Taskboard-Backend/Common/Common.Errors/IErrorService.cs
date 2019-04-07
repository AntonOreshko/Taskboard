namespace Common.Errors
{
    public interface IErrorService
    {
        Error GetError(ErrorType errorType);

        Error GetError(short id);
    }
}
