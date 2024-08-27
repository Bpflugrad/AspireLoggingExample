using Microsoft.AspNetCore.Mvc;

namespace AspireLoggingExample.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ExceptionLogController(ILogger<ExceptionLogController> logger) : ControllerBase
{
    [HttpGet(Name = "GetExceptionLog")]

    public string Get()
    {
        const string logMessage = "LogExceptionMessage({value})";

        try
        {
            throw new Exception("Exception Message");
        }
        catch (Exception e)
        {
            logger.LogExceptionMessage(e, 9001);
        }


        return logMessage;
    }
}

internal static partial class LoggerExtensions
{
    [LoggerMessage(LogLevel.Information, "LogExceptionMessage({value})")]
    internal static partial void LogExceptionMessage(this ILogger logger, Exception exception, int value);
}