namespace Zad.Application.Exceptions;

public static class AppExceptionMapper
{
    public static Exception ToAppException(Exception ex)
    {
        return ex switch
        {
            UnauthorizedAccessException unauthorizedAccessException => new UnauthorizedException(unauthorizedAccessException.Message),
            InvalidOperationException invalidOperationException when IsNotFoundOperation(invalidOperationException) => new NotFoundException(invalidOperationException.Message),
            InvalidOperationException invalidOperationException => new AppException(invalidOperationException.Message, 400),
            _ => ex
        };
    }

    private static bool IsNotFoundOperation(InvalidOperationException exception)
    {
        return exception.Message.Contains("not found", StringComparison.OrdinalIgnoreCase);
    }
}
