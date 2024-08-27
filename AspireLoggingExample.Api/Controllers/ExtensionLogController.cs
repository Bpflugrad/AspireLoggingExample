using Microsoft.AspNetCore.Mvc;

namespace AspireLoggingExample.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ExtensionLogController(ILogger<ExtensionLogController> logger) : ControllerBase
{
    [HttpGet(Name = "GetExtensionLog")]

    public string Get()
    {
        const string logMessage = "LogInformation({value})";

        logger.LogInformation("LogInformation({value})", 9001);

        return logMessage;
    }
}