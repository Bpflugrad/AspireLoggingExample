using Microsoft.AspNetCore.Mvc;

namespace AspireLoggingExample.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AttributeLogController(ILogger<AttributeLogController> logger) : ControllerBase
{
    [HttpGet(Name = "GetAttributeLog")]

    public string Get()
    {
        const string logMessage = "LogFromAttributeMessage({value})";

        logger.LogFromAttributeMessage(9001);

        return logMessage;
    }
}

internal static partial class LoggerExtensions
{
    [LoggerMessage(LogLevel.Information, "LogFromAttributeMessage({value})")]
    internal static partial void LogFromAttributeMessage(this ILogger logger, int value);
}